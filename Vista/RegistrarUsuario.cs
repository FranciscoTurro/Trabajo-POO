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
            Neos.Contraseña = textBox4.Text;
            Neos.Perfil = (Modelo.Perfil)comboBox1.SelectedValue;
            Controladora.Usuario.obtenerInstancia().AgregarUsuario(Neos);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Controladora.Perfiles.obtenerInstancia().ListarPerfiles();
        }
    }
}
