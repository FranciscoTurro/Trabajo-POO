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
            Neos.Perfil = DarPerfilCliente();

            if (CheckEmail() == false)
            {
                MessageBox.Show("El email ingresado no es valido");
            }
            if (NombreUnico() == false)  //funciones validan que el email y el nombre sean correctos, devuelven un mensaje de error y no permiten la creacion si se ingresan incorrectamente
            {
                MessageBox.Show("Usuario ya existente");
            }
            if (CheckEmail() == true && NombreUnico() == true)
            {
                Controladora.Usuario.obtenerInstancia().AgregarUsuario(Neos);
                MessageBox.Show("Usuario creado con exito"); //avisa que se creo un usuario y limpia las text boxes
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
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
                return false;
            else
                return true;
        }
            
        private Modelo.Perfil DarPerfilCliente()
        {
            return Controladora.Perfiles.obtenerInstancia().ListarPerfiles().Find(item => item.Nombre == "Cliente"); 
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button3.BringToFront();
            textBox3.MaxLength = 8; //se pueden ingresar solo 8 numeros como dni
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
