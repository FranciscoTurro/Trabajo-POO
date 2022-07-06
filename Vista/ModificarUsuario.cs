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
            comboBox1.DataSource = Controladora.Perfiles.obtenerInstancia().ListarPerfiles();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Modelo.Usuario seleccionado = dataGridView1.SelectedRows[0].DataBoundItem as Modelo.Usuario;
            if (!string.IsNullOrWhiteSpace(textBox1.Text)) { seleccionado.Nombre = textBox1.Text; }
            seleccionado.Email = textBox2.Text;
            seleccionado.Dni = textBox3.Text;
            seleccionado.Contraseña = Controladora.Encriptar.GetSHA256(textBox4.Text); 
            seleccionado.Perfil = (Modelo.Perfil)comboBox1.SelectedValue;
            Modelo.SingletonContexto.obtenerInstancia().Contexto.SaveChanges();

            List<Modelo.Usuario> listaUsuarios = Controladora.Usuario.obtenerInstancia().ListaUsuarios();
            dataGridView1.DataSource = listaUsuarios;
        }
    }
}
