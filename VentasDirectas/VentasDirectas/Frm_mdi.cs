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
using VentasDirectas.Mantenimientos;

namespace VentasDirectas
{
    public partial class Frm_mdi : Form
    {
        string usuario;
        string tipoUsuario;
        DateTime fecha = DateTime.Now;

        public Frm_mdi(string usuario, string tipoUsuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.tipoUsuario = tipoUsuario;
        }

        private void Frm_mdi_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "BIENVENIDO: " + usuario;

            MdiClient ctlMDI; //control del color del MDI
            // Loop through all of the form's controls looking
            // for the control of type MdiClient.
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    // Attempt to cast the control to type MdiClient.
                    ctlMDI = (MdiClient)ctl;

                    // Set the BackColor of the MdiClient control.
                    ctlMDI.BackColor = this.BackColor;
                }
                catch (InvalidCastException exc)
                {
                    // Catch and ignore the error if casting failed.
                }
            }
        }

        private void Frm_mdi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_login logeo = new Frm_login();
            this.Hide();
            logeo.Show();

            try
            {
                OdbcCommand comm = new OdbcCommand("{call SP_InsertarBitacora(?,?,?,?)}", Conexion.nuevaConexion());
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("ope", OdbcType.Text).Value = "CIERRE DE SESIÓN";
                comm.Parameters.Add("usr", OdbcType.Text).Value = usuario;
                comm.Parameters.Add("fecha", OdbcType.Text).Value = fecha.ToString("yyyy/MM/dd HH:mm:ss");
                comm.Parameters.Add("tbl", OdbcType.Text).Value = "-----";
                comm.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

        }

        bool ventanaBitacora = false;
        Frm_bitacora bitacora = new Frm_bitacora();
        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_bitacora);
            if (ventanaBitacora == false || frmC == null)
            {
                if (frmC == null)
                {
                    bitacora = new Frm_bitacora();
                }

                bitacora.MdiParent = this;
                bitacora.Show();
                Application.DoEvents();
                ventanaBitacora = true;
            }
            else
            {
                bitacora.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanaCuentaContable = false;
        Frm_mantCuentaContable cuentaContable = new Frm_mantCuentaContable("");
        private void cuentasContablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_mantCuentaContable);
            if (ventanaCuentaContable == false || frmC == null)
            {
                if (frmC == null)
                {
                    cuentaContable = new Frm_mantCuentaContable(usuario);
                }

                cuentaContable.MdiParent = this;
                cuentaContable.Show();
                Application.DoEvents();
                ventanaCuentaContable = true;
            }
            else
            {
                cuentaContable.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanaEmpleado = false;
        Frm_mantEmpleado empleado = new Frm_mantEmpleado("");
        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_mantEmpleado);
            if (ventanaEmpleado == false || frmC == null)
            {
                if (frmC == null)
                {
                    empleado = new Frm_mantEmpleado(usuario);
                }

                empleado.MdiParent = this;
                empleado.Show();
                Application.DoEvents();
                ventanaEmpleado = true;
            }
            else
            {
                empleado.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanaGasto = false;
        Frm_mantGastos gasto = new Frm_mantGastos("");
        private void gastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_mantGastos);
            if (ventanaGasto == false || frmC == null)
            {
                if (frmC == null)
                {
                    gasto = new Frm_mantGastos(usuario);
                }

                gasto.MdiParent = this;
                gasto.Show();
                Application.DoEvents();
                ventanaGasto = true;
            }
            else
            {
                gasto.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanaProducto = false;
        Frm_mantProducto producto = new Frm_mantProducto("");
        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_mantProducto);
            if (ventanaProducto == false || frmC == null)
            {
                if (frmC == null)
                {
                    producto = new Frm_mantProducto(usuario);
                }

                producto.MdiParent = this;
                producto.Show();
                Application.DoEvents();
                ventanaProducto = true;
            }
            else
            {
                producto.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanaProveedor = false;
        Frm_mantProveedor proveedor = new Frm_mantProveedor("");
        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_mantProveedor);
            if (ventanaProveedor == false || frmC == null)
            {
                if (frmC == null)
                {
                    proveedor = new Frm_mantProveedor(usuario);
                }

                proveedor.MdiParent = this;
                proveedor.Show();
                Application.DoEvents();
                ventanaProveedor = true;
            }
            else
            {
                proveedor.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanaSucursal = false;
        Frm_mantSucursal sucursal = new Frm_mantSucursal("");
        private void sucursalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_mantSucursal);
            if (ventanaSucursal == false || frmC == null)
            {
                if (frmC == null)
                {
                    sucursal = new Frm_mantSucursal(usuario);
                }

                sucursal.MdiParent = this;
                sucursal.Show();
                Application.DoEvents();
                ventanaSucursal = true;
            }
            else
            {
                sucursal.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanaTipoPago = false;
        Frm_mantTipoPago tipoPago = new Frm_mantTipoPago("");
        private void tipoDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_mantTipoPago);
            if (ventanaTipoPago == false || frmC == null)
            {
                if (frmC == null)
                {
                    tipoPago = new Frm_mantTipoPago(usuario);
                }

                tipoPago.MdiParent = this;
                tipoPago.Show();
                Application.DoEvents();
                ventanaTipoPago = true;
            }
            else
            {
                tipoPago.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanaTipoPuesto = false;
        Frm_mantTipoPuesto tipoPuesto = new Frm_mantTipoPuesto("");
        private void tipoDePuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_mantTipoPuesto);
            if (ventanaTipoPuesto == false || frmC == null)
            {
                if (frmC == null)
                {
                    tipoPuesto = new Frm_mantTipoPuesto(usuario);
                }

                tipoPuesto.MdiParent = this;
                tipoPuesto.Show();
                Application.DoEvents();
                ventanaTipoPuesto = true;
            }
            else
            {
                tipoPuesto.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }
    }
}
