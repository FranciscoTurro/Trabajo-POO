﻿namespace Vista
{
    partial class MainApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.GestionarClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.GestionarProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.GestionarPerfil = new System.Windows.Forms.ToolStripMenuItem();
            this.Listas = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregar});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(259, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnAgregar
            // 
            this.btnAgregar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GestionarClientes,
            this.GestionarProductos,
            this.GestionarPerfil,
            this.Listas});
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(69, 20);
            this.btnAgregar.Text = "Opciones";
            // 
            // GestionarClientes
            // 
            this.GestionarClientes.Name = "GestionarClientes";
            this.GestionarClientes.Size = new System.Drawing.Size(181, 22);
            this.GestionarClientes.Text = "Gestionar usuarios";
            this.GestionarClientes.Visible = false;
            this.GestionarClientes.Click += new System.EventHandler(this.formGestionarUsuarios_Click);
            // 
            // GestionarProductos
            // 
            this.GestionarProductos.Name = "GestionarProductos";
            this.GestionarProductos.Size = new System.Drawing.Size(181, 22);
            this.GestionarProductos.Text = "Gestionar productos";
            this.GestionarProductos.Visible = false;
            this.GestionarProductos.Click += new System.EventHandler(this.Placeholder_Click);
            // 
            // GestionarPerfil
            // 
            this.GestionarPerfil.Name = "GestionarPerfil";
            this.GestionarPerfil.Size = new System.Drawing.Size(181, 22);
            this.GestionarPerfil.Text = "Crear perfil";
            this.GestionarPerfil.Visible = false;
            this.GestionarPerfil.Click += new System.EventHandler(this.CrearPerfil_Click);
            // 
            // Listas
            // 
            this.Listas.Name = "Listas";
            this.Listas.Size = new System.Drawing.Size(181, 22);
            this.Listas.Text = "Listas";
            this.Listas.Visible = false;
            this.Listas.Click += new System.EventHandler(this.Listas_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(172, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Deslogearse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 305);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainApp";
            this.Text = "Aplicación";
            this.Load += new System.EventHandler(this.MainApp_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnAgregar;
        private System.Windows.Forms.ToolStripMenuItem GestionarClientes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem GestionarPerfil;
        private System.Windows.Forms.ToolStripMenuItem GestionarProductos;
        private System.Windows.Forms.ToolStripMenuItem Listas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}