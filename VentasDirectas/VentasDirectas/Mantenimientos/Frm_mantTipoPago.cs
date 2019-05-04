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
    public partial class Frm_mantTipoPago : Form
    {
        string usuario = " ";
        DateTime fecha = DateTime.Now;
        bool presionado = false;

        string codPago = "";
        string nomPago = "";

        public Frm_mantTipoPago(string usuario)
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
            Txt_codPago.Enabled = false;
            Txt_nombrePago.Enabled = false;
        }

        private void HabilitarCampos()
        {
            Txt_codPago.Enabled = true;
            Txt_nombrePago.Enabled = true;
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
            Txt_codPago.Text = "";
            Txt_nombrePago.Text = "";
        }

        private void Frm_mantTipoPago_Load(object sender, EventArgs e)
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
                Frm_consultaTipoPago conTipoPago = new Frm_consultaTipoPago();
                conTipoPago.ShowDialog();

                if (conTipoPago.DialogResult == DialogResult.OK)
                {
                    Txt_codPago.Text =
                        conTipoPago.Dgv_mostrarTipoPago.Rows[conTipoPago.Dgv_mostrarTipoPago.CurrentRow.Index].
                        Cells[0].Value.ToString();

                    Txt_nombrePago.Text = conTipoPago.Dgv_mostrarTipoPago.Rows[conTipoPago.Dgv_mostrarTipoPago.CurrentRow.Index].
                        Cells[1].Value.ToString();

                    Txt_codPago.Focus();
                    presionado = false;
                    HabilitarBtn();
                }
            }
        }

        private void BorrarDatos()
        {
            codPago = Txt_codPago.Text;

            try
            {
                string consulta = "DELETE FROM `tbl_tipo_pago` WHERE `Cod_Pago` = " + codPago;
                OdbcCommand comm = new OdbcCommand(consulta, Conexion.nuevaConexion());
                comm.ExecuteNonQuery();
                MessageBox.Show("Registro eliminado correctamente");

                OdbcCommand comm1 = new OdbcCommand("{call SP_InsertarBitacora(?,?,?,?)}", Conexion.nuevaConexion());
                comm1.CommandType = CommandType.StoredProcedure;
                comm1.Parameters.Add("ope", OdbcType.Text).Value = "ELIMINACIÓN DE REGISTRO";
                comm1.Parameters.Add("usr", OdbcType.Text).Value = usuario;
                comm1.Parameters.Add("fecha", OdbcType.Text).Value = fecha.ToString("yyyy/MM/dd HH:mm:ss");
                comm1.Parameters.Add("tbl", OdbcType.Text).Value = "TIPO DE PAGO";
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
                Txt_codPago.Focus();
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
        
        private void GuardarDatos()
        {
            codPago = Txt_codPago.Text;
            nomPago = Txt_nombrePago.Text;

            try
            {
                string consulta = "INSERT INTO `tbl_tipo_pago` VALUES ('" + codPago + "', '" + nomPago + "')";
                OdbcCommand comm = new OdbcCommand(consulta, Conexion.nuevaConexion());
                comm.ExecuteNonQuery();
                MessageBox.Show("Registro guardado correctamente");

                OdbcCommand comm1 = new OdbcCommand("{call SP_InsertarBitacora(?,?,?,?)}", Conexion.nuevaConexion());
                comm1.CommandType = CommandType.StoredProcedure;
                comm1.Parameters.Add("ope", OdbcType.Text).Value = "NUEVO REGISTRO";
                comm1.Parameters.Add("usr", OdbcType.Text).Value = usuario;
                comm1.Parameters.Add("fecha", OdbcType.Text).Value = fecha.ToString("yyyy/MM/dd HH:mm:ss");
                comm1.Parameters.Add("tbl", OdbcType.Text).Value = "TIPO DE PAGO";
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
                Txt_codPago.Focus();
                presionado = false;
                DeshabilitarCampos();
                HabilitarBtn();
                Limpiar();
            }
        }

        private void ActualizarDatos()
        {
            try
            {
                codPago = Txt_codPago.Text;
                nomPago = Txt_nombrePago.Text;

                string consulta = "UPDATE `tbl_tipo_pago` SET `Cod_Pago` = '" + codPago + "',`Nombre_Tipo_Pago` = '" + nomPago + "' WHERE Cod_Pago = " + codPago;

                OdbcCommand comm = new OdbcCommand(consulta, Conexion.nuevaConexion());
                comm.ExecuteNonQuery();
                MessageBox.Show("Registro actualizado correctamente");

                OdbcCommand comm1 = new OdbcCommand("{call SP_InsertarBitacora(?,?,?,?)}", Conexion.nuevaConexion());
                comm1.CommandType = CommandType.StoredProcedure;
                comm1.Parameters.Add("ope", OdbcType.Text).Value = "ACTUALIZACIÓN DE REGISTRO";
                comm1.Parameters.Add("usr", OdbcType.Text).Value = usuario;
                comm1.Parameters.Add("fecha", OdbcType.Text).Value = fecha.ToString("yyyy/MM/dd HH:mm:ss");
                comm1.Parameters.Add("tbl", OdbcType.Text).Value = "TIPO DE PAGO";
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
                Txt_codPago.Enabled = false;
            }
            else
            {
                ActualizarDatos();
                Txt_codPago.Focus();
                presionado = false;
                DeshabilitarCampos();
                HabilitarBtn();
                Limpiar();
            }
        }

        private void Btn_ingresar_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
        }
    }
}
