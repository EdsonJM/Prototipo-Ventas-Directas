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

namespace VentasDirectas
{
    public partial class Frm_login : Form
    {
        public string tipoUsuario = "";
        public string usuarioLogeado = "";
        DateTime fecha = DateTime.Now;

        public Frm_login()
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

        private void IniciarSesion()
        {
            try
            {
                string seleccionarUsuario = string.Format("SELECT * FROM tbl_usuario;");
                OdbcCommand comm = new OdbcCommand(seleccionarUsuario, Conexion.nuevaConexion());
                OdbcDataReader mostrar = comm.ExecuteReader();

                while(mostrar.Read())
                {
                    if((Txt_usuario.Text==mostrar.GetString(2)) && (Txt_contraseña.Text==mostrar.GetString(3)))
                    {
                        usuarioLogeado = mostrar.GetString(1); //iguala al valor del campo cuenta_usr
                        tipoUsuario = mostrar.GetString(4); //asigna el valor del campo tipo_usuario
                        MessageBox.Show("INICIO DE SESIÓN ACEPTADO");
                        Frm_mdi mdiMenu = new Frm_mdi(usuarioLogeado,tipoUsuario);
                        this.Hide();
                        mdiMenu.Show();
                        break;
                    }
                    else
                    {
                        Console.Write("DATOS INCORRECTOS");
                        Txt_usuario.Focus();
                    }
                }

            }
            catch(Exception err)
            {
                Console.Write("Error: " + err.Message);
            }

            try
            {
                OdbcCommand comm = new OdbcCommand("{call SP_InsertarBitacora(?,?,?,?)}", Conexion.nuevaConexion());
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("ope", OdbcType.Text).Value = "INICIO DE SESIÓN";
                comm.Parameters.Add("usr", OdbcType.Text).Value = usuarioLogeado;
                comm.Parameters.Add("fecha", OdbcType.Text).Value = fecha.ToString("yyyy/MM/dd HH:mm:ss");
                comm.Parameters.Add("tbl", OdbcType.Text).Value = "-----";
                comm.ExecuteNonQuery();
            }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private void Btn_ingresar_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        private void Frm_login_Load(object sender, EventArgs e)
        {
            Txt_usuario.Focus();
            usuarioLogeado = "";
            
        }
    }
}
