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
    public partial class AgregarProductos : Form
    {
        public AgregarProductos()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Controladora.Validaciones.NombreUnicoProd(textBox1.Text) == false | (textBox2.TextLength)==0 | (textBox3.TextLength) == 0| (textBox4.TextLength)==0)
            {
                MessageBox.Show("Llenar todos los campos.");
                return;
            }

            Modelo.Producto producto = new Modelo.Producto();
            producto.Nombre = textBox1.Text;
            producto.Stock = textBox2.Text;
            producto.Descripcion = textBox3.Text;
            producto.Precio = textBox4.Text;

            Controladora.Producto.obtenerInstancia().AgregarProducto(producto);
            MessageBox.Show("Producto agregado a la base de datos"); 
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //toma solo numeros como input valido
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //toma solo numeros como input valido
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GestionarProductos form = new GestionarProductos();
            form.Show();
            this.Close();   
        }

        private void AgregarProductos_Load(object sender, EventArgs e)
        {
            Size screenSize = Screen.PrimaryScreen.WorkingArea.Size;
            Location = new Point(screenSize.Width / 2 - Width / 2, screenSize.Height / 2 - Height / 2); //aparece en el medio de la pantalla
        }
    }
}
