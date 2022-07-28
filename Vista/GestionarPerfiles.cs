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
            List<Modelo.Formulario> formulariosNewUser = new List<Modelo.Formulario>();
            if (string.IsNullOrWhiteSpace(textBox1.Text) || Controladora.Validaciones.NombreUnicoUser(textBox1.Text) == false)
            {
                MessageBox.Show("Ingrese un nombre de perfil valido");
                return;
            }

            if (checkBox2.Checked == true)
            {
                formulariosNewUser.Add(Controladora.Formularios.obtenerInstancia().ListarFormularios().Find(item => item.Nombre == "CrearPerfil"));
            }
            DialogResult respuesta = MessageBox.Show("Seguro de querer crear este perfil? No puede ser borrado mas adelante.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                formulariosNewUser.Add(Controladora.Formularios.obtenerInstancia().ListarFormularios().Find(item => item.Nombre == "GestionarClientes"));
                Modelo.Perfil perfil = new Modelo.Perfil();
                perfil.Nombre = textBox1.Text;
                perfil.Formulario = formulariosNewUser;
                Controladora.Perfiles.obtenerInstancia().AgregarPerfil(perfil);
            }
            if (respuesta == DialogResult.No)
            {
                return;
            }

            MessageBox.Show("Perfil creado con exito");
            textBox1.Clear();
            checkBox2.Checked = false;
            List<Modelo.Perfil> lista = Controladora.Perfiles.obtenerInstancia().ListarPerfiles();
            dataGridView1.DataSource = lista;
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

            List<Modelo.Formulario> lista2 = Controladora.Formularios.obtenerInstancia().ListarFormularios();

            for (int i = 0; i < lista2.Count; i++)
            {
                CheckBox box = new CheckBox();
                box.Tag = lista2[i].Nombre;
                box.Text = lista2[i].Nombre;
                box.AutoSize = true;
                box.Location = new Point(10, i * 50); //vertical
                this.Controls.Add(box);
            }

            //private void button2_Click(object sender, EventArgs e) NO FUNCIONA EL ELIMINAR PERFILES, PROBLEMA CON TABLAS INTERMEDIAS Y LA FORMA EN LA QUE SE CREAN LOS PERFILES.
            //{
            //    DialogResult respuesta = MessageBox.Show("Seguro de querer borrar este perfil? Esta accion es permanente.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (respuesta == DialogResult.Yes)
            //    {
            //        Modelo.Perfil seleccionado = dataGridView1.SelectedRows[0].DataBoundItem as Modelo.Perfil;
            //        Controladora.Perfiles.obtenerInstancia().EliminarPerfil(seleccionado);

            //        List<Modelo.Perfil> lista = Controladora.Perfiles.obtenerInstancia().ListarPerfiles();
            //        dataGridView1.DataSource = lista;
            //    }
            //    if (respuesta == DialogResult.No)
            //    {
            //        return;
            //    }
            //}
        }
    }
}
