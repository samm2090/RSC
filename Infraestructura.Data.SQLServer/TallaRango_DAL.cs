using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using Dominio.Core.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.Data.SQLServer
{
    public class TallaRango_DAL
    {
        SqlConnection conexion;
        SqlCommand cmd;
        SqlDataReader reader;

        public IEnumerable<TallaRango> ListarTallasRangos()
        {
            List<TallaRango> tallasRangos = new List<TallaRango>();

            try
            {
                conexion = new Conexion().Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText = "SELECT * FROM TB_TALLA_RANGO";
                cmd.CommandType = CommandType.Text;

                conexion.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TallaRango tallaRango = new TallaRango();

                    tallaRango.cod_talla_ran = Convert.ToInt32(reader["cod_talla_ran"]);
                    tallaRango.desc_talla_ran = Convert.ToString(reader["desc_talla_ran"]);

                    tallasRangos.Add(tallaRango);
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

            return tallasRangos;
        }

    }
}
