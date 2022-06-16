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
            Neos.Contraseña = textBox2.Text; 
            
            Modelo.Usuario x = ListaUsuarios.Find(usuario => usuario.Nombre == Neos.Nombre && usuario.Contraseña == Neos.Contraseña); //Se busca en la lista un usuario que tenga el mismo nombre y contraseña que el ingresado
            if (x != null)
            {
                MessageBox.Show("Usuario existe en la base de datos");
            }
            else
            {
                MessageBox.Show("Usuario no existe en la base de datos");
            }
        }
    }
}
