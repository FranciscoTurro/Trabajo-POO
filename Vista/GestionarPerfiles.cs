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

        List<CheckBox> listaChecks = new List<CheckBox>();

        private void GestionarPerfiles_Load(object sender, EventArgs e)
        {
            List<Modelo.Perfil> lista = Controladora.Perfiles.obtenerInstancia().ListarPerfiles();
            List<string> listaNombres = new List<string>();
            foreach (Modelo.Perfil item in lista)
            {
                listaNombres.Add(item.Nombre);
            }

            var result = listaNombres.Select(s => new { Nombre = s }).ToList(); //los datagridview pueden mostrar solo propiedades, y la unica propiedad de un string es su length. sin esta linea no se ven los nombres en el dgv
            dataGridView1.DataSource = result;

            List<Modelo.Formulario> lista2 = Controladora.Formularios.obtenerInstancia().ListarFormularios();

            for (int i = 0; i < lista2.Count; i++)   //creo de forma dinamica un checkbox por cada formulario cargado en la base de datos
            {
                CheckBox box = new CheckBox();
                box.Tag = lista2[i].Nombre;
                box.Text = lista2[i].Nombre;
                box.AutoSize = true;
                box.Location = new Point(410,i * 30);
                this.Controls.Add(box);
                listaChecks.Add(box);//agrega los checkboxes a una lista
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Modelo.Formulario> formulariosNewUser = new List<Modelo.Formulario>();
            if (string.IsNullOrWhiteSpace(textBox1.Text) || Controladora.Validaciones.NombreUnicoUser(textBox1.Text) == false)
            {
                MessageBox.Show("Ingrese un nombre de perfil valido");
                return;
            }

            for(int i = 0; i < listaChecks.Count; i++)
            {
                if (listaChecks[i].Checked == true)
                {
                    formulariosNewUser.Add(Controladora.Formularios.obtenerInstancia().ListarFormularios().Find(item => item.Nombre == listaChecks[i].Text));
                }
                //itera la lista de checkboxes, si encuentra uno checkeado lo busca en la lista de formularios y lo agrega a una lista vacia de formularios. 
                //esta lista de formularios es para agregarle al perfil creado
            }

            DialogResult respuesta = MessageBox.Show("Seguro de querer crear este perfil? No puede ser borrado mas adelante.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
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
            List<Modelo.Perfil> lista = Controladora.Perfiles.obtenerInstancia().ListarPerfiles();
            dataGridView1.DataSource = lista;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainApp app = new MainApp();
            app.Show();
            this.Hide();
        }
    }
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