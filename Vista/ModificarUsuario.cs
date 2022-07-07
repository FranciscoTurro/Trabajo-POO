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
    public partial class ModificarUsuario : Form
    {
        public ModificarUsuario()
        {
            InitializeComponent();
        }

        private void ModificarUsuario_Load(object sender, EventArgs e)
        {
            List<Modelo.Usuario> listaUsuarios = Controladora.Usuario.obtenerInstancia().ListaUsuarios();
            dataGridView1.DataSource = listaUsuarios;

            textBox3.MaxLength = 8; //se pueden ingresar solo 8 numeros como dni

            Modelo.Usuario usuarioactual = Controladora.Usuario.obtenerInstancia().usuarioActual;
            if (usuarioactual.Perfil.Nombre == "Empleado")  //si el usuario actual es un empleado escondo la posibilidad de crear un gerente
            {
                comboBox1.Hide();
                label5.Hide();
            }
            else
            {
                comboBox1.DataSource = Controladora.Perfiles.obtenerInstancia().ListarPerfiles();

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Modelo.Usuario usuarioactual = Controladora.Usuario.obtenerInstancia().usuarioActual;
            Modelo.Usuario seleccionado = dataGridView1.SelectedRows[0].DataBoundItem as Modelo.Usuario;

            if (!string.IsNullOrWhiteSpace(textBox1.Text) && NombreUnico() == true) { seleccionado.Nombre = textBox1.Text; }
            if (!string.IsNullOrWhiteSpace(textBox2.Text) && CheckEmail() == true) { seleccionado.Email = textBox2.Text; } 
            if (!string.IsNullOrWhiteSpace(textBox3.Text) && LongitudDNI() == true) { seleccionado.Dni = textBox3.Text; } 
            if (!string.IsNullOrWhiteSpace(textBox4.Text)) { seleccionado.Contraseña = Controladora.Encriptar.GetSHA256(textBox4.Text); }
            if (usuarioactual.Perfil.Nombre == "Gerente")
            {
                seleccionado.Perfil = (Modelo.Perfil)comboBox1.SelectedValue;
            }
            Modelo.SingletonContexto.obtenerInstancia().Contexto.SaveChanges();

            List<Modelo.Usuario> listaUsuarios = Controladora.Usuario.obtenerInstancia().ListaUsuarios();
            dataGridView1.DataSource = listaUsuarios;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
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

        private Modelo.Perfil DarPerfilEmpleado()
        {
            return Controladora.Perfiles.obtenerInstancia().ListarPerfiles().Find(item => item.Nombre == "Empleado");
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //toma solo numeros como input valido
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainApp app = new MainApp();
            app.Show();
            this.Hide();
        }
    }
}
