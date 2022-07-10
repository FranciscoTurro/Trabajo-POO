namespace Vista
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
            this.CrearPerfil = new System.Windows.Forms.ToolStripMenuItem();
            this.Placeholder = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregar});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(605, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnAgregar
            // 
            this.btnAgregar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GestionarClientes,
            this.CrearPerfil,
            this.Placeholder});
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(69, 20);
            this.btnAgregar.Text = "Opciones";
            // 
            // GestionarClientes
            // 
            this.GestionarClientes.Name = "GestionarClientes";
            this.GestionarClientes.Size = new System.Drawing.Size(180, 22);
            this.GestionarClientes.Text = "Gestionar usuarios";
            this.GestionarClientes.Visible = false;
            this.GestionarClientes.Click += new System.EventHandler(this.formGestionarUsuarios_Click);
            // 
            // CrearPerfil
            // 
            this.CrearPerfil.Name = "CrearPerfil";
            this.CrearPerfil.Size = new System.Drawing.Size(180, 22);
            this.CrearPerfil.Text = "Crear perfil";
            this.CrearPerfil.Visible = false;
            this.CrearPerfil.Click += new System.EventHandler(this.CrearPerfil_Click);
            // 
            // Placeholder
            // 
            this.Placeholder.Name = "Placeholder";
            this.Placeholder.Size = new System.Drawing.Size(180, 22);
            this.Placeholder.Text = "Listar usuarios";
            this.Placeholder.Click += new System.EventHandler(this.Placeholder_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(518, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Log out";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 324);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainApp";
            this.Text = "MainApp";
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
        private System.Windows.Forms.ToolStripMenuItem CrearPerfil;
        private System.Windows.Forms.ToolStripMenuItem Placeholder;
    }
}