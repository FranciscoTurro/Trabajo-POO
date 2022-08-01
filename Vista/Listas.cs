﻿using System;
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
    public partial class Listas : Form
    {
        public Listas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Controladora.Producto.obtenerInstancia().ListaProductos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Controladora.Usuario.obtenerInstancia().ListaUsuarios(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainApp app = new MainApp();
            app.Show();
            this.Hide();
        }

        private void Listas_Load(object sender, EventArgs e)
        {
            Size screenSize = Screen.PrimaryScreen.WorkingArea.Size;
            Location = new Point(screenSize.Width / 2 - Width / 2, screenSize.Height / 2 - Height / 2); //aparece en el medio de la pantalla
        }
    }
}
