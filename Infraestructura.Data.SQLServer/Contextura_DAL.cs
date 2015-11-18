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
    public class Contextura_DAL
    {  
        Conexion conexion;
        SqlCommand cmd;
        SqlDataReader reader;
  
        public IEnumerable<Contextura> ListarContexturas()
        {
            List<Contextura> contexturas = new List<Contextura>();

            try
            {
                conexion = new Conexion();
                cmd = new SqlCommand("SELECT * FROM TB_CONTEXTURA",conexion.Conectar());
                cmd.CommandType=CommandType.StoredProcedure;

                conexion.Conectar().Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Contextura contextura = new Contextura();
                 
                    contextura.cod_contex = Convert.ToInt32(reader["cod_contex"]);
                    contextura.desc_contex = Convert.ToString(reader["desc_contex"]);

                    contexturas.Add(contextura);
                }
                reader.Close();
            }
            catch(Exception e)
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

            return contexturas;
        }
    
    }
}
