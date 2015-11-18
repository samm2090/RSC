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
    public class EstadoCivil_DAL
    {
        Conexion conexion;
        SqlCommand cmd;
        SqlDataReader reader;

        public IEnumerable<EstadoCivil> ListarEstadosCiviles()
        {
            List<EstadoCivil> estadosCiviles = new List<EstadoCivil>();

            try
            {
                conexion = new Conexion();
                cmd = new SqlCommand("SELECT * FROM TB_ESTADOCIVIL", conexion.Conectar());
                cmd.CommandType = CommandType.Text;

                conexion.Conectar().Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EstadoCivil estadoCivil = new EstadoCivil();

                    estadoCivil.cod_estCiv = Convert.ToInt32(reader["cod_estCiv"]);
                    estadoCivil.desc_estCiv = Convert.ToString(reader["desc_estCiv"]);

                    estadosCiviles.Add(estadoCivil);
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

            return estadosCiviles;
        }

    }
}
