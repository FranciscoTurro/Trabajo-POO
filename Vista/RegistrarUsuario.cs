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
            Controladora.Usuario.obtenerInstancia().AgregarUsuario(Neos);
        }

        private Modelo.Perfil CreaCliente()
        {
            return Controladora.Perfiles.obtenerInstancia().ListarPerfiles().Find(item => item.Nombre == "Cliente"); 
        }

        private void Form2_Load(object sender, EventArgs e)
        {
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
