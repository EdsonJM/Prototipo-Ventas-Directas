namespace VentasDirectas.Mantenimientos
{
    partial class Frm_consultaEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_consultaEmpleado));
            this.Dgv_mostrarEmpleado = new System.Windows.Forms.DataGridView();
            this.codEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codTipoPuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primerNombreEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primerApellidoEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dpiEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nitEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaNacEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaContraEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correoEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generoEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_minimizar = new System.Windows.Forms.Button();
            this.Btn_eliminar = new System.Windows.Forms.Button();
            this.Btn_buscar = new System.Windows.Forms.Button();
            this.Txt_buscar = new System.Windows.Forms.TextBox();
            this.Lbl_nombre = new System.Windows.Forms.Label();
            this.Btn_seleccionar = new System.Windows.Forms.Button();
            this.Btn_actualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_mostrarEmpleado)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Dgv_mostrarEmpleado
            // 
            this.Dgv_mostrarEmpleado.AllowUserToAddRows = false;
            this.Dgv_mostrarEmpleado.AllowUserToDeleteRows = false;
            this.Dgv_mostrarEmpleado.AllowUserToResizeColumns = false;
            this.Dgv_mostrarEmpleado.AllowUserToResizeRows = false;
            this.Dgv_mostrarEmpleado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_mostrarEmpleado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_mostrarEmpleado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codEmpleado,
            this.codTipoPuesto,
            this.primerNombreEmpleado,
            this.primerApellidoEmpleado,
            this.dpiEmpleado,
            this.nitEmpleado,
            this.direccionEmpleado,
            this.telefonoEmpleado,
            this.fechaNacEmpleado,
            this.fechaContraEmpleado,
            this.correoEmpleado,
            this.generoEmpleado,
            this.estadoEmpleado});
            this.Dgv_mostrarEmpleado.Location = new System.Drawing.Point(30, 115);
            this.Dgv_mostrarEmpleado.Name = "Dgv_mostrarEmpleado";
            this.Dgv_mostrarEmpleado.RowHeadersVisible = false;
            this.Dgv_mostrarEmpleado.RowTemplate.Height = 24;
            this.Dgv_mostrarEmpleado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_mostrarEmpleado.Size = new System.Drawing.Size(1058, 401);
            this.Dgv_mostrarEmpleado.TabIndex = 0;
            // 
            // codEmpleado
            // 
            this.codEmpleado.HeaderText = "Código empleado";
            this.codEmpleado.Name = "codEmpleado";
            // 
            // codTipoPuesto
            // 
            this.codTipoPuesto.HeaderText = "Código puesto";
            this.codTipoPuesto.Name = "codTipoPuesto";
            // 
            // primerNombreEmpleado
            // 
            this.primerNombreEmpleado.HeaderText = "Primer nombre";
            this.primerNombreEmpleado.Name = "primerNombreEmpleado";
            // 
            // primerApellidoEmpleado
            // 
            this.primerApellidoEmpleado.HeaderText = "Primer Apellido";
            this.primerApellidoEmpleado.Name = "primerApellidoEmpleado";
            // 
            // dpiEmpleado
            // 
            this.dpiEmpleado.HeaderText = "DPI";
            this.dpiEmpleado.Name = "dpiEmpleado";
            // 
            // nitEmpleado
            // 
            this.nitEmpleado.HeaderText = "NIT";
            this.nitEmpleado.Name = "nitEmpleado";
            // 
            // direccionEmpleado
            // 
            this.direccionEmpleado.HeaderText = "Dirección";
            this.direccionEmpleado.Name = "direccionEmpleado";
            // 
            // telefonoEmpleado
            // 
            this.telefonoEmpleado.HeaderText = "Teléfono";
            this.telefonoEmpleado.Name = "telefonoEmpleado";
            // 
            // fechaNacEmpleado
            // 
            this.fechaNacEmpleado.HeaderText = "Fecha de nacimiento";
            this.fechaNacEmpleado.Name = "fechaNacEmpleado";
            // 
            // fechaContraEmpleado
            // 
            this.fechaContraEmpleado.HeaderText = "Fecha de contratación";
            this.fechaContraEmpleado.Name = "fechaContraEmpleado";
            // 
            // correoEmpleado
            // 
            this.correoEmpleado.HeaderText = "Correo";
            this.correoEmpleado.Name = "correoEmpleado";
            // 
            // generoEmpleado
            // 
            this.generoEmpleado.HeaderText = "Genero";
            this.generoEmpleado.Name = "generoEmpleado";
            // 
            // estadoEmpleado
            // 
            this.estadoEmpleado.HeaderText = "Estado";
            this.estadoEmpleado.Name = "estadoEmpleado";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CadetBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Btn_minimizar);
            this.panel1.Controls.Add(this.Btn_eliminar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 45);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "CONSULTA EMPLEADO";
            // 
            // Btn_minimizar
            // 
            this.Btn_minimizar.FlatAppearance.BorderSize = 0;
            this.Btn_minimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_minimizar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_minimizar.Image")));
            this.Btn_minimizar.Location = new System.Drawing.Point(946, 5);
            this.Btn_minimizar.Name = "Btn_minimizar";
            this.Btn_minimizar.Size = new System.Drawing.Size(35, 35);
            this.Btn_minimizar.TabIndex = 6;
            this.Btn_minimizar.UseVisualStyleBackColor = true;
            this.Btn_minimizar.Click += new System.EventHandler(this.Btn_minimizar_Click);
            // 
            // Btn_eliminar
            // 
            this.Btn_eliminar.FlatAppearance.BorderSize = 0;
            this.Btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_eliminar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_eliminar.Image")));
            this.Btn_eliminar.Location = new System.Drawing.Point(1035, 5);
            this.Btn_eliminar.Name = "Btn_eliminar";
            this.Btn_eliminar.Size = new System.Drawing.Size(35, 35);
            this.Btn_eliminar.TabIndex = 5;
            this.Btn_eliminar.UseVisualStyleBackColor = true;
            this.Btn_eliminar.Click += new System.EventHandler(this.Btn_eliminar_Click);
            // 
            // Btn_buscar
            // 
            this.Btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_buscar.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_buscar.Location = new System.Drawing.Point(946, 66);
            this.Btn_buscar.Name = "Btn_buscar";
            this.Btn_buscar.Size = new System.Drawing.Size(92, 31);
            this.Btn_buscar.TabIndex = 7;
            this.Btn_buscar.Text = "Buscar";
            this.Btn_buscar.UseVisualStyleBackColor = true;
            this.Btn_buscar.Click += new System.EventHandler(this.Btn_buscar_Click);
            // 
            // Txt_buscar
            // 
            this.Txt_buscar.Location = new System.Drawing.Point(188, 69);
            this.Txt_buscar.Name = "Txt_buscar";
            this.Txt_buscar.Size = new System.Drawing.Size(726, 22);
            this.Txt_buscar.TabIndex = 6;
            // 
            // Lbl_nombre
            // 
            this.Lbl_nombre.AutoSize = true;
            this.Lbl_nombre.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_nombre.Location = new System.Drawing.Point(90, 73);
            this.Lbl_nombre.Name = "Lbl_nombre";
            this.Lbl_nombre.Size = new System.Drawing.Size(72, 18);
            this.Lbl_nombre.TabIndex = 5;
            this.Lbl_nombre.Text = "Nombre:";
            // 
            // Btn_seleccionar
            // 
            this.Btn_seleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_seleccionar.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_seleccionar.Location = new System.Drawing.Point(894, 545);
            this.Btn_seleccionar.Name = "Btn_seleccionar";
            this.Btn_seleccionar.Size = new System.Drawing.Size(194, 31);
            this.Btn_seleccionar.TabIndex = 8;
            this.Btn_seleccionar.Text = "Seleccionar";
            this.Btn_seleccionar.UseVisualStyleBackColor = true;
            this.Btn_seleccionar.Click += new System.EventHandler(this.Btn_seleccionar_Click);
            // 
            // Btn_actualizar
            // 
            this.Btn_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_actualizar.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_actualizar.Location = new System.Drawing.Point(30, 545);
            this.Btn_actualizar.Name = "Btn_actualizar";
            this.Btn_actualizar.Size = new System.Drawing.Size(194, 31);
            this.Btn_actualizar.TabIndex = 9;
            this.Btn_actualizar.Text = "Actualizar";
            this.Btn_actualizar.UseVisualStyleBackColor = true;
            this.Btn_actualizar.Click += new System.EventHandler(this.Btn_actualizar_Click);
            // 
            // Frm_consultaEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.Btn_actualizar);
            this.Controls.Add(this.Btn_seleccionar);
            this.Controls.Add(this.Btn_buscar);
            this.Controls.Add(this.Txt_buscar);
            this.Controls.Add(this.Lbl_nombre);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Dgv_mostrarEmpleado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_consultaEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_consultaEmpleado";
            this.Load += new System.EventHandler(this.Frm_consultaEmpleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_mostrarEmpleado)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn codEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn codTipoPuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn primerNombreEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn primerApellidoEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn dpiEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn nitEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaNacEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaContraEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn correoEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn generoEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoEmpleado;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_minimizar;
        private System.Windows.Forms.Button Btn_eliminar;
        public System.Windows.Forms.Button Btn_buscar;
        private System.Windows.Forms.TextBox Txt_buscar;
        private System.Windows.Forms.Label Lbl_nombre;
        public System.Windows.Forms.Button Btn_seleccionar;
        public System.Windows.Forms.Button Btn_actualizar;
        public System.Windows.Forms.DataGridView Dgv_mostrarEmpleado;
    }
}