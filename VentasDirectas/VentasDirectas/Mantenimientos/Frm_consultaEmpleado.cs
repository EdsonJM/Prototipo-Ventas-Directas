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
    public partial class Frm_consultaEmpleado : Form
    {
        public Frm_consultaEmpleado()
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

        private void Btn_seleccionar_Click(object sender, EventArgs e)
        {
            if (Dgv_mostrarEmpleado.Rows.Count == 0)
            {
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void MostrarConsulta()
        {
            try
            {
                string consultaMostrar = "SELECT Cod_Emp, Cod_TipoPuesto, PrimerNombre_Emp, PrimerApellido_Emp, Dpi_Emp, Nit_Emp, Direccion_Emp, Telefono1_Emp, Fecha_de_nacimiento, Fecha_Contratacion, Email, Genero, Estado_Empleado FROM tbl_empleados;";
                OdbcCommand comm = new OdbcCommand(consultaMostrar, Conexion.nuevaConexion());
                OdbcDataReader mostrarDatos = comm.ExecuteReader();

                while (mostrarDatos.Read())
                {
                    Dgv_mostrarEmpleado.Refresh();
                    Dgv_mostrarEmpleado.Rows.Add(mostrarDatos.GetString(0), mostrarDatos.GetString(1), mostrarDatos.GetString(2),
                        mostrarDatos.GetString(3), mostrarDatos.GetString(4), mostrarDatos.GetString(5), mostrarDatos.GetString(6)
                        , mostrarDatos.GetString(7), mostrarDatos.GetString(8), mostrarDatos.GetString(9), mostrarDatos.GetString(10)
                        , mostrarDatos.GetString(11), mostrarDatos.GetString(12));
                }

            }
            catch (Exception err)
            {
                Console.Write(err.Message);
            }
        }

        private void Frm_consultaEmpleado_Load(object sender, EventArgs e)
        {
            MostrarConsulta();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Dgv_mostrarEmpleado.Rows.Clear();
            MostrarConsulta();
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_buscar.Text.Trim()) == false)
            {
                Dgv_mostrarEmpleado.Rows.Clear();
                try
                {
                    string consultaMostrar = "SELECT Cod_Emp, Cod_TipoPuesto, PrimerNombre_Emp, PrimerApellido_Emp, Dpi_Emp, Nit_Emp, Direccion_Emp, Telefono1_Emp, Fecha_de_nacimiento, Fecha_Contratacion, Email, Genero, Estado_Empleado FROM tbl_empleados WHERE PrimerNombre_Emp LIKE ('%" + Txt_buscar.Text.Trim() + "%');";
                    OdbcCommand comm = new OdbcCommand(consultaMostrar, Conexion.nuevaConexion());
                    OdbcDataReader mostrarDatos = comm.ExecuteReader();

                    while (mostrarDatos.Read())
                    {
                        Dgv_mostrarEmpleado.Refresh();
                        Dgv_mostrarEmpleado.Rows.Add(mostrarDatos.GetString(0), mostrarDatos.GetString(1), mostrarDatos.GetString(2),
                            mostrarDatos.GetString(3), mostrarDatos.GetString(4), mostrarDatos.GetString(5), mostrarDatos.GetString(6)
                            , mostrarDatos.GetString(7), mostrarDatos.GetString(8), mostrarDatos.GetString(9), mostrarDatos.GetString(10)
                            , mostrarDatos.GetString(11), mostrarDatos.GetString(12));
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine("ERROR:" + err.Message);
                }
            }
        }
    }
}
