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
    public partial class Frm_mantCuentaContable : Form
    {
        string usuario = " ";
        DateTime fecha = DateTime.Now;
        bool presionado = false;

        string codigoCuenta = " ";
        string nomCuenta = " ";
        string descCuenta = " ";
        string tipoCuenta = " ";
        string saldoCuenta = " ";

        public Frm_mantCuentaContable(string usuario)
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
            Txt_codCuenta.Enabled = false;
            Txt_nombreCuenta.Enabled = false;
            Txt_descCuenta.Enabled = false;
            Txt_tipoCuenta.Enabled = false;
            Txt_saldoCuenta.Enabled = false;
        }

        private void DeshabilitarBtn()
        {
            Btn_ingresar.Enabled = false;
            Btn_editar.Enabled = false;
            Btn_guardar.Enabled = false;
            Btn_borrar.Enabled = false;
            Btn_consultar.Enabled = false;
        }

        private void HabilitarCampos()
        {
            Txt_codCuenta.Enabled = true;
            Txt_nombreCuenta.Enabled = true;
            Txt_descCuenta.Enabled = true;
            Txt_tipoCuenta.Enabled = true;
            Txt_saldoCuenta.Enabled = true;
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
            Txt_codCuenta.Text = "";
            Txt_nombreCuenta.Text = "";
            Txt_descCuenta.Text = "";
            Txt_tipoCuenta.Text = "";
            Txt_saldoCuenta.Text = "";
        }

        private void Frm_mantCuentaContable_Load(object sender, EventArgs e)
        {
            DeshabilitarCampos();
        }

        private void Btn_ingresar_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
        }

        private void Btn_consultar_Click(object sender, EventArgs e)
        {
            if(presionado == false)
            {
                DeshabilitarBtn();
                Btn_consultar.Enabled = true;
                presionado = true;
            }else
            {
                Frm_consultaCuentaContable conCuentaContable = new Frm_consultaCuentaContable();
                conCuentaContable.ShowDialog();

                if(conCuentaContable.DialogResult == DialogResult.OK)
                {
                    Txt_codCuenta.Text = 
                        conCuentaContable.Dgv_mostrarCuenta.Rows[conCuentaContable.Dgv_mostrarCuenta.CurrentRow.Index].
                        Cells[0].Value.ToString();

                    Txt_nombreCuenta.Text = conCuentaContable.Dgv_mostrarCuenta.Rows[conCuentaContable.Dgv_mostrarCuenta.CurrentRow.Index].
                        Cells[1].Value.ToString();

                    Txt_descCuenta.Text = conCuentaContable.Dgv_mostrarCuenta.Rows[conCuentaContable.Dgv_mostrarCuenta.CurrentRow.Index].
                        Cells[2].Value.ToString();

                    Txt_tipoCuenta.Text = conCuentaContable.Dgv_mostrarCuenta.Rows[conCuentaContable.Dgv_mostrarCuenta.CurrentRow.Index].
                        Cells[3].Value.ToString();

                    Txt_saldoCuenta.Text = conCuentaContable.Dgv_mostrarCuenta.Rows[conCuentaContable.Dgv_mostrarCuenta.CurrentRow.Index].
                        Cells[4].Value.ToString();

                    Txt_codCuenta.Focus();
                    presionado = false;
                    HabilitarBtn();
                }
            }
        }

        private void ActualizarDatos()
        {
            codigoCuenta = Txt_codCuenta.Text;
            nomCuenta = Txt_nombreCuenta.Text;
            descCuenta = Txt_descCuenta.Text;
            tipoCuenta = Txt_tipoCuenta.Text;
            saldoCuenta = Txt_saldoCuenta.Text;

            try
            {
                string consulta = "UPDATE `catalogo_cuentas_contables` SET `Cod_Contable` = '" + codigoCuenta + "',`Nombre_CuentaContable` = '" + nomCuenta + "', `Descripcion` = '" + descCuenta + "', `Tipo_Activo-Pasivo` = " + tipoCuenta + ", `Saldo` = " + saldoCuenta +" WHERE Cod_Contable = " + codigoCuenta;

                OdbcCommand comm = new OdbcCommand(consulta, Conexion.nuevaConexion());
                comm.ExecuteNonQuery();
                MessageBox.Show("Registro actualizado correctamente");
            }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
                MessageBox.Show("Error al intentar actualizar el registro");
            }

            try
            {
                OdbcCommand comm = new OdbcCommand("{call SP_InsertarBitacora(?,?,?,?)}", Conexion.nuevaConexion());
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("ope", OdbcType.Text).Value = "ACTUALIZACIÓN DE REGISTRO";
                comm.Parameters.Add("usr", OdbcType.Text).Value = usuario;
                comm.Parameters.Add("fecha", OdbcType.Text).Value = fecha.ToString("yyyy/MM/dd HH:mm:ss");
                comm.Parameters.Add("tbl", OdbcType.Text).Value = "CUENTAS CONTABLES";
                comm.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private void Btn_editar_Click(object sender, EventArgs e)
        {
            if(presionado == false)
            {
                DeshabilitarBtn();
                Btn_editar.Enabled = true;
                presionado = true;
                Txt_codCuenta.Enabled = false;
            }
            else
            {
                ActualizarDatos();
                Txt_codCuenta.Focus();
                presionado = false;
                DeshabilitarCampos();
                HabilitarBtn();
                Limpiar();
            }
        }

        private void GuardarDatos()
        {
            codigoCuenta = Txt_codCuenta.Text;
            nomCuenta = Txt_nombreCuenta.Text;
            descCuenta = Txt_descCuenta.Text;
            tipoCuenta = Txt_tipoCuenta.Text;
            saldoCuenta = Txt_saldoCuenta.Text;

            try
            {
                string consulta = "INSERT INTO `catalogo_cuentas_contables` (`Cod_Contable`,`Nombre_CuentaContable`,`Descripcion`,`Tipo_Activo-Pasivo`,`Saldo`) VALUES ('" + codigoCuenta + "', '" + nomCuenta + "', '" + descCuenta + "', '" + tipoCuenta + "', '" + saldoCuenta + "')";
                OdbcCommand comm = new OdbcCommand(consulta, Conexion.nuevaConexion());
                comm.ExecuteNonQuery();
                MessageBox.Show("Registro guardado correctamente");
            }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
                MessageBox.Show("Error al intentar guardar el registro");
            }

            try
            {
                OdbcCommand comm = new OdbcCommand("{call SP_InsertarBitacora(?,?,?,?)}", Conexion.nuevaConexion());
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("ope", OdbcType.Text).Value = "NUEVO REGISTRO";
                comm.Parameters.Add("usr", OdbcType.Text).Value = usuario;
                comm.Parameters.Add("fecha", OdbcType.Text).Value = fecha.ToString("yyyy/MM/dd HH:mm:ss");
                comm.Parameters.Add("tbl", OdbcType.Text).Value = "CUENTAS CONTABLES";
                comm.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if(presionado == false)
            {
                DeshabilitarBtn();
                Btn_guardar.Enabled = true;
                presionado = true;
            }
            else
            {
                GuardarDatos();
                Txt_codCuenta.Focus();
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
            codigoCuenta = Txt_codCuenta.Text;

            try
            {
                string consulta = "DELETE FROM `catalogo_cuentas_contables` WHERE `Cod_Contable` = " + codigoCuenta;
                OdbcCommand comm = new OdbcCommand(consulta, Conexion.nuevaConexion());
                comm.ExecuteNonQuery();
                MessageBox.Show("Registro eliminado correctamente");
            }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
                MessageBox.Show("Error al intentar borrar el registro");
            }

            try
            {
                OdbcCommand comm = new OdbcCommand("{call SP_InsertarBitacora(?,?,?,?)}", Conexion.nuevaConexion());
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("ope", OdbcType.Text).Value = "ELIMINACIÓN DE REGISTRO";
                comm.Parameters.Add("usr", OdbcType.Text).Value = usuario;
                comm.Parameters.Add("fecha", OdbcType.Text).Value = fecha.ToString("yyyy/MM/dd HH:mm:ss");
                comm.Parameters.Add("tbl", OdbcType.Text).Value = "CUENTAS CONTABLES";
                comm.ExecuteNonQuery();
            }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private void Btn_borrar_Click(object sender, EventArgs e)
        {
            if(presionado == false)
            {
                DeshabilitarBtn();
                Btn_borrar.Enabled = true;
                presionado = true;
            }
            else
            {
                BorrarDatos();
                Txt_codCuenta.Focus();
                presionado = false;
                DeshabilitarCampos();
                HabilitarBtn();
                Limpiar();
            }
        }
    }
}
