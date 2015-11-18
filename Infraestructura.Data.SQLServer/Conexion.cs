using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Infraestructura.Data.SQLServer
{
    public class Conexion
    {
        SqlConnection conexion;

        public SqlConnection Conectar()
        {
            conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
            return conexion;
        }
    }
}
