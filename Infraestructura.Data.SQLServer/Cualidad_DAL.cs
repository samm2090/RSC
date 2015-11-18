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
    public class Cualidad_DAL
    {
        Conexion conexion;
        SqlCommand cmd;
        SqlDataReader reader;

        public IEnumerable<Cualidad> ListarCualidades()
        {
            List<Cualidad> cualidades = new List<Cualidad>();

            try
            {
                conexion = new Conexion();
                cmd = new SqlCommand("SELECT * FROM TB_CUALIDAD", conexion.Conectar());
                cmd.CommandType = CommandType.Text;

                conexion.Conectar().Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Cualidad cualidad = new Cualidad();

                    cualidad.cod_cua = Convert.ToInt32(reader["cod_cua"]);
                    cualidad.desc_cua = Convert.ToString(reader["desc_cua"]);

                    cualidades.Add(cualidad);
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

            return cualidades;
        }

    }
}
