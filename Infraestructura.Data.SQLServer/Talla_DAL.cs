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
    public class Talla_DAL
    {
        Conexion conexion;
        SqlCommand cmd;
        SqlDataReader reader;

        public IEnumerable<Talla> ListarTallas()
        {
            List<Talla> tallas = new List<Talla>();

            try
            {
                conexion = new Conexion();
                cmd = new SqlCommand("SELECT * FROM TB_TALLA", conexion.Conectar());
                cmd.CommandType = CommandType.Text;

                conexion.Conectar().Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Talla talla = new Talla();

                    talla.cod_talla = Convert.ToInt32(reader["cod_talla"]);
                    talla.desc_talla = Convert.ToString(reader["desc_talla"]);

                    tallas.Add(talla);
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

            return tallas;
        }

    }
}
