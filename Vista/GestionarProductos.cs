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

        private void button2_Click(object sender, EventArgs e)
        {
            Modelo.Producto producto = new Modelo.Producto();
            producto.Nombre = textBox1.Text;
            producto.Stock = textBox2.Text;
            producto.Descripcion = textBox3.Text;
            producto.Precio = textBox4.Text;

            Controladora.Producto.obtenerInstancia().AgregarProducto(producto);
            dataGridView1.DataSource = Controladora.Producto.obtenerInstancia().ListaProductos();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Modelo.Producto seleccionado = dataGridView1.SelectedRows[0].DataBoundItem as Modelo.Producto;
            Controladora.Producto.obtenerInstancia().EliminarProducto(seleccionado);
            dataGridView1.DataSource = Controladora.Producto.obtenerInstancia().ListaProductos();


        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //toma solo numeros como input valido
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //toma solo numeros como input valido
        }
    }
}
