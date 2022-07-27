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
    public partial class GestionarProductos : Form
    {
        public GestionarProductos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainApp app = new MainApp();
            app.Show();
            this.Hide();
        }

        private void ListarUsuarios_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Controladora.Producto.obtenerInstancia().ListaProductos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Seguro de querer borrar el producto? Esta accion es permanente.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                Modelo.Producto seleccionado = dataGridView1.SelectedRows[0].DataBoundItem as Modelo.Producto;
                Controladora.Producto.obtenerInstancia().EliminarProducto(seleccionado);
                Modelo.SingletonContexto.obtenerInstancia().Contexto.SaveChanges();
                dataGridView1.DataSource = Controladora.Producto.obtenerInstancia().ListaProductos();
            }
            if (respuesta == DialogResult.No)
            {
                return;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Modelo.Producto seleccionado = dataGridView1.SelectedRows[0].DataBoundItem as Modelo.Producto;
            if (seleccionado == null ^ String.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Debe tener seleccionado un producto y un numero valido para agregar/restar.");
                return;
            } 
            else
            {
                int suma = Convert.ToInt32(seleccionado.Stock) + Convert.ToInt32(textBox5.Text);
                seleccionado.Stock = suma.ToString();
                Modelo.SingletonContexto.obtenerInstancia().Contexto.SaveChanges();
                textBox5.Text = "";
                dataGridView1.DataSource = Controladora.Producto.obtenerInstancia().ListaProductos();
            }

        }
        private void button5_Click(object sender, EventArgs e)
        {
            Modelo.Producto seleccionado = dataGridView1.SelectedRows[0].DataBoundItem as Modelo.Producto;
            if (seleccionado == null ^ String.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Debe tener seleccionado un producto y un numero valido para agregar/restar.");
                return;
            }
            else
            {
                int suma = Convert.ToInt32(seleccionado.Stock) + Convert.ToInt32(textBox6.Text);
                if (suma > 0) { suma = 0; }
                seleccionado.Stock = suma.ToString();
                textBox6.Text = "";
                dataGridView1.DataSource = Controladora.Producto.obtenerInstancia().ListaProductos();
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //toma solo numeros como input valido

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //toma solo numeros como input valido

        }

        private void button6_Click(object sender, EventArgs e)
        {
            AgregarProductos popupForm = new AgregarProductos();
            popupForm.ShowDialog();
        }
    }
}
