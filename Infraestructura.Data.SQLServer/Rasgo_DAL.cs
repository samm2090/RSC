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
    public class Rasgo_DAL
    {
        Conexion conexion;
        SqlCommand cmd;
        SqlDataReader reader;

        public IEnumerable<Rasgo> ListarRasgos()
        {
            List<Rasgo> rasgos = new List<Rasgo>();

            try
            {
                conexion = new Conexion();
                cmd = new SqlCommand("SELECT * FROM TB_RASGO", conexion.Conectar());
                cmd.CommandType = CommandType.Text;

                conexion.Conectar().Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Rasgo rasgo = new Rasgo();

                    rasgo.cod_rasgo = Convert.ToInt32(reader["cod_rasgo"]);
                    rasgo.desc_rasgo = Convert.ToString(reader["desc_rasgo"]);

                    rasgos.Add(rasgo);
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

            return rasgos;
        }

    }
}
