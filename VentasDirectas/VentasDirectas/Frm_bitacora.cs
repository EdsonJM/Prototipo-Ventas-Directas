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
    public partial class Frm_bitacora : Form
    {
        public Frm_bitacora()
        {
            InitializeComponent();
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MostrarConsulta()
        {
            try
            {
                string consultaMostrar = "SELECT * FROM tbl_bitacora;";
                OdbcCommand comm = new OdbcCommand(consultaMostrar, Conexion.nuevaConexion());
                OdbcDataReader mostrarDatos = comm.ExecuteReader();

                while (mostrarDatos.Read())
                {
                    Dgv_mostrarBitacora.Refresh();
                    Dgv_mostrarBitacora.Rows.Add(mostrarDatos.GetString(0), mostrarDatos.GetString(1), mostrarDatos.GetString(2),
                        mostrarDatos.GetString(3), mostrarDatos.GetString(4));
                }

            }
            catch (Exception err)
            {
                Console.Write(err.Message);
            }
        }

        private void Frm_bitacora_Load(object sender, EventArgs e)
        {
            MostrarConsulta();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Txt_buscar.Text.Trim())==false)
            {
                Dgv_mostrarBitacora.Rows.Clear();
                try
                {
                    string consultaMostrar = "SELECT * FROM tbl_bitacora WHERE usuario LIKE ('%"+Txt_buscar.Text.Trim()+"%');";
                    OdbcCommand comm = new OdbcCommand(consultaMostrar, Conexion.nuevaConexion());
                    OdbcDataReader mostrarDatos = comm.ExecuteReader();

                    while (mostrarDatos.Read())
                    {
                        Dgv_mostrarBitacora.Refresh();
                        Dgv_mostrarBitacora.Rows.Add(mostrarDatos.GetString(0), mostrarDatos.GetString(1), mostrarDatos.GetString(2),
                            mostrarDatos.GetString(3), mostrarDatos.GetString(4));
                    }
                }
                catch(Exception err)
                {
                    Console.WriteLine("ERROR:"+err.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dgv_mostrarBitacora.Rows.Clear();
            MostrarConsulta();
        }
    }
}
