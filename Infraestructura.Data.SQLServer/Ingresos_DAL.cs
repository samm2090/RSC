using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Dominio.Core.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.Data.SQLServer
{
    public class Ingresos_DAL
    {
        SqlConnection conexion;
        SqlCommand cmd;
        SqlDataReader reader;

        public IEnumerable<Ingresos> ListarIngresos()
        {
            List<Ingresos> ingresos = new List<Ingresos>();

            try
            {
                conexion = new Conexion().Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText="SELECT * FROM TB_INGRESOS";
                cmd.CommandType = CommandType.Text;

                conexion.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Ingresos ingreso = new Ingresos();

                    ingreso.cod_ing = Convert.ToInt32(reader["cod_ing"]);
                    ingreso.desc_ing = Convert.ToString(reader["desc_ing"]);

                    ingresos.Add(ingreso);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                conexion.Dispose();
                cmd.Dispose();
            }

            return ingresos;
        }

    }
}
