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
        bool permisoVerificar = false; //IMPORTANTE, variable que se convierte en true cuando el usuario tiene permisos avanzados
        bool permisoVerificar2 = false;

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
                    if (permiso.NombreSistema == "Eliminar") //checkea que el usuario actual tenga permisos avanzados
                    {
                        permisoVerificar = true;
                    }
                });
            });

            if (permisoVerificar == true)
            {
                comboBox1.DataSource = Controladora.Perfiles.obtenerInstancia().ListarPerfiles();
                comboBox1.Show();
                label5.Show();
                button3.Show();
            }
        }

        private Modelo.Perfil DarPerfilEmpleado()
        {
            return Controladora.Perfiles.obtenerInstancia().ListarPerfiles().Find(item => item.Nombre == "Empleado");
        }

        private void button2_Click(object sender, EventArgs e) //modificar usuario
        {
            Modelo.Usuario usuarioactual = Controladora.Usuario.obtenerInstancia().usuarioActual;
            Modelo.Usuario seleccionado = dataGridView1.SelectedRows[0].DataBoundItem as Modelo.Usuario;
            if (usuarioactual == seleccionado ^ seleccionado.Nombre == "admin")
            {
                MessageBox.Show("No es posible editar este usuario.");
                return;
            }

            List<Modelo.Formulario> listaFormularios = Controladora.Formularios.obtenerInstancia().ListaFormularios(seleccionado);
            listaFormularios.ForEach(formulario =>
            {
                List<Modelo.Permiso> listaPermisos = Controladora.Permisos.obtenerInstancia().ListarPermisos(formulario);
                listaPermisos.ForEach(permiso =>
                {
                    if (permiso.NombreSistema == "Eliminar") //checkea que el usuario seleccionado tenga permisos avanzados
                    {
                        permisoVerificar2 = true;
                    }
                });
            });

            if (permisoVerificar == false & permisoVerificar2 == true) //si el usuario no tiene permisos avanzados no puede editar un perfil que si los tenga
            {
                MessageBox.Show("No es posible editar el perfil de este usuario");
                return;
            }
            //si el textbox NO esta vacio se reemplaza el atributo correspondiente del usuario seleccionado
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && Controladora.Validaciones.NombreUnicoUser(textBox1.Text) == true) { seleccionado.Nombre = textBox1.Text; } 
            if (!string.IsNullOrWhiteSpace(textBox2.Text) && Controladora.Validaciones.CheckEmail(textBox2.Text) == true) { seleccionado.Email = textBox2.Text; }
            if (!string.IsNullOrWhiteSpace(textBox3.Text) && Controladora.Validaciones.LongitudDNI(textBox3.TextLength) == true) { seleccionado.Dni = textBox3.Text; }
            if (!string.IsNullOrWhiteSpace(textBox4.Text)) { seleccionado.Contraseña = Controladora.Validaciones.GetSHA256(textBox4.Text); }


            if (permisoVerificar == true)
            {
                seleccionado.Perfil = (Modelo.Perfil)comboBox1.SelectedValue;
            }



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
            Neos.Contraseña = Controladora.Validaciones.GetSHA256(textBox4.Text);
            Neos.Perfil = DarPerfilEmpleado();

            if (permisoVerificar == true) 
            {
                Neos.Perfil = (Modelo.Perfil)comboBox1.SelectedValue;
            }


            if (Controladora.Validaciones.NombreUnicoUser(textBox1.Text) == false)  //funciones validan que el email y el nombre sean correctos, devuelven un mensaje de error y no permiten la creacion si se ingresan incorrectamente
            {
                MessageBox.Show("Nombre de usuario no valido");
            }
            if (Controladora.Validaciones.CheckEmail(textBox2.Text) == false)
            {
                MessageBox.Show("El email ingresado no es valido");
            }
            if (Controladora.Validaciones.LongitudDNI(textBox3.TextLength) == false)
            {
                MessageBox.Show("El DNI ingresado no es valido");
            }
            if (Controladora.Validaciones.CheckEmail(textBox2.Text) == true && Controladora.Validaciones.NombreUnicoUser(textBox1.Text) == true &&  Controladora.Validaciones.LongitudDNI(textBox3.TextLength) == true)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Modelo.Usuario seleccionado = dataGridView1.SelectedRows[0].DataBoundItem as Modelo.Usuario;
            textBox1.Text = seleccionado.Nombre;
            textBox2.Text = seleccionado.Email;
            textBox3.Text = seleccionado.Dni;
            comboBox1.SelectedItem = seleccionado.Perfil;
        }
    }
}

