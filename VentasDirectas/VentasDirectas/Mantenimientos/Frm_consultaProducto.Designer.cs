namespace VentasDirectas.Mantenimientos
{
    partial class Frm_consultaProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_consultaProducto));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_minimizar = new System.Windows.Forms.Button();
            this.Btn_eliminar = new System.Windows.Forms.Button();
            this.Lbl_nombre = new System.Windows.Forms.Label();
            this.Txt_buscar = new System.Windows.Forms.TextBox();
            this.Btn_buscar = new System.Windows.Forms.Button();
            this.Dgv_mostrarProducto = new System.Windows.Forms.DataGridView();
            this.codProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codProv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marcaProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineaProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.existenciaProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Btn_seleccionar = new System.Windows.Forms.Button();
            this.Btn_actualizar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_mostrarProducto)).BeginInit();
            this.SuspendLayout();
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
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "CONSULTA PRODUCTO";
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
            // Lbl_nombre
            // 
            this.Lbl_nombre.AutoSize = true;
            this.Lbl_nombre.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_nombre.Location = new System.Drawing.Point(90, 73);
            this.Lbl_nombre.Name = "Lbl_nombre";
            this.Lbl_nombre.Size = new System.Drawing.Size(72, 18);
            this.Lbl_nombre.TabIndex = 2;
            this.Lbl_nombre.Text = "Nombre:";
            // 
            // Txt_buscar
            // 
            this.Txt_buscar.Location = new System.Drawing.Point(188, 69);
            this.Txt_buscar.Name = "Txt_buscar";
            this.Txt_buscar.Size = new System.Drawing.Size(726, 22);
            this.Txt_buscar.TabIndex = 3;
            // 
            // Btn_buscar
            // 
            this.Btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_buscar.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_buscar.Location = new System.Drawing.Point(946, 66);
            this.Btn_buscar.Name = "Btn_buscar";
            this.Btn_buscar.Size = new System.Drawing.Size(92, 31);
            this.Btn_buscar.TabIndex = 4;
            this.Btn_buscar.Text = "Buscar";
            this.Btn_buscar.UseVisualStyleBackColor = true;
            this.Btn_buscar.Click += new System.EventHandler(this.Btn_buscar_Click);
            // 
            // Dgv_mostrarProducto
            // 
            this.Dgv_mostrarProducto.AllowUserToAddRows = false;
            this.Dgv_mostrarProducto.AllowUserToDeleteRows = false;
            this.Dgv_mostrarProducto.AllowUserToResizeColumns = false;
            this.Dgv_mostrarProducto.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Dgv_mostrarProducto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv_mostrarProducto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_mostrarProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_mostrarProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codProd,
            this.codProv,
            this.nomProd,
            this.marcaProd,
            this.lineaProd,
            this.imei,
            this.cantidadProd,
            this.costoProd,
            this.precioProd,
            this.existenciaProd});
            this.Dgv_mostrarProducto.Location = new System.Drawing.Point(30, 115);
            this.Dgv_mostrarProducto.Name = "Dgv_mostrarProducto";
            this.Dgv_mostrarProducto.RowHeadersVisible = false;
            this.Dgv_mostrarProducto.RowTemplate.Height = 24;
            this.Dgv_mostrarProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_mostrarProducto.Size = new System.Drawing.Size(1058, 401);
            this.Dgv_mostrarProducto.TabIndex = 5;
            // 
            // codProd
            // 
            this.codProd.HeaderText = "Código Producto";
            this.codProd.Name = "codProd";
            // 
            // codProv
            // 
            this.codProv.HeaderText = "Código Proveedor";
            this.codProv.Name = "codProv";
            // 
            // nomProd
            // 
            this.nomProd.HeaderText = "Nombre Producto";
            this.nomProd.Name = "nomProd";
            // 
            // marcaProd
            // 
            this.marcaProd.HeaderText = "Marca Producto";
            this.marcaProd.Name = "marcaProd";
            // 
            // lineaProd
            // 
            this.lineaProd.HeaderText = "Linea Producto";
            this.lineaProd.Name = "lineaProd";
            // 
            // imei
            // 
            this.imei.HeaderText = "IMEI";
            this.imei.Name = "imei";
            // 
            // cantidadProd
            // 
            this.cantidadProd.HeaderText = "Cantidad";
            this.cantidadProd.Name = "cantidadProd";
            // 
            // costoProd
            // 
            this.costoProd.HeaderText = "Costo";
            this.costoProd.Name = "costoProd";
            // 
            // precioProd
            // 
            this.precioProd.HeaderText = "Precio";
            this.precioProd.Name = "precioProd";
            // 
            // existenciaProd
            // 
            this.existenciaProd.HeaderText = "Existencias";
            this.existenciaProd.Name = "existenciaProd";
            // 
            // Btn_seleccionar
            // 
            this.Btn_seleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_seleccionar.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_seleccionar.Location = new System.Drawing.Point(894, 545);
            this.Btn_seleccionar.Name = "Btn_seleccionar";
            this.Btn_seleccionar.Size = new System.Drawing.Size(194, 31);
            this.Btn_seleccionar.TabIndex = 6;
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
            this.Btn_actualizar.TabIndex = 7;
            this.Btn_actualizar.Text = "Actualizar";
            this.Btn_actualizar.UseVisualStyleBackColor = true;
            this.Btn_actualizar.Click += new System.EventHandler(this.Btn_actualizar_Click);
            // 
            // Frm_consultaProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.Btn_actualizar);
            this.Controls.Add(this.Btn_seleccionar);
            this.Controls.Add(this.Dgv_mostrarProducto);
            this.Controls.Add(this.Btn_buscar);
            this.Controls.Add(this.Txt_buscar);
            this.Controls.Add(this.Lbl_nombre);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_consultaProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_consultaProducto";
            this.Load += new System.EventHandler(this.Frm_consultaProducto_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_mostrarProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btn_eliminar;
        private System.Windows.Forms.Button Btn_minimizar;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Lbl_nombre;
        private System.Windows.Forms.TextBox Txt_buscar;
        public System.Windows.Forms.Button Btn_buscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn codProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn codProv;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn marcaProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineaProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn imei;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn existenciaProd;
        public System.Windows.Forms.Button Btn_seleccionar;
        public System.Windows.Forms.Button Btn_actualizar;
        public System.Windows.Forms.DataGridView Dgv_mostrarProducto;
    }
}