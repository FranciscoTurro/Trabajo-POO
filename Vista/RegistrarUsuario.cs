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
    public partial class RegistrarUsuario : Form
    {
        public RegistrarUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Modelo.Usuario Neos = new Modelo.Usuario(); 
            Neos.Nombre = textBox1.Text;
            Neos.Email = textBox2.Text;
            Neos.Dni = textBox3.Text;
            Neos.Contraseña = Controladora.Encriptar.GetSHA256(textBox4.Text);
            Neos.Perfil = CreaCliente();

            if (CheckEmail() == true && NombreUnico() == true)
            {
                Controladora.Usuario.obtenerInstancia().AgregarUsuario(Neos);
            }
            else MessageBox.Show("Datos ingresados incorrectos. Recuerde que el usuario tiene que ser unico y el email tiene que tener @xx.com");
        }

        private bool CheckEmail ()
        {
            string email = textBox2.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                return false;
        }

        private bool NombreUnico()
        {
            Modelo.Usuario x = Controladora.Usuario.obtenerInstancia().ListaUsuarios().Find(usuario => usuario.Nombre == textBox1.Text);
            if (x != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
            
        private Modelo.Perfil CreaCliente()
        {
            return Controladora.Perfiles.obtenerInstancia().ListarPerfiles().Find(item => item.Nombre == "Cliente"); 
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button3.BringToFront();
        }
            
        private void button2_Click(object sender, EventArgs e)
        {
            Bienvenida f2 = new Bienvenida();
            f2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox4.PasswordChar == '*')
            {
                button4.BringToFront();
                textBox4.PasswordChar = '\0';
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.PasswordChar == '\0')
            {
                button3.BringToFront();
                textBox4.PasswordChar = '*';
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //toma solo numeros como input valido
        }
    }
}
