using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace Vista
{
    public partial class GestionarUsuarios : Form
    {
        public GestionarUsuarios()
        {
            InitializeComponent();
        }

        private void GestionarUsuarios_Load(object sender, EventArgs e)
        {
            comboBox1.Hide();
            label5.Hide();
            button3.Hide();

            List<Modelo.Usuario> listaUsuarios = Controladora.Usuario.obtenerInstancia().ListaUsuarios();
            dataGridView1.DataSource = listaUsuarios; //cargo el datagridview con la lista de todos los usuarios en la base de datos

            textBox3.MaxLength = 8; //se pueden ingresar solo 8 numeros como dni



            Modelo.Usuario usuarioactual = Controladora.Usuario.obtenerInstancia().usuarioActual;
            List<Modelo.Formulario> listaFormularios = Controladora.Formularios.obtenerInstancia().ListaFormularios(usuarioactual);
            listaFormularios.ForEach(formulario =>
            {
                List<Modelo.Permiso> listaPermisos = Controladora.Permisos.obtenerInstancia().ListarPermisos(formulario);
                listaPermisos.ForEach(permiso =>
                {
                    if (permiso.NombreSistema == "Eliminar")
                    {
                        comboBox1.DataSource = Controladora.Perfiles.obtenerInstancia().ListarPerfiles();
                        comboBox1.Show();
                        label5.Show();
                        button3.Show();
                    }
                });
            });
        }

        private bool NombreUnico()
        {
            Modelo.Usuario x = Controladora.Usuario.obtenerInstancia().ListaUsuarios().Find(usuario => usuario.Nombre == textBox1.Text);
            if (x != null)
                return false;
            else
                return true;
        }

        private bool CheckEmail()
        {
            string email = textBox2.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                return false;
        }

        private bool LongitudDNI()
        {
            if (textBox3.TextLength != 8)
                return false;
            else
                return true;
        }

        private bool CamposCompletos()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrWhiteSpace(textBox2.Text) && LongitudDNI() == false) //checkea que todos los campos esten completos, excepto la contraseña, que puede ser vacia
                return false;
            else
                return true;
        }

        private Modelo.Perfil DarPerfilEmpleado()
        {
            return Controladora.Perfiles.obtenerInstancia().ListarPerfiles().Find(item => item.Nombre == "Empleado");
        }

        private void button2_Click(object sender, EventArgs e) //modificar usuario
        {
            Modelo.Usuario usuarioactual = Controladora.Usuario.obtenerInstancia().usuarioActual;
            Modelo.Usuario seleccionado = dataGridView1.SelectedRows[0].DataBoundItem as Modelo.Usuario;
//si el textbox NO esta vacio se reemplaza el atributo correspondiente del usuario seleccionado
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && NombreUnico() == true) { seleccionado.Nombre = textBox1.Text; }
            if (!string.IsNullOrWhiteSpace(textBox2.Text) && CheckEmail() == true) { seleccionado.Email = textBox2.Text; }
            if (!string.IsNullOrWhiteSpace(textBox3.Text) && LongitudDNI() == true) { seleccionado.Dni = textBox3.Text; }
            if (!string.IsNullOrWhiteSpace(textBox4.Text)) { seleccionado.Contraseña = Controladora.Encriptar.GetSHA256(textBox4.Text); }

            List<Modelo.Formulario> listaFormularios = Controladora.Formularios.obtenerInstancia().ListaFormularios(usuarioactual);
            listaFormularios.ForEach(formulario =>
            {
                List<Modelo.Permiso> listaPermisos = Controladora.Permisos.obtenerInstancia().ListarPermisos(formulario);
                listaPermisos.ForEach(permiso =>
                {
                    if (permiso.NombreSistema == "Eliminar")
                    {
                        seleccionado.Perfil = (Modelo.Perfil)comboBox1.SelectedValue;
                    }
                });
            });


            Modelo.SingletonContexto.obtenerInstancia().Contexto.SaveChanges();

            List<Modelo.Usuario> listaUsuarios = Controladora.Usuario.obtenerInstancia().ListaUsuarios();
            dataGridView1.DataSource = listaUsuarios;
            MessageBox.Show("Usuario modificado con exito"); 
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //toma solo numeros como input valido
        }

        private void button1_Click(object sender, EventArgs e) //agregar usuario
        {
            Modelo.Usuario usuarioactual = Controladora.Usuario.obtenerInstancia().usuarioActual;
            Modelo.Usuario Neos = new Modelo.Usuario(); //creo un usuario vacio y lo lleno con los contenidos en las textboxes
            Neos.Nombre = textBox1.Text;
            Neos.Email = textBox2.Text;
            Neos.Dni = textBox3.Text;
            Neos.Contraseña = Controladora.Encriptar.GetSHA256(textBox4.Text);
            Neos.Perfil = DarPerfilEmpleado();

            List<Modelo.Formulario> listaFormularios = Controladora.Formularios.obtenerInstancia().ListaFormularios(usuarioactual);
            listaFormularios.ForEach(formulario =>
            {
                List<Modelo.Permiso> listaPermisos = Controladora.Permisos.obtenerInstancia().ListarPermisos(formulario);
                listaPermisos.ForEach(permiso =>
                {
                    if (permiso.NombreSistema == "Eliminar")
                    {
                        Neos.Perfil = (Modelo.Perfil)comboBox1.SelectedValue;
                    }
                });
            });

            if (CamposCompletos() == false)
            {
                MessageBox.Show("Falta completar campos");
            }
            if (NombreUnico() == false)  //funciones validan que el email y el nombre sean correctos, devuelven un mensaje de error y no permiten la creacion si se ingresan incorrectamente
            {
                MessageBox.Show("Usuario ya existente");
            }
            if (CheckEmail() == false)
            {
                MessageBox.Show("El email ingresado no es valido");
            }
            if (LongitudDNI() == false)
            {
                MessageBox.Show("El DNI ingresado no es valido");
            }
            if (CheckEmail() == true && NombreUnico() == true && CamposCompletos() == true && LongitudDNI() == true)
            {
                Controladora.Usuario.obtenerInstancia().AgregarUsuario(Neos);
                MessageBox.Show("Usuario creado con exito"); //avisa que se creo un usuario y limpia las text boxes
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                List<Modelo.Usuario> listaUsuarios = Controladora.Usuario.obtenerInstancia().ListaUsuarios();
                dataGridView1.DataSource = listaUsuarios;
            }
        }

        private void button3_Click(object sender, EventArgs e) //eliminar usuario
        {
            Modelo.Usuario seleccionado = dataGridView1.SelectedRows[0].DataBoundItem as Modelo.Usuario;
            if (seleccionado.Nombre == Controladora.Usuario.obtenerInstancia().usuarioActual.Nombre)
            {
                MessageBox.Show("No es posible borrar el usuario actual.");
                return;
            }

            if (seleccionado.Nombre == "admin")
            {
                MessageBox.Show("Este usuario esta protegido.");
                return;
            }

            DialogResult respuesta = MessageBox.Show("Seguro de querer borrar al usuario? Esta accion es permanente.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                Controladora.Usuario.obtenerInstancia().BorrarUsuario(seleccionado);

                List<Modelo.Usuario> listaUsuarios = Controladora.Usuario.obtenerInstancia().ListaUsuarios();
                dataGridView1.DataSource = listaUsuarios; //refresco la lista
            }
            if (respuesta == DialogResult.No)
            {
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainApp app = new MainApp();
            app.Show();
            this.Hide();
        }
    }
}

