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
    public partial class GestionarPerfiles : Form
    {
        public GestionarPerfiles()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1 != null)
            {
                Modelo.Perfil perfil = new Modelo.Perfil();
                perfil.Nombre = textBox1.Text;
                Controladora.Perfiles.obtenerInstancia().AgregarPerfil(perfil);
            }
            MessageBox.Show("Perfil creado con exito");
            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainApp app = new MainApp();
            app.Show();
            this.Hide();
        }

        private void GestionarPerfiles_Load(object sender, EventArgs e)
        {
            List<Modelo.Perfil> lista = Controladora.Perfiles.obtenerInstancia().ListarPerfiles();
            dataGridView1.DataSource = lista;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Seguro de querer borrar este perfil? Esta accion es permanente.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                Modelo.Perfil seleccionado = dataGridView1.SelectedRows[0].DataBoundItem as Modelo.Perfil;
                Controladora.Perfiles.obtenerInstancia().EliminarPerfil(seleccionado);

                List<Modelo.Perfil> lista = Controladora.Perfiles.obtenerInstancia().ListarPerfiles();
                dataGridView1.DataSource = lista;
            }
            if (respuesta == DialogResult.No)
            {
                return;
            }
        }
    }
}
