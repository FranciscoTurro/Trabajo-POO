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
    public partial class MainApp : Form
    {
        public MainApp()
        {
            InitializeComponent();
        }

        private void MainApp_Load(object sender, EventArgs e)
        {
            Modelo.Usuario usuario = Controladora.Usuario.obtenerInstancia().usuarioActual;
            List<Modelo.Formulario> formulariosUsuario = Controladora.Formularios.obtenerInstancia().ListaFormularios(usuario); //hago una lista con todos los formularios del usuario actual
            formulariosUsuario.ForEach((formulario) => //por cada formulario en la lista checkeo una por una las opciones del menustrip, y si una es igual la hace visible
            {
                foreach (ToolStripMenuItem opcion in menuStrip1.Items)
                {
                    foreach (ToolStripMenuItem form in opcion.DropDownItems)
                    {
                        if (form.Name == formulario.NombreSistema)
                        {
                            form.Visible = true;
                            return;
                        }
                    }
                }
            });
        }

        private void formGestionarUsuarios_Click(object sender, EventArgs e)
        {
            GestionarUsuarios app = new GestionarUsuarios();
            app.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login app = new Login();
            app.Show();
            this.Hide();
        }

        private void CrearPerfil_Click(object sender, EventArgs e)
        {
            GestionarPerfiles app = new GestionarPerfiles();
            app.Show();
            this.Hide();
        }

        private void Placeholder_Click(object sender, EventArgs e)
        {
            ListarUsuarios app = new ListarUsuarios();
            app.Show();
            this.Hide();
        }
    }
}
