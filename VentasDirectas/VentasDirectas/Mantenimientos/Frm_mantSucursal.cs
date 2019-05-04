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
    public partial class Frm_mantSucursal : Form
    {
        string usuario = " ";
        DateTime fecha = DateTime.Now;
        bool presionado = false;

        string codSucursal = "";
        string nomSucursal = "";
        string dirSucursal = "";
        string telSucursal = "";

        public Frm_mantSucursal(string usuario)
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
            Txt_codSucursal.Enabled = false;
            Txt_nombreSucursal.Enabled = false;
            Txt_telSucursal.Enabled = false;
            Txt_dirSucursal.Enabled = false;
        }

        private void HabilitarCampos()
        {
            Txt_codSucursal.Enabled = true;
            Txt_nombreSucursal.Enabled = true;
            Txt_telSucursal.Enabled = true;
            Txt_dirSucursal.Enabled = true;
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
            Txt_codSucursal.Text = "";
            Txt_nombreSucursal.Text = "";
            Txt_telSucursal.Text = "";
            Txt_dirSucursal.Text = "";
        }

        private void Frm_mantSucursal_Load(object sender, EventArgs e)
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
                Frm_consultaSucursal conSucursal = new Frm_consultaSucursal();
                conSucursal.ShowDialog();

                if (conSucursal.DialogResult == DialogResult.OK)
                {
                    Txt_codSucursal.Text =
                        conSucursal.Dgv_mostrarSucursal.Rows[conSucursal.Dgv_mostrarSucursal.CurrentRow.Index].
                        Cells[0].Value.ToString();

                    Txt_nombreSucursal.Text = conSucursal.Dgv_mostrarSucursal.Rows[conSucursal.Dgv_mostrarSucursal.CurrentRow.Index].
                        Cells[1].Value.ToString();

                    Txt_dirSucursal.Text = conSucursal.Dgv_mostrarSucursal.Rows[conSucursal.Dgv_mostrarSucursal.CurrentRow.Index].
                        Cells[2].Value.ToString();

                    Txt_telSucursal.Text = conSucursal.Dgv_mostrarSucursal.Rows[conSucursal.Dgv_mostrarSucursal.CurrentRow.Index].
                        Cells[3].Value.ToString();

                    Txt_codSucursal.Focus();
                    presionado = false;
                    HabilitarBtn();
                }
            }
        }

        private void BorrarDatos()
        {
            codSucursal = Txt_codSucursal.Text;

            try
            {
                string consulta = "DELETE FROM `tbl_sucursal` WHERE `Cod_Sucursal` = " + codSucursal;
                OdbcCommand comm = new OdbcCommand(consulta, Conexion.nuevaConexion());
                comm.ExecuteNonQuery();
                MessageBox.Show("Registro eliminado correctamente");

                OdbcCommand comm1 = new OdbcCommand("{call SP_InsertarBitacora(?,?,?,?)}", Conexion.nuevaConexion());
                comm1.CommandType = CommandType.StoredProcedure;
                comm1.Parameters.Add("ope", OdbcType.Text).Value = "ELIMINACIÓN DE REGISTRO";
                comm1.Parameters.Add("usr", OdbcType.Text).Value = usuario;
                comm1.Parameters.Add("fecha", OdbcType.Text).Value = fecha.ToString("yyyy/MM/dd HH:mm:ss");
                comm1.Parameters.Add("tbl", OdbcType.Text).Value = "SUCURSALES";
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
                Txt_codSucursal.Focus();
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
            codSucursal = Txt_codSucursal.Text;
            nomSucursal = Txt_nombreSucursal.Text;
            dirSucursal = Txt_dirSucursal.Text;
            telSucursal = Txt_telSucursal.Text;

            try
            {
                string consulta = "INSERT INTO `tbl_sucursal` VALUES ('" + codSucursal + "', '" + nomSucursal + "', '" + dirSucursal + "', '" + telSucursal + "')";
                OdbcCommand comm = new OdbcCommand(consulta, Conexion.nuevaConexion());
                comm.ExecuteNonQuery();
                MessageBox.Show("Registro guardado correctamente");

                OdbcCommand comm1 = new OdbcCommand("{call SP_InsertarBitacora(?,?,?,?)}", Conexion.nuevaConexion());
                comm1.CommandType = CommandType.StoredProcedure;
                comm1.Parameters.Add("ope", OdbcType.Text).Value = "NUEVO REGISTRO";
                comm1.Parameters.Add("usr", OdbcType.Text).Value = usuario;
                comm1.Parameters.Add("fecha", OdbcType.Text).Value = fecha.ToString("yyyy/MM/dd HH:mm:ss");
                comm1.Parameters.Add("tbl", OdbcType.Text).Value = "SUCURSALES";
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
                Txt_codSucursal.Focus();
                presionado = false;
                DeshabilitarCampos();
                HabilitarBtn();
                Limpiar();
            }
        }

        private void ActualizarDatos()
        {
            codSucursal = Txt_codSucursal.Text;
            nomSucursal = Txt_nombreSucursal.Text;
            dirSucursal = Txt_dirSucursal.Text;
            telSucursal = Txt_telSucursal.Text;

            try
            {
                string consulta = "UPDATE `tbl_sucursal` SET `Cod_Sucursal` = '" + codSucursal + "',`Nombre_Sucursal` = '" + nomSucursal + "', `Direccion_Sucursal` = '" + dirSucursal + "', `Telefono_Sucursal` = " + telSucursal + " WHERE Cod_Sucursal = " + codSucursal;

                OdbcCommand comm = new OdbcCommand(consulta, Conexion.nuevaConexion());
                comm.ExecuteNonQuery();
                MessageBox.Show("Registro actualizado correctamente");

                OdbcCommand comm1 = new OdbcCommand("{call SP_InsertarBitacora(?,?,?,?)}", Conexion.nuevaConexion());
                comm1.CommandType = CommandType.StoredProcedure;
                comm1.Parameters.Add("ope", OdbcType.Text).Value = "ACTUALIZACIÓN DE REGISTRO";
                comm1.Parameters.Add("usr", OdbcType.Text).Value = usuario;
                comm1.Parameters.Add("fecha", OdbcType.Text).Value = fecha.ToString("yyyy/MM/dd HH:mm:ss");
                comm1.Parameters.Add("tbl", OdbcType.Text).Value = "SUCURSALES";
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
                Txt_codSucursal.Enabled = false;
            }
            else
            {
                ActualizarDatos();
                Txt_codSucursal.Focus();
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
