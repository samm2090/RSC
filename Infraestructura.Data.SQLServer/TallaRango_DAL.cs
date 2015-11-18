using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Core.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.Data.SQLServer
{
    public class TallaRango_DAL
    {
        Conexion conexion;
        SqlCommand cmd;
        SqlDataReader reader;

        public IEnumerable<TallaRango> ListarTallasRangos()
        {
            List<TallaRango> tallasRangos = new List<TallaRango>();

            try
            {
                conexion = new Conexion();
                cmd = new SqlCommand("SELECT * FROM TB_TALLA_RANGO", conexion.Conectar());
                cmd.CommandType = CommandType.Text;

                conexion.Conectar().Open();
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
                Console.Write(e.Message);
            }
            finally
            {
                if (conexion.Conectar().State == ConnectionState.Open)
                {
                    conexion.Conectar().Close();
                }
            }

            conexion.Conectar().Dispose();
            cmd.Dispose();

            return tallasRangos;
        }

    }
}
