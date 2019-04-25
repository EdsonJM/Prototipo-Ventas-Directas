using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace VentasDirectas
{
    class Conexion
    {
        public static OdbcConnection nuevaConexion()
        {
            OdbcConnection conectar = new OdbcConnection("Dsn=ventas_directas");
            conectar.Open();
            //MessageBox.Show("Conexion Exitosa");
            return conectar;
        }
    }
}
