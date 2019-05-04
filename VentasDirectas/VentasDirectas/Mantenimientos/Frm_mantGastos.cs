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
    public partial class Frm_mantGastos : Form
    {
        string usuario = " ";
        DateTime fecha = DateTime.Now;
        bool presionado = false;

        string codGasto = "";
        string nomGasto = "";
        string fechaGasto = "";
        string totalGasto = "";

        public Frm_mantGastos(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void DeshabilitarCampos()
        {
            Txt_codGasto.Enabled = false;
            Txt_nombreGasto.Enabled = false;
            Dtp_fechaGasto.Enabled = false;
            Txt_totalGasto.Enabled = false;
        }

        private void HabilitarCampos()
        {
            Txt_codGasto.Enabled = true;
            Txt_nombreGasto.Enabled = true;
            Dtp_fechaGasto.Enabled = true;
            Txt_totalGasto.Enabled = true;
        }

        private void DeshabilitarBtn()
        {
            Btn_ingresar.Enabled = false;
            Btn_editar.Enabled = false;
            Btn_guardar.Enabled = false;
            Btn_borrar.Enabled = false;
            Btn_consultar.Enabled = false;
        }

        private void HabilitarBtn()
        {
            Btn_ingresar.Enabled = true;
            Btn_editar.Enabled = true;
            Btn_guardar.Enabled = true;
            Btn_borrar.Enabled = true;
            Btn_consultar.Enabled = true;
        }

        private void Limpiar()
        {
            Txt_codGasto.Text = " ";
            Txt_nombreGasto.Text = " ";
            Txt_totalGasto.Text = " ";
        }

        private void Frm_mantGastos_Load(object sender, EventArgs e)
        {
            DeshabilitarCampos();
        }

        private void Btn_consultar_Click(object sender, EventArgs e)
        {
            if (presionado == false)
            {
                DeshabilitarBtn();
                Btn_consultar.Enabled = true;
                presionado = true;
            }
            else
            {
                Frm_consultaGasto conGasto = new Frm_consultaGasto();
                conGasto.ShowDialog();

                if (conGasto.DialogResult == DialogResult.OK)
                {
                    Txt_codGasto.Text =
                        conGasto.Dgv_mostrarGastos.Rows[conGasto.Dgv_mostrarGastos.CurrentRow.Index].
                        Cells[0].Value.ToString();

                    Txt_nombreGasto.Text = conGasto.Dgv_mostrarGastos.Rows[conGasto.Dgv_mostrarGastos.CurrentRow.Index].
                        Cells[1].Value.ToString();

                    Dtp_fechaGasto.Text = conGasto.Dgv_mostrarGastos.Rows[conGasto.Dgv_mostrarGastos.CurrentRow.Index].
                        Cells[2].Value.ToString();

                    Txt_totalGasto.Text = conGasto.Dgv_mostrarGastos.Rows[conGasto.Dgv_mostrarGastos.CurrentRow.Index].
                        Cells[3].Value.ToString();

                    Txt_codGasto.Focus();
                    presionado = false;
                    HabilitarBtn();
                }
            }
        }

        private void Btn_ingresar_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
        }

        private void ActualizarDatos()
        {
            codGasto = Txt_codGasto.Text;
            nomGasto = Txt_nombreGasto.Text;
            fechaGasto = Dtp_fechaGasto.Text;
            totalGasto = Txt_totalGasto.Text;
            try
            {
                string consulta = "UPDATE `tbl_catalogo_gastos` SET `Cod_gasto` = '" + codGasto + "',`Nombre_Gasto` = '" + nomGasto + "', `Fecha_Gasto` = '" + fechaGasto + "', `Total_Gasto` = " + totalGasto + " WHERE Cod_Gasto = " + codGasto;

                OdbcCommand comm = new OdbcCommand(consulta, Conexion.nuevaConexion());
                comm.ExecuteNonQuery();
                MessageBox.Show("Registro actualizado correctamente");

                OdbcCommand comm1 = new OdbcCommand("{call SP_InsertarBitacora(?,?,?,?)}", Conexion.nuevaConexion());
                comm1.CommandType = CommandType.StoredProcedure;
                comm1.Parameters.Add("ope", OdbcType.Text).Value = "ACTUALIZACIÓN DE REGISTRO";
                comm1.Parameters.Add("usr", OdbcType.Text).Value = usuario;
                comm1.Parameters.Add("fecha", OdbcType.Text).Value = fecha.ToString("yyyy/MM/dd HH:mm:ss");
                comm1.Parameters.Add("tbl", OdbcType.Text).Value = "GASTOS";
                comm1.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                MessageBox.Show("Error al intentar actualizar el registro");
            }
        }

        private void Btn_editar_Click(object sender, EventArgs e)
        {
            if (presionado == false)
            {
                DeshabilitarBtn();
                Btn_editar.Enabled = true;
                presionado = true;
                Txt_codGasto.Enabled = false;
            }
            else
            {
                ActualizarDatos();
                Txt_codGasto.Focus();
                presionado = false;
                DeshabilitarCampos();
                HabilitarBtn();
                Limpiar();
            }
        }
        
        private void GuardarDatos()
        {
            codGasto = Txt_codGasto.Text;
            nomGasto = Txt_nombreGasto.Text;
            fechaGasto = Dtp_fechaGasto.Text;
            totalGasto = Txt_totalGasto.Text;

            try
            {
                string consulta = "INSERT INTO `tbl_catalogo_gastos` VALUES ('" + codGasto + "', '" + nomGasto + "', '" + fechaGasto + "', '" + totalGasto + "')";
                OdbcCommand comm = new OdbcCommand(consulta, Conexion.nuevaConexion());
                comm.ExecuteNonQuery();
                MessageBox.Show("Registro guardado correctamente");

                OdbcCommand comm1 = new OdbcCommand("{call SP_InsertarBitacora(?,?,?,?)}", Conexion.nuevaConexion());
                comm1.CommandType = CommandType.StoredProcedure;
                comm1.Parameters.Add("ope", OdbcType.Text).Value = "NUEVO REGISTRO";
                comm1.Parameters.Add("usr", OdbcType.Text).Value = usuario;
                comm1.Parameters.Add("fecha", OdbcType.Text).Value = fecha.ToString("yyyy/MM/dd HH:mm:ss");
                comm1.Parameters.Add("tbl", OdbcType.Text).Value = "GASTOS";
                comm1.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                MessageBox.Show("Error al intentar guardar el registro");
            }
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (presionado == false)
            {
                DeshabilitarBtn();
                Btn_guardar.Enabled = true;
                presionado = true;
            }
            else
            {
                GuardarDatos();
                Txt_codGasto.Focus();
                presionado = false;
                DeshabilitarCampos();
                HabilitarBtn();
                Limpiar();
            }
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            presionado = false;
            HabilitarBtn();
        }

        private void BorrarDatos()
        {
            codGasto = Txt_codGasto.Text;

            try
            {
                string consulta = "DELETE FROM `tbl_catalogo_gastos` WHERE `Cod_Gasto` = " + codGasto;
                OdbcCommand comm = new OdbcCommand(consulta, Conexion.nuevaConexion());
                comm.ExecuteNonQuery();
                MessageBox.Show("Registro eliminado correctamente");

                OdbcCommand comm1 = new OdbcCommand("{call SP_InsertarBitacora(?,?,?,?)}", Conexion.nuevaConexion());
                comm1.CommandType = CommandType.StoredProcedure;
                comm1.Parameters.Add("ope", OdbcType.Text).Value = "ELIMINACIÓN DE REGISTRO";
                comm1.Parameters.Add("usr", OdbcType.Text).Value = usuario;
                comm1.Parameters.Add("fecha", OdbcType.Text).Value = fecha.ToString("yyyy/MM/dd HH:mm:ss");
                comm1.Parameters.Add("tbl", OdbcType.Text).Value = "GASTOS";
                comm1.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                MessageBox.Show("Error al intentar borrar el registro");
            }
        }

        private void Btn_borrar_Click(object sender, EventArgs e)
        {
            if (presionado == false)
            {
                DeshabilitarBtn();
                Btn_borrar.Enabled = true;
                presionado = true;
            }
            else
            {
                BorrarDatos();
                Txt_codGasto.Focus();
                presionado = false;
                DeshabilitarCampos();
                HabilitarBtn();
                Limpiar();
            }
        }
    }
}
