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
    public partial class Frm_mantTipoPuesto : Form
    {
        string usuario = " ";
        DateTime fecha = DateTime.Now;
        bool presionado = false;

        string codPuesto = "";
        string nomPuesto = "";
        string descPuesto = "";
        string horEntrada = "";
        string horSalida = "";

        public Frm_mantTipoPuesto(string usuario)
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
            Txt_codPuesto.Enabled = false;
            Txt_nombrePuesto.Enabled = false;
            Txt_descPuesto.Enabled = false;
            Dtp_horEntrada.Enabled = false;
            Dtp_horSalida.Enabled = false;
        }

        private void HabilitarCampos()
        {
            Txt_codPuesto.Enabled = true;
            Txt_nombrePuesto.Enabled = true;
            Txt_descPuesto.Enabled = true;
            Dtp_horEntrada.Enabled = true;
            Dtp_horSalida.Enabled = true;
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
            Txt_codPuesto.Text = " ";
            Txt_nombrePuesto.Text = " ";
            Txt_descPuesto.Text = " ";
        }

        private void Frm_mantTipoPuesto_Load(object sender, EventArgs e)
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
                Frm_consultaTipoPuesto conTipoPuesto = new Frm_consultaTipoPuesto();
                conTipoPuesto.ShowDialog();

                if (conTipoPuesto.DialogResult == DialogResult.OK)
                {
                    Txt_codPuesto.Text =
                        conTipoPuesto.Dgv_mostrarTipoPuesto.Rows[conTipoPuesto.Dgv_mostrarTipoPuesto.CurrentRow.Index].
                        Cells[0].Value.ToString();

                    Txt_nombrePuesto.Text = conTipoPuesto.Dgv_mostrarTipoPuesto.Rows[conTipoPuesto.Dgv_mostrarTipoPuesto.CurrentRow.Index].
                        Cells[1].Value.ToString();

                    Txt_descPuesto.Text = conTipoPuesto.Dgv_mostrarTipoPuesto.Rows[conTipoPuesto.Dgv_mostrarTipoPuesto.CurrentRow.Index].
                        Cells[2].Value.ToString();

                    Dtp_horEntrada.Text = conTipoPuesto.Dgv_mostrarTipoPuesto.Rows[conTipoPuesto.Dgv_mostrarTipoPuesto.CurrentRow.Index].
                        Cells[3].Value.ToString();

                    Dtp_horSalida.Text = conTipoPuesto.Dgv_mostrarTipoPuesto.Rows[conTipoPuesto.Dgv_mostrarTipoPuesto.CurrentRow.Index].
                        Cells[4].Value.ToString();

                    Txt_codPuesto.Focus();
                    presionado = false;
                    HabilitarBtn();
                }
            }
        }
        
        private void BorrarDatos()
        {
            codPuesto = Txt_codPuesto.Text;

            try
            {
                string consulta = "DELETE FROM `tbl_tipopuesto` WHERE `Cod_TipoPuesto` = " + codPuesto;
                OdbcCommand comm = new OdbcCommand(consulta, Conexion.nuevaConexion());
                comm.ExecuteNonQuery();
                MessageBox.Show("Registro eliminado correctamente");

                OdbcCommand comm1 = new OdbcCommand("{call SP_InsertarBitacora(?,?,?,?)}", Conexion.nuevaConexion());
                comm1.CommandType = CommandType.StoredProcedure;
                comm1.Parameters.Add("ope", OdbcType.Text).Value = "ELIMINACIÓN DE REGISTRO";
                comm1.Parameters.Add("usr", OdbcType.Text).Value = usuario;
                comm1.Parameters.Add("fecha", OdbcType.Text).Value = fecha.ToString("yyyy/MM/dd HH:mm:ss");
                comm1.Parameters.Add("tbl", OdbcType.Text).Value = "TIPO PUESTO";
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
                Txt_codPuesto.Focus();
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
            codPuesto = Txt_codPuesto.Text;
            nomPuesto = Txt_nombrePuesto.Text;
            descPuesto = Txt_descPuesto.Text;
            horEntrada = Dtp_horEntrada.Text;
            horSalida = Dtp_horSalida.Text;

            try
            {
                string consulta = "INSERT INTO `tbl_tipopuesto` VALUES ('" + codPuesto + "', '" + nomPuesto + "', '" + descPuesto + "', '" + horEntrada + "', '" + horSalida + "')";
                OdbcCommand comm = new OdbcCommand(consulta, Conexion.nuevaConexion());
                comm.ExecuteNonQuery();
                MessageBox.Show("Registro guardado correctamente");

                OdbcCommand comm1 = new OdbcCommand("{call SP_InsertarBitacora(?,?,?,?)}", Conexion.nuevaConexion());
                comm1.CommandType = CommandType.StoredProcedure;
                comm1.Parameters.Add("ope", OdbcType.Text).Value = "NUEVO REGISTRO";
                comm1.Parameters.Add("usr", OdbcType.Text).Value = usuario;
                comm1.Parameters.Add("fecha", OdbcType.Text).Value = fecha.ToString("yyyy/MM/dd HH:mm:ss");
                comm1.Parameters.Add("tbl", OdbcType.Text).Value = "TIPO PUESTO";
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
                Txt_codPuesto.Focus();
                presionado = false;
                DeshabilitarCampos();
                HabilitarBtn();
                Limpiar();
            }
        }

        private void ActualizarDatos()
        {
            codPuesto = Txt_codPuesto.Text;
            nomPuesto = Txt_nombrePuesto.Text;
            descPuesto = Txt_descPuesto.Text;
            horEntrada = Dtp_horEntrada.Text;
            horSalida = Dtp_horSalida.Text;

            try
            {
                string consulta = "UPDATE `tbl_tipopuesto` SET `Cod_TipoPuesto` = '" + codPuesto + "',`Nombre_Puesto` = '" + nomPuesto + "', `Descripcion_Puesto` = '" + descPuesto + "', `Horario_Entrada` = " + horEntrada + ", `Horario_Salida` = " + horSalida + " WHERE Cod_TipoPuesto = " + codPuesto;

                OdbcCommand comm = new OdbcCommand(consulta, Conexion.nuevaConexion());
                comm.ExecuteNonQuery();
                MessageBox.Show("Registro actualizado correctamente");

                OdbcCommand comm1 = new OdbcCommand("{call SP_InsertarBitacora(?,?,?,?)}", Conexion.nuevaConexion());
                comm1.CommandType = CommandType.StoredProcedure;
                comm1.Parameters.Add("ope", OdbcType.Text).Value = "ACTUALIZACIÓN DE REGISTRO";
                comm1.Parameters.Add("usr", OdbcType.Text).Value = usuario;
                comm1.Parameters.Add("fecha", OdbcType.Text).Value = fecha.ToString("yyyy/MM/dd HH:mm:ss");
                comm1.Parameters.Add("tbl", OdbcType.Text).Value = "TIPO PUESTO";
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
                Txt_codPuesto.Enabled = false;
            }
            else
            {
                ActualizarDatos();
                Txt_codPuesto.Focus();
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
