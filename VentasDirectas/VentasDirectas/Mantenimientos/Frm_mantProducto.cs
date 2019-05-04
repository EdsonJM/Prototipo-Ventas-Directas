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
    public partial class Frm_mantProducto : Form
    {

        bool presionado = false;
        string usuario;
        DateTime fecha = DateTime.Now;

        string codProd = " ";
        string codProv = " ";
        string nomProd = " ";
        string marcaProd = " ";
        string lineaProd = " ";
        string imei = " ";
        string cantProd = " ";
        string costoU = " ";
        string precioU = " ";
        string existencias = " ";

        public Frm_mantProducto(string usuario)
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
            Txt_codProducto.Enabled = false;
            Txt_codProveedor.Enabled = false;
            Txt_nomProducto.Enabled = false;
            Txt_marcaProducto.Enabled = false;
            Txt_codLinea.Enabled = false;
            Txt_imei.Enabled = false;
            Txt_cantidad.Enabled = false;
            Txt_costoU.Enabled = false;
            Txt_precioU.Enabled = false;
            Txt_existencias.Enabled = false;
        }

        private void HabilitarCampos()
        {
            Txt_codProducto.Enabled = true;
            Txt_codProveedor.Enabled = true;
            Txt_nomProducto.Enabled = true;
            Txt_marcaProducto.Enabled = true;
            Txt_codLinea.Enabled = true;
            Txt_imei.Enabled = true;
            Txt_cantidad.Enabled = true;
            Txt_costoU.Enabled = true;
            Txt_precioU.Enabled = true;
            Txt_existencias.Enabled = true;
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
            Txt_codProducto.Text = " ";
            Txt_codProveedor.Text = " ";
            Txt_nomProducto.Text = " ";
            Txt_marcaProducto.Text = " ";
            Txt_codLinea.Text = " ";
            Txt_imei.Text = " ";
            Txt_cantidad.Text = " ";
            Txt_costoU.Text = " ";
            Txt_precioU.Text = " ";
            Txt_existencias.Text = " ";
        }

        private void Frm_mantProducto_Load(object sender, EventArgs e)
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
                Frm_consultaProducto conProducto = new Frm_consultaProducto();
                conProducto.ShowDialog();

                if (conProducto.DialogResult == DialogResult.OK)
                {
                    Txt_codProducto.Text =
                        conProducto.Dgv_mostrarProducto.Rows[conProducto.Dgv_mostrarProducto.CurrentRow.Index].
                        Cells[0].Value.ToString();

                    Txt_codProveedor.Text = conProducto.Dgv_mostrarProducto.Rows[conProducto.Dgv_mostrarProducto.CurrentRow.Index].
                        Cells[1].Value.ToString();

                    Txt_nomProducto.Text = conProducto.Dgv_mostrarProducto.Rows[conProducto.Dgv_mostrarProducto.CurrentRow.Index].
                        Cells[2].Value.ToString();

                    Txt_marcaProducto.Text = conProducto.Dgv_mostrarProducto.Rows[conProducto.Dgv_mostrarProducto.CurrentRow.Index].
                        Cells[3].Value.ToString();

                    Txt_codLinea.Text = conProducto.Dgv_mostrarProducto.Rows[conProducto.Dgv_mostrarProducto.CurrentRow.Index].
                        Cells[4].Value.ToString();

                    Txt_imei.Text = conProducto.Dgv_mostrarProducto.Rows[conProducto.Dgv_mostrarProducto.CurrentRow.Index].
                        Cells[5].Value.ToString();

                    Txt_cantidad.Text = conProducto.Dgv_mostrarProducto.Rows[conProducto.Dgv_mostrarProducto.CurrentRow.Index].
                        Cells[6].Value.ToString();

                    Txt_costoU.Text = conProducto.Dgv_mostrarProducto.Rows[conProducto.Dgv_mostrarProducto.CurrentRow.Index].
                        Cells[7].Value.ToString();

                    Txt_precioU.Text = conProducto.Dgv_mostrarProducto.Rows[conProducto.Dgv_mostrarProducto.CurrentRow.Index].
                        Cells[8].Value.ToString();

                    Txt_existencias.Text = conProducto.Dgv_mostrarProducto.Rows[conProducto.Dgv_mostrarProducto.CurrentRow.Index].
                        Cells[9].Value.ToString();

                    Txt_codProducto.Focus();
                    presionado = false;
                    HabilitarBtn();
                }
            }
        }

        private void BorrarDatos()
        {
            codProd = Txt_codProducto.Text;

            try
            {
                string consulta = "DELETE FROM `tbl_producto` WHERE `Cod_Producto` = " + codProd;
                OdbcCommand comm = new OdbcCommand(consulta, Conexion.nuevaConexion());
                comm.ExecuteNonQuery();
                MessageBox.Show("Registro eliminado correctamente");

                OdbcCommand comm1 = new OdbcCommand("{call SP_InsertarBitacora(?,?,?,?)}", Conexion.nuevaConexion());
                comm1.CommandType = CommandType.StoredProcedure;
                comm1.Parameters.Add("ope", OdbcType.Text).Value = "ELIMINACIÓN DE REGISTRO";
                comm1.Parameters.Add("usr", OdbcType.Text).Value = usuario;
                comm1.Parameters.Add("fecha", OdbcType.Text).Value = fecha.ToString("yyyy/MM/dd HH:mm:ss");
                comm1.Parameters.Add("tbl", OdbcType.Text).Value = "PRODUCTOS";
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
                Txt_codProducto.Focus();
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
            codProd = Txt_codProducto.Text;
            codProv = Txt_codProveedor.Text;
            nomProd = Txt_nomProducto.Text;
            marcaProd = Txt_marcaProducto.Text;
            lineaProd = Txt_codLinea.Text;
            imei = Txt_imei.Text;
            cantProd = Txt_cantidad.Text;
            costoU = Txt_costoU.Text;
            precioU = Txt_precioU.Text;
            existencias = Txt_existencias.Text;

            try
            {
                string consulta = "INSERT INTO `tbl_producto` VALUES ('" + codProd + "', '" + codProv + "'," +
                    " '" + nomProd + "', '" + marcaProd + "', '" + lineaProd + "', '" + imei + "', '" + cantProd + "'" +
                    ", '" + costoU + "', '" + precioU + "', '" + existencias + "')";
                OdbcCommand comm = new OdbcCommand(consulta, Conexion.nuevaConexion());
                comm.ExecuteNonQuery();
                MessageBox.Show("Registro guardado correctamente");

                OdbcCommand comm1 = new OdbcCommand("{call SP_InsertarBitacora(?,?,?,?)}", Conexion.nuevaConexion());
                comm1.CommandType = CommandType.StoredProcedure;
                comm1.Parameters.Add("ope", OdbcType.Text).Value = "NUEVO REGISTRO";
                comm1.Parameters.Add("usr", OdbcType.Text).Value = usuario;
                comm1.Parameters.Add("fecha", OdbcType.Text).Value = fecha.ToString("yyyy/MM/dd HH:mm:ss");
                comm1.Parameters.Add("tbl", OdbcType.Text).Value = "PRODUCTOS";
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
                Txt_codProducto.Focus();
                presionado = false;
                DeshabilitarCampos();
                HabilitarBtn();
                Limpiar();
            }
        }

        private void ActualizarDatos()
        {
            codProd = Txt_codProducto.Text;
            codProv = Txt_codProveedor.Text;
            nomProd = Txt_nomProducto.Text;
            marcaProd = Txt_marcaProducto.Text;
            lineaProd = Txt_codLinea.Text;
            imei = Txt_imei.Text;
            cantProd = Txt_cantidad.Text;
            costoU = Txt_costoU.Text;
            precioU = Txt_precioU.Text;
            existencias = Txt_existencias.Text;

            try
            {
                string consulta = "UPDATE `tbl_producto` SET `Cod_Producto` = '" + codProd + "', `Cod_Proveedor` = '" + codProv + "'" +
                    ", `Nombre_Producto` = '" + nomProd + "', `Marca_Producto` = '" + marcaProd + "', `Linea_Producto` = '" + lineaProd + "'," +
                    "`IMEI` = '" + imei + "', `Cantidad` = '" + cantProd + "', `Costo_Unitario` = '" + costoU + "'," +
                    "`Precio_Unitario` = '" + precioU + "', `Exitencias` = '" + existencias + "' WHERE Cod_Producto = " + codProd;

                OdbcCommand comm = new OdbcCommand(consulta, Conexion.nuevaConexion());
                comm.ExecuteNonQuery();
                MessageBox.Show("Registro actualizado correctamente");

                OdbcCommand comm1 = new OdbcCommand("{call SP_InsertarBitacora(?,?,?,?)}", Conexion.nuevaConexion());
                comm1.CommandType = CommandType.StoredProcedure;
                comm1.Parameters.Add("ope", OdbcType.Text).Value = "ACTUALIZACIÓN DE REGISTRO";
                comm1.Parameters.Add("usr", OdbcType.Text).Value = usuario;
                comm1.Parameters.Add("fecha", OdbcType.Text).Value = fecha.ToString("yyyy/MM/dd HH:mm:ss");
                comm1.Parameters.Add("tbl", OdbcType.Text).Value = "PRODUCTOS";
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
                Txt_codProducto.Enabled = false;
            }
            else
            {
                ActualizarDatos();
                Txt_codProducto.Focus();
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
