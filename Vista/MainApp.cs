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
            button1.Hide();
            button2.Hide();
            button3.Hide();

            Modelo.Usuario usuarioActual = Controladora.Usuario.obtenerInstancia().usuarioActual; //traigo al usuario actual
            List<Modelo.Formulario> formularios = Controladora.Formularios.obtenerInstancia().ListaFormularios(usuarioActual); //traigo la lista de formularios a los que tiene acceso el usuario actual
            Modelo.Formulario formularioBuscado = formularios.Find(f => f.NombreSistema == "formGestionarUsuarios");  //veo si entre los formularios a los que tiene acceso esta formGestionarUsuarios
            List<Modelo.Permiso> permisos = Controladora.Permisos.obtenerInstancia().ListaPermisos(formularioBuscado); //busco los permisos que tengo con ese formulario
            permisos.ForEach(item =>
            {
                if (item.NombreSistema == "btnAgregar") button1.Show();
                if (item.NombreSistema == "btnEliminar") button3.Show();
                if (item.NombreSistema == "btnModificar") button2.Show();
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistrarUsuario app = new RegistrarUsuario();
            app.Show();
            this.Hide();
        }
    }
}
