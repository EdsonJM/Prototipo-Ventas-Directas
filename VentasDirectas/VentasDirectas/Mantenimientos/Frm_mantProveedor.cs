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
    public partial class Frm_mantProveedor : Form
    {

        bool presionado = false;
        string usuario;
        DateTime fecha = DateTime.Now;

        string codProv = "";
        string nomProv = "";
        string telProv = "";
        string dirProv = "";
        string correoProv = "";
        string codPostal = "";
        string estado = "";

        public Frm_mantProveedor(string usuario)
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
            Txt_codProveedor.Enabled = false;
            Txt_nombreProveedor.Enabled = false;
            Txt_telProveedor.Enabled = false;
            Txt_dirProveedor.Enabled = false;
            Txt_correoProveedor.Enabled = false;
            Txt_codPostal.Enabled = false;
            Txt_estadoProveedor.Enabled = false;
        }

        private void HabilitarCampos()
        {
            Txt_codProveedor.Enabled = true;
            Txt_nombreProveedor.Enabled = true;
            Txt_telProveedor.Enabled = true;
            Txt_dirProveedor.Enabled = true;
            Txt_correoProveedor.Enabled = true;
            Txt_codPostal.Enabled = true;
            Txt_estadoProveedor.Enabled = true;
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
            Txt_codProveedor.Text = " ";
            Txt_nombreProveedor.Text = " ";
            Txt_telProveedor.Text = " ";
            Txt_dirProveedor.Text = " ";
            Txt_correoProveedor.Text = " ";
            Txt_codPostal.Text = " ";
            Txt_estadoProveedor.Text = " ";
        }

        private void Frm_mantProveedor_Load(object sender, EventArgs e)
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
                Frm_consultaProveedor conProveedor = new Frm_consultaProveedor();
                conProveedor.ShowDialog();

                if (conProveedor.DialogResult == DialogResult.OK)
                {
                    Txt_codProveedor.Text =
                        conProveedor.Dgv_mostrarProveedor.Rows[conProveedor.Dgv_mostrarProveedor.CurrentRow.Index].
                        Cells[0].Value.ToString();

                    Txt_nombreProveedor.Text = conProveedor.Dgv_mostrarProveedor.Rows[conProveedor.Dgv_mostrarProveedor.CurrentRow.Index].
                        Cells[1].Value.ToString();

                    Txt_telProveedor.Text = conProveedor.Dgv_mostrarProveedor.Rows[conProveedor.Dgv_mostrarProveedor.CurrentRow.Index].
                        Cells[2].Value.ToString();

                    Txt_dirProveedor.Text = conProveedor.Dgv_mostrarProveedor.Rows[conProveedor.Dgv_mostrarProveedor.CurrentRow.Index].
                        Cells[3].Value.ToString();

                    Txt_correoProveedor.Text = conProveedor.Dgv_mostrarProveedor.Rows[conProveedor.Dgv_mostrarProveedor.CurrentRow.Index].
                        Cells[4].Value.ToString();

                    Txt_codPostal.Text = conProveedor.Dgv_mostrarProveedor.Rows[conProveedor.Dgv_mostrarProveedor.CurrentRow.Index].
                        Cells[5].Value.ToString();

                    Txt_estadoProveedor.Text = conProveedor.Dgv_mostrarProveedor.Rows[conProveedor.Dgv_mostrarProveedor.CurrentRow.Index].
                        Cells[6].Value.ToString();

                    Txt_codProveedor.Focus();
                    presionado = false;
                    HabilitarBtn();
                }
            }
        }

        private void BorrarDatos()
        {
            codProv = Txt_codProveedor.Text;

            try
            {
                string consulta = "DELETE FROM `tbl_proveedores` WHERE `Cod_Proveedor` = " + codProv;
                OdbcCommand comm = new OdbcCommand(consulta, Conexion.nuevaConexion());
                comm.ExecuteNonQuery();
                MessageBox.Show("Registro eliminado correctamente");

                OdbcCommand comm1 = new OdbcCommand("{call SP_InsertarBitacora(?,?,?,?)}", Conexion.nuevaConexion());
                comm1.CommandType = CommandType.StoredProcedure;
                comm1.Parameters.Add("ope", OdbcType.Text).Value = "ELIMINACIÓN DE REGISTRO";
                comm1.Parameters.Add("usr", OdbcType.Text).Value = usuario;
                comm1.Parameters.Add("fecha", OdbcType.Text).Value = fecha.ToString("yyyy/MM/dd HH:mm:ss");
                comm1.Parameters.Add("tbl", OdbcType.Text).Value = "PROVEEDORES";
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
                Txt_codProveedor.Focus();
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
            codProv = Txt_codProveedor.Text;
            nomProv = Txt_nombreProveedor.Text;
            telProv = Txt_telProveedor.Text;
            dirProv = Txt_dirProveedor.Text;
            correoProv = Txt_correoProveedor.Text;
            codPostal = Txt_codPostal.Text;
            estado = Txt_estadoProveedor.Text;

            try
            {
                string consulta = "INSERT INTO `tbl_proveedores` VALUES ('" + codProv + "', '" + nomProv + "'," +
                    " '" + telProv + "', '" + dirProv + "', '" + correoProv + "', '" + codPostal + "', '" + estado + "')";
                OdbcCommand comm = new OdbcCommand(consulta, Conexion.nuevaConexion());
                comm.ExecuteNonQuery();
                MessageBox.Show("Registro guardado correctamente");

                OdbcCommand comm1 = new OdbcCommand("{call SP_InsertarBitacora(?,?,?,?)}", Conexion.nuevaConexion());
                comm1.CommandType = CommandType.StoredProcedure;
                comm1.Parameters.Add("ope", OdbcType.Text).Value = "NUEVO REGISTRO";
                comm1.Parameters.Add("usr", OdbcType.Text).Value = usuario;
                comm1.Parameters.Add("fecha", OdbcType.Text).Value = fecha.ToString("yyyy/MM/dd HH:mm:ss");
                comm1.Parameters.Add("tbl", OdbcType.Text).Value = "PROVEEDORES";
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
                Txt_codProveedor.Focus();
                presionado = false;
                DeshabilitarCampos();
                HabilitarBtn();
                Limpiar();
            }
        }

        private void ActualizarDatos()
        {
            codProv = Txt_codProveedor.Text;
            nomProv = Txt_nombreProveedor.Text;
            telProv = Txt_telProveedor.Text;
            dirProv = Txt_dirProveedor.Text;
            correoProv = Txt_correoProveedor.Text;
            codPostal = Txt_codPostal.Text;
            estado = Txt_estadoProveedor.Text;

            try
            {
                string consulta = "UPDATE `tbl_proveedores` SET `Cod_Proveedor` = '" + codProv + "', `Nombre_Proveedor` = '" + nomProv + "'" +
                    ", `Telefono_Proveedor` = '" + telProv + "', `Direccion` = '" + dirProv + "', `Correo_Proveedor` = '" + correoProv + "'," +
                    "`Codigo_Postal` = '" + codPostal + "', `Estado_Proveedor` = '" + estado + "' WHERE Cod_Proveedor = " + codProv;

                OdbcCommand comm = new OdbcCommand(consulta, Conexion.nuevaConexion());
                comm.ExecuteNonQuery();
                MessageBox.Show("Registro actualizado correctamente");

                OdbcCommand comm1 = new OdbcCommand("{call SP_InsertarBitacora(?,?,?,?)}", Conexion.nuevaConexion());
                comm1.CommandType = CommandType.StoredProcedure;
                comm1.Parameters.Add("ope", OdbcType.Text).Value = "ACTUALIZACIÓN DE REGISTRO";
                comm1.Parameters.Add("usr", OdbcType.Text).Value = usuario;
                comm1.Parameters.Add("fecha", OdbcType.Text).Value = fecha.ToString("yyyy/MM/dd HH:mm:ss");
                comm1.Parameters.Add("tbl", OdbcType.Text).Value = "PROVEEDORES";
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
                Txt_codProveedor.Enabled = false;
            }
            else
            {
                ActualizarDatos();
                Txt_codProveedor.Focus();
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
