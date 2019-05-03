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
    public partial class Frm_mantEmpleado : Form
    {

        bool presionado = false;
        string usuario;
        DateTime fecha = DateTime.Now;

        string codEmp = " ";
        string codTipoPuesto = " ";
        string primerNom = " ";
        string segundoNom = " ";
        string tercerNom = " ";
        string primerApe = " ";
        string segundoApe = " ";
        string tercerApe = " ";
        string dpi = " ";
        string nit = " ";
        string direccion = " ";
        string telefono1 = " ";
        string telefono2 = " ";
        string fechaNac = " ";
        string fechaContra = " ";
        string correo = " ";
        string genero = " ";
        string estado = " ";

        public Frm_mantEmpleado(string usuario)
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

        private void HabilitarCampos()
        {
            Txt_codEmpleado.Enabled = true;
            Txt_codTipoPuesto.Enabled = true;
            Txt_primerNombre.Enabled = true;
            Txt_segundoNombre.Enabled = true;
            Txt_tercerNombre.Enabled = true;
            Txt_primerApellido.Enabled = true;
            Txt_segundoApellido.Enabled = true;
            Txt_tercerApellido.Enabled = true;
            Txt_dpi.Enabled = true;
            Txt_nit.Enabled = true;
            Txt_direccion.Enabled = true;
            Txt_telefono1.Enabled = true;
            Txt_telefono2.Enabled = true;
            Dtp_fechaNac.Enabled = true;
            Dtp_fecha_contra.Enabled = true;
            Txt_correo.Enabled = true;
            Txt_género.Enabled = true;
            Txt_estado.Enabled = true;
        }

        private void DeshabilitarCampos()
        {
            Txt_codEmpleado.Enabled = false;
            Txt_codTipoPuesto.Enabled = false;
            Txt_primerNombre.Enabled = false;
            Txt_segundoNombre.Enabled = false;
            Txt_tercerNombre.Enabled = false;
            Txt_primerApellido.Enabled = false;
            Txt_segundoApellido.Enabled = false;
            Txt_tercerApellido.Enabled = false;
            Txt_dpi.Enabled = false;
            Txt_nit.Enabled = false;
            Txt_direccion.Enabled = false;
            Txt_telefono1.Enabled = false;
            Txt_telefono2.Enabled = false;
            Dtp_fechaNac.Enabled = false;
            Dtp_fecha_contra.Enabled = false;
            Txt_correo.Enabled = false;
            Txt_género.Enabled = false;
            Txt_estado.Enabled = false;
        }

        private void Limpiar()
        {
            Txt_codEmpleado.Text = "";
            Txt_codTipoPuesto.Text = "";
            Txt_primerNombre.Text = "";
            Txt_segundoNombre.Text = "";
            Txt_tercerNombre.Text = "";
            Txt_primerApellido.Text = "";
            Txt_segundoApellido.Text = "";
            Txt_tercerApellido.Text = "";
            Txt_dpi.Text = "";
            Txt_nit.Text = "";
            Txt_direccion.Text = "";
            Txt_telefono1.Text = "";
            Txt_telefono2.Text = "";
            Txt_correo.Text = "";
            Txt_género.Text = "";
            Txt_estado.Text = "";
        }

        private void HabilitarBtn()
        {
            Btn_ingresar.Enabled = true;
            Btn_editar.Enabled = true;
            Btn_guardar.Enabled = true;
            Btn_borrar.Enabled = true;
            Btn_consultar.Enabled = true;
        }

        private void DeshabilitarBtn()
        {
            Btn_ingresar.Enabled = false;
            Btn_editar.Enabled = false;
            Btn_guardar.Enabled = false;
            Btn_borrar.Enabled = false;
            Btn_consultar.Enabled = false;
        }

        private void Btn_ingresar_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
        }

        private void ActualizarDatos()
        {
            codEmp = Txt_codEmpleado.Text;
            codTipoPuesto = Txt_codTipoPuesto.Text;
            primerNom = Txt_primerNombre.Text;
            segundoNom = Txt_segundoNombre.Text;
            tercerNom = Txt_tercerNombre.Text;
            primerApe = Txt_primerApellido.Text;
            segundoApe = Txt_segundoApellido.Text;
            tercerApe = Txt_tercerApellido.Text;
            dpi = Txt_dpi.Text;
            nit = Txt_nit.Text;
            direccion = Txt_direccion.Text;
            telefono1 = Txt_telefono1.Text;
            telefono2 = Txt_telefono2.Text;
            fechaNac = Dtp_fechaNac.Text;
            fechaContra = Dtp_fecha_contra.Text;
            correo = Txt_correo.Text;
            genero = Txt_género.Text;
            estado = Txt_estado.Text;

            try
            {
                string consulta = "UPDATE `tbl_empleados` SET `Cod_Emp` = '" + codEmp + "', `Cod_TipoPuesto` = '" + codTipoPuesto + "'" +
                    ", `PrimerNombre_Emp` = '" + primerNom + "', `SegundoNombre_Emp` = '" + segundoNom + "', `TercerNombre_Emp` = '" + tercerNom + "'," +
                    "`PrimerApellido_Emp` = '" + primerApe + "', `SegundoApellido_Emp` = '" + segundoApe + "', `TercerApellido_Emp` = '" + tercerApe + "'," +
                    "`Dpi_Emp` = '" + dpi + "', `Nit_Emp` = '" + nit + "', `Direccion_Emp` = '" + direccion + "', `Telefono1_Emp` = '" + telefono1 + "'," +
                    "`Telefono2_Emp` = '" + telefono2 + "', `Fecha_de_nacimiento` = '" + fechaNac + "', `Fecha_Contratacion` = '" + fechaContra + "'," +
                    "`Email` = '" + correo + "', `Genero` = '" + genero + "', `Estado_Empleado` = '"+estado+"' WHERE Cod_Emp = " + codEmp;

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
                comm.Parameters.Add("tbl", OdbcType.Text).Value = "EMPLEADOS";
                comm.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private void Btn_editar_Click(object sender, EventArgs e)
        {
            if (presionado == false)
            {
                DeshabilitarBtn();
                Btn_editar.Enabled = true;
                presionado = true;
                Txt_codEmpleado.Enabled = false;
            }
            else
            {
                ActualizarDatos();
                Txt_codEmpleado.Focus();
                presionado = false;
                DeshabilitarCampos();
                HabilitarBtn();
                Limpiar();
            }
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
                Frm_consultaEmpleado conEmpleado = new Frm_consultaEmpleado();
                conEmpleado.ShowDialog();

                if (conEmpleado.DialogResult == DialogResult.OK)
                {
                    Txt_codEmpleado.Text =
                        conEmpleado.Dgv_mostrarEmpleado.Rows[conEmpleado.Dgv_mostrarEmpleado.CurrentRow.Index].
                        Cells[0].Value.ToString();

                    Txt_codTipoPuesto.Text = conEmpleado.Dgv_mostrarEmpleado.Rows[conEmpleado.Dgv_mostrarEmpleado.CurrentRow.Index].
                        Cells[1].Value.ToString();

                    Txt_primerNombre.Text = conEmpleado.Dgv_mostrarEmpleado.Rows[conEmpleado.Dgv_mostrarEmpleado.CurrentRow.Index].
                        Cells[2].Value.ToString();

                    Txt_primerApellido.Text = conEmpleado.Dgv_mostrarEmpleado.Rows[conEmpleado.Dgv_mostrarEmpleado.CurrentRow.Index].
                        Cells[3].Value.ToString();

                    Txt_dpi.Text = conEmpleado.Dgv_mostrarEmpleado.Rows[conEmpleado.Dgv_mostrarEmpleado.CurrentRow.Index].
                        Cells[4].Value.ToString();

                    Txt_nit.Text = conEmpleado.Dgv_mostrarEmpleado.Rows[conEmpleado.Dgv_mostrarEmpleado.CurrentRow.Index].
                        Cells[5].Value.ToString();

                    Txt_direccion.Text = conEmpleado.Dgv_mostrarEmpleado.Rows[conEmpleado.Dgv_mostrarEmpleado.CurrentRow.Index].
                        Cells[6].Value.ToString();

                    Txt_telefono1.Text = conEmpleado.Dgv_mostrarEmpleado.Rows[conEmpleado.Dgv_mostrarEmpleado.CurrentRow.Index].
                        Cells[7].Value.ToString();

                    Dtp_fechaNac.Text = conEmpleado.Dgv_mostrarEmpleado.Rows[conEmpleado.Dgv_mostrarEmpleado.CurrentRow.Index].
                        Cells[8].Value.ToString();

                    Dtp_fecha_contra.Text = conEmpleado.Dgv_mostrarEmpleado.Rows[conEmpleado.Dgv_mostrarEmpleado.CurrentRow.Index].
                        Cells[9].Value.ToString();

                    Txt_correo.Text = conEmpleado.Dgv_mostrarEmpleado.Rows[conEmpleado.Dgv_mostrarEmpleado.CurrentRow.Index].
                       Cells[10].Value.ToString();

                    Txt_género.Text = conEmpleado.Dgv_mostrarEmpleado.Rows[conEmpleado.Dgv_mostrarEmpleado.CurrentRow.Index].
                       Cells[11].Value.ToString();

                    Txt_estado.Text = conEmpleado.Dgv_mostrarEmpleado.Rows[conEmpleado.Dgv_mostrarEmpleado.CurrentRow.Index].
                       Cells[12].Value.ToString();

                    Txt_codEmpleado.Focus();
                    presionado = false;
                    HabilitarBtn();
                }
            }
        }

        private void Frm_mantEmpleado_Load(object sender, EventArgs e)
        {
            DeshabilitarCampos();
        }

        private void GuardarDatos()
        {
            codEmp = Txt_codEmpleado.Text;
            codTipoPuesto = Txt_codTipoPuesto.Text;
            primerNom = Txt_primerNombre.Text;
            segundoNom = Txt_segundoNombre.Text;
            tercerNom = Txt_tercerNombre.Text;
            primerApe = Txt_primerApellido.Text;
            segundoApe = Txt_segundoApellido.Text;
            tercerApe = Txt_tercerApellido.Text;
            dpi = Txt_dpi.Text;
            nit = Txt_nit.Text;
            direccion = Txt_direccion.Text;
            telefono1 = Txt_telefono1.Text;
            telefono2 = Txt_telefono2.Text;
            fechaNac = Dtp_fechaNac.Text;
            fechaContra = Dtp_fecha_contra.Text;
            correo = Txt_correo.Text;
            genero = Txt_género.Text;
            estado = Txt_estado.Text;

            try
            {
                string consulta = "INSERT INTO `tbl_empleados` VALUES ('" + codEmp + "', '" + codTipoPuesto + "'," +
                    " '" + primerNom + "', '" + segundoNom + "', '" + tercerNom + "', '" + primerApe + "', '" + segundoApe + "'" +
                    ", '" + tercerApe + "', '" + dpi + "', '" + nit + "', '" + direccion + "', '" + telefono1 + "', '" + telefono2 + "'" +
                    ", '" + fechaNac + "', '" + fechaContra + "', '" + correo + "', '" + genero + "', '" + estado + "')";
                OdbcCommand comm = new OdbcCommand(consulta, Conexion.nuevaConexion());
                comm.ExecuteNonQuery();
                MessageBox.Show("Registro guardado correctamente");
            }
            catch (Exception err)
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
                comm.Parameters.Add("tbl", OdbcType.Text).Value = "EMPLEADOS";
                comm.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
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
                Txt_codEmpleado.Focus();
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
            codEmp = Txt_codEmpleado.Text;

            try
            {
                string consulta = "DELETE FROM `tbl_empleados` WHERE `Cod_Emp` = " + codEmp;
                OdbcCommand comm = new OdbcCommand(consulta, Conexion.nuevaConexion());
                comm.ExecuteNonQuery();
                MessageBox.Show("Registro eliminado correctamente");
            }
            catch (Exception err)
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
                comm.Parameters.Add("tbl", OdbcType.Text).Value = "EMPLEADOS";
                comm.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
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
                Txt_codEmpleado.Focus();
                presionado = false;
                DeshabilitarCampos();
                HabilitarBtn();
                Limpiar();
            }
        }
    }
}
