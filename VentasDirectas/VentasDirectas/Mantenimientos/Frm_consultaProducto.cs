using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace VentasDirectas.Mantenimientos
{
    public partial class Frm_consultaProducto : Form
    {
        public Frm_consultaProducto()
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
                string consultaMostrar = "SELECT * FROM tbl_producto;";
                OdbcCommand comm = new OdbcCommand(consultaMostrar, Conexion.nuevaConexion());
                OdbcDataReader mostrarDatos = comm.ExecuteReader();

                while (mostrarDatos.Read())
                {
                    Dgv_mostrarProducto.Refresh();
                    Dgv_mostrarProducto.Rows.Add(mostrarDatos.GetString(0), mostrarDatos.GetString(1), mostrarDatos.GetString(2),
                        mostrarDatos.GetString(3), mostrarDatos.GetString(4), mostrarDatos.GetString(5), mostrarDatos.GetString(6)
                        , mostrarDatos.GetString(7), mostrarDatos.GetString(8), mostrarDatos.GetString(9));
                }

            }
            catch (Exception err)
            {
                Console.Write(err.Message);
            }
        }

        private void Frm_consultaProducto_Load(object sender, EventArgs e)
        {
            MostrarConsulta();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Dgv_mostrarProducto.Rows.Clear();
            MostrarConsulta();
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_buscar.Text.Trim()) == false)
            {
                Dgv_mostrarProducto.Rows.Clear();
                try
                {
                    string consultaMostrar = "SELECT * FROM tbl_producto WHERE Nombre_Producto LIKE ('%" + Txt_buscar.Text.Trim() + "%');";
                    OdbcCommand comm = new OdbcCommand(consultaMostrar, Conexion.nuevaConexion());
                    OdbcDataReader mostrarDatos = comm.ExecuteReader();

                    while (mostrarDatos.Read())
                    {
                        Dgv_mostrarProducto.Refresh();
                        Dgv_mostrarProducto.Rows.Add(mostrarDatos.GetString(0), mostrarDatos.GetString(1), mostrarDatos.GetString(2),
                            mostrarDatos.GetString(3), mostrarDatos.GetString(4), mostrarDatos.GetString(5), mostrarDatos.GetString(6)
                            , mostrarDatos.GetString(7), mostrarDatos.GetString(8), mostrarDatos.GetString(9));
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine("ERROR:" + err.Message);
                }
            }
        }

        private void Btn_seleccionar_Click(object sender, EventArgs e)
        {
            if(Dgv_mostrarProducto.Rows.Count == 0)
            {
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
