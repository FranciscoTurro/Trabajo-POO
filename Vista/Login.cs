using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Modelo.Usuario> ListaUsuarios = new List<Modelo.Usuario>();
            ListaUsuarios = Controladora.Usuario.obtenerInstancia().ListaUsuarios();  //Se crea una lista con todos los usuarios en la base de datos

            Modelo.Usuario Neos = new Modelo.Usuario();
            Neos.Nombre = textBox1.Text;
            Neos.Contraseña = Controladora.Validaciones.GetSHA256(textBox2.Text);

            Modelo.Usuario usuarioIngresado = ListaUsuarios.Find(usuario => usuario.Nombre == Neos.Nombre && usuario.Contraseña == Neos.Contraseña);//Se busca en la lista un usuario que tenga el mismo nombre y contraseña que el ingresado

            if (usuarioIngresado != null)
            {
                Controladora.Usuario.obtenerInstancia().AgregarUsuarioActual(usuarioIngresado);
                MainApp app = new MainApp();
                app.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No existe el usuario ingresado.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '*')
            {
                button4.BringToFront();
                textBox2.PasswordChar = '\0';
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '\0')
            {
                button3.BringToFront();
                textBox2.PasswordChar = '*';
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            button3.BringToFront();
        }
    }
}
