﻿namespace VentasDirectas.Mantenimientos
{
    partial class Frm_consultaTipoPuesto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_consultaTipoPuesto));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn_minimizar = new System.Windows.Forms.Button();
            this.Btn_eliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Dgv_mostrarTipoPuesto = new System.Windows.Forms.DataGridView();
            this.codTipoPuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrePuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descPuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horarioEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horarioSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Btn_buscar = new System.Windows.Forms.Button();
            this.Txt_buscar = new System.Windows.Forms.TextBox();
            this.Lbl_nombre = new System.Windows.Forms.Label();
            this.Btn_seleccionar = new System.Windows.Forms.Button();
            this.Btn_actualizar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_mostrarTipoPuesto)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CadetBlue;
            this.panel1.Controls.Add(this.Btn_minimizar);
            this.panel1.Controls.Add(this.Btn_eliminar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 45);
            this.panel1.TabIndex = 2;
            // 
            // Btn_minimizar
            // 
            this.Btn_minimizar.FlatAppearance.BorderSize = 0;
            this.Btn_minimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_minimizar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_minimizar.Image")));
            this.Btn_minimizar.Location = new System.Drawing.Point(660, 5);
            this.Btn_minimizar.Name = "Btn_minimizar";
            this.Btn_minimizar.Size = new System.Drawing.Size(35, 35);
            this.Btn_minimizar.TabIndex = 10;
            this.Btn_minimizar.UseVisualStyleBackColor = true;
            this.Btn_minimizar.Click += new System.EventHandler(this.Btn_minimizar_Click);
            // 
            // Btn_eliminar
            // 
            this.Btn_eliminar.FlatAppearance.BorderSize = 0;
            this.Btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_eliminar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_eliminar.Image")));
            this.Btn_eliminar.Location = new System.Drawing.Point(743, 5);
            this.Btn_eliminar.Name = "Btn_eliminar";
            this.Btn_eliminar.Size = new System.Drawing.Size(35, 35);
            this.Btn_eliminar.TabIndex = 9;
            this.Btn_eliminar.UseVisualStyleBackColor = true;
            this.Btn_eliminar.Click += new System.EventHandler(this.Btn_eliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "CONSULTA TIPO DE PUESTO";
            // 
            // Dgv_mostrarTipoPuesto
            // 
            this.Dgv_mostrarTipoPuesto.AllowUserToAddRows = false;
            this.Dgv_mostrarTipoPuesto.AllowUserToDeleteRows = false;
            this.Dgv_mostrarTipoPuesto.AllowUserToResizeColumns = false;
            this.Dgv_mostrarTipoPuesto.AllowUserToResizeRows = false;
            this.Dgv_mostrarTipoPuesto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_mostrarTipoPuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_mostrarTipoPuesto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codTipoPuesto,
            this.nombrePuesto,
            this.descPuesto,
            this.horarioEntrada,
            this.horarioSalida});
            this.Dgv_mostrarTipoPuesto.Location = new System.Drawing.Point(44, 129);
            this.Dgv_mostrarTipoPuesto.Name = "Dgv_mostrarTipoPuesto";
            this.Dgv_mostrarTipoPuesto.RowHeadersVisible = false;
            this.Dgv_mostrarTipoPuesto.RowTemplate.Height = 24;
            this.Dgv_mostrarTipoPuesto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_mostrarTipoPuesto.Size = new System.Drawing.Size(708, 371);
            this.Dgv_mostrarTipoPuesto.TabIndex = 3;
            // 
            // codTipoPuesto
            // 
            this.codTipoPuesto.HeaderText = "Código tipo de puesto";
            this.codTipoPuesto.Name = "codTipoPuesto";
            // 
            // nombrePuesto
            // 
            this.nombrePuesto.HeaderText = "Nombre";
            this.nombrePuesto.Name = "nombrePuesto";
            // 
            // descPuesto
            // 
            this.descPuesto.HeaderText = "Descripción";
            this.descPuesto.Name = "descPuesto";
            // 
            // horarioEntrada
            // 
            this.horarioEntrada.HeaderText = "Horario de entrada";
            this.horarioEntrada.Name = "horarioEntrada";
            // 
            // horarioSalida
            // 
            this.horarioSalida.HeaderText = "Horario de salida";
            this.horarioSalida.Name = "horarioSalida";
            // 
            // Btn_buscar
            // 
            this.Btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_buscar.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_buscar.Location = new System.Drawing.Point(660, 75);
            this.Btn_buscar.Name = "Btn_buscar";
            this.Btn_buscar.Size = new System.Drawing.Size(92, 31);
            this.Btn_buscar.TabIndex = 8;
            this.Btn_buscar.Text = "Buscar";
            this.Btn_buscar.UseVisualStyleBackColor = true;
            this.Btn_buscar.Click += new System.EventHandler(this.Btn_buscar_Click);
            // 
            // Txt_buscar
            // 
            this.Txt_buscar.Location = new System.Drawing.Point(147, 78);
            this.Txt_buscar.Name = "Txt_buscar";
            this.Txt_buscar.Size = new System.Drawing.Size(473, 22);
            this.Txt_buscar.TabIndex = 7;
            // 
            // Lbl_nombre
            // 
            this.Lbl_nombre.AutoSize = true;
            this.Lbl_nombre.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_nombre.Location = new System.Drawing.Point(51, 82);
            this.Lbl_nombre.Name = "Lbl_nombre";
            this.Lbl_nombre.Size = new System.Drawing.Size(72, 18);
            this.Lbl_nombre.TabIndex = 6;
            this.Lbl_nombre.Text = "Nombre:";
            // 
            // Btn_seleccionar
            // 
            this.Btn_seleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_seleccionar.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_seleccionar.Location = new System.Drawing.Point(558, 528);
            this.Btn_seleccionar.Name = "Btn_seleccionar";
            this.Btn_seleccionar.Size = new System.Drawing.Size(194, 31);
            this.Btn_seleccionar.TabIndex = 9;
            this.Btn_seleccionar.Text = "Seleccionar";
            this.Btn_seleccionar.UseVisualStyleBackColor = true;
            this.Btn_seleccionar.Click += new System.EventHandler(this.Btn_seleccionar_Click);
            // 
            // Btn_actualizar
            // 
            this.Btn_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_actualizar.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_actualizar.Location = new System.Drawing.Point(44, 528);
            this.Btn_actualizar.Name = "Btn_actualizar";
            this.Btn_actualizar.Size = new System.Drawing.Size(194, 31);
            this.Btn_actualizar.TabIndex = 10;
            this.Btn_actualizar.Text = "Actualizar";
            this.Btn_actualizar.UseVisualStyleBackColor = true;
            this.Btn_actualizar.Click += new System.EventHandler(this.Btn_actualizar_Click);
            // 
            // Frm_consultaTipoPuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.Btn_actualizar);
            this.Controls.Add(this.Btn_seleccionar);
            this.Controls.Add(this.Btn_buscar);
            this.Controls.Add(this.Txt_buscar);
            this.Controls.Add(this.Lbl_nombre);
            this.Controls.Add(this.Dgv_mostrarTipoPuesto);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_consultaTipoPuesto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_consultaTipoPuesto";
            this.Load += new System.EventHandler(this.Frm_consultaTipoPuesto_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_mostrarTipoPuesto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btn_minimizar;
        private System.Windows.Forms.Button Btn_eliminar;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codTipoPuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrePuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn descPuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn horarioEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn horarioSalida;
        public System.Windows.Forms.Button Btn_buscar;
        private System.Windows.Forms.TextBox Txt_buscar;
        private System.Windows.Forms.Label Lbl_nombre;
        public System.Windows.Forms.Button Btn_seleccionar;
        public System.Windows.Forms.Button Btn_actualizar;
        public System.Windows.Forms.DataGridView Dgv_mostrarTipoPuesto;
    }
}