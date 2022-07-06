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
            RegistrarUsuario app = new RegistrarUsuario();
            app.Show();
            this.Hide();
        }

        private void EliminarCliente_Click(object sender, EventArgs e)
        {
            BorrarUsuario app = new BorrarUsuario();
            app.Show();
            this.Hide();
        }

        private void ModificarCliente_Click(object sender, EventArgs e)
        {
            ModificarUsuario app = new ModificarUsuario();
            app.Show();
            this.Hide();
        }
    }
}
