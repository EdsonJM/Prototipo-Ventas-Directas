﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace VentasDirectas
{
    public partial class Frm_mdi : Form
    {
        string usuario;
        string tipoUsuario;
        DateTime fecha = DateTime.Now;

        public Frm_mdi(string usuario, string tipoUsuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.tipoUsuario = tipoUsuario;
        }

        private void Frm_mdi_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "BIENVENIDO: " + usuario;

            MdiClient ctlMDI; //control del color del MDI
            // Loop through all of the form's controls looking
            // for the control of type MdiClient.
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    // Attempt to cast the control to type MdiClient.
                    ctlMDI = (MdiClient)ctl;

                    // Set the BackColor of the MdiClient control.
                    ctlMDI.BackColor = this.BackColor;
                }
                catch (InvalidCastException exc)
                {
                    // Catch and ignore the error if casting failed.
                }
            }
        }

        private void Frm_mdi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_login logeo = new Frm_login();
            this.Hide();
            logeo.Show();

            try
            {
                OdbcCommand comm = new OdbcCommand("{call SP_InsertarBitacora(?,?,?,?)}", Conexion.nuevaConexion());
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("ope", OdbcType.Text).Value = "CIERRE DE SESIÓN";
                comm.Parameters.Add("usr", OdbcType.Text).Value = usuario;
                comm.Parameters.Add("fecha", OdbcType.Text).Value = fecha.ToString("yyyy/MM/dd HH:mm:ss");
                comm.Parameters.Add("tbl", OdbcType.Text).Value = "-----";
                comm.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

        }

        bool ventanaBitacora = false;
        Frm_bitacora bitacora = new Frm_bitacora();
        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_bitacora);
            if (ventanaBitacora == false || frmC == null)
            {
                if (frmC == null)
                {
                    bitacora = new Frm_bitacora();
                }

                bitacora.MdiParent = this;
                bitacora.Show();
                Application.DoEvents();
                ventanaBitacora = true;
            }
            else
            {
                bitacora.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }
    }
}
