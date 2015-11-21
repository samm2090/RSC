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
    public class Rasgo_DAL
    {
        SqlConnection conexion;
        SqlCommand cmd;
        SqlDataReader reader;

        public IEnumerable<Rasgo> ListarRasgos()
        {
            List<Rasgo> rasgos = new List<Rasgo>();

            try
            {
                conexion = new Conexion().Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText = "SELECT * FROM TB_RASGO";
                cmd.CommandType = CommandType.Text;

                conexion.Open();
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

            return rasgos;
        }

    }
}
