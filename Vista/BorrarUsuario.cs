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
    public partial class BorrarUsuario : Form
    {
        public BorrarUsuario()
        {
            InitializeComponent();
        }

        private void BorrarUsuario_Load(object sender, EventArgs e)
        {
            List<Modelo.Usuario> listaUsuarios = Controladora.Usuario.obtenerInstancia().ListaUsuarios();
            dataGridView1.DataSource = listaUsuarios;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Seguro de querer borrar al usuario? Esta accion es permanente.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                Modelo.Usuario seleccionado = dataGridView1.SelectedRows[0].DataBoundItem as Modelo.Usuario;
                Controladora.Usuario.obtenerInstancia().BorrarUsuario(seleccionado);

                List<Modelo.Usuario> listaUsuarios = Controladora.Usuario.obtenerInstancia().ListaUsuarios();
                dataGridView1.DataSource = listaUsuarios; //refresco la lista
            }
            if (respuesta == DialogResult.No)
            {
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainApp app = new MainApp();
            app.Show();
            this.Hide();
        }
    }
}
