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
            List<Modelo.Formulario> formularios_habilitados = Controladora.Formularios.obtenerInstancia().ListaFormularios(usuario);
            formularios_habilitados.ForEach((formulario) => {
                foreach (ToolStripMenuItem categoria in menuStrip1.Items)
                {
                    foreach (ToolStripMenuItem form in categoria.DropDownItems)
                    {
                        if (form.Name == formulario.NombreSistema)
                        {
                            form.Enabled = true;
                            return;
                        }
                    }
                }
            });
        }

        private void formGestionarUsuarios_Click(object sender, EventArgs e)
        {
            RegistrarUsuario app = new RegistrarUsuario();
            app.Show();
            this.Hide();
        }
    }
}
