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

        private void FormIntermedia_Load(object sender, EventArgs e)
        {
            Modelo.Usuario usuario = Controladora.Usuario.obtenerInstancia().usuarioActual;

            List<Modelo.Formulario> formulariosHabilitados = Controladora.Formularios.obtenerInstancia().ListaFormularios(usuario);
            formulariosHabilitados.ForEach((formulario) => {
                var opcionesStripMenu = menuStrip1.Items.Find(formulario.NombreSistema, true);
                opcionesStripMenu.ToList().ForEach(opciones =>
                {
                    if (opciones.Name == formulario.NombreSistema)
                    {
                        opciones.Enabled = true;
                    }
                });
            });
        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RegistrarUsuario app = new RegistrarUsuario();
            app.Show();
        }
    }
}
