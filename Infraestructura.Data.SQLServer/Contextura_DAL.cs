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
    public class Contextura_DAL
    {  
        SqlConnection conexion;
        SqlCommand cmd;
        SqlDataReader reader;
  
        public IEnumerable<Contextura> ListarContexturas()
        {
            List<Contextura> contexturas = new List<Contextura>();

            try
            {
                conexion = new Conexion().Conectar() ;
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText="SELECT * FROM TB_CONTEXTURA";
                cmd.CommandType=CommandType.Text;

                conexion.Open();
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
          
            return contexturas;
        }


        public string buscarContextura(Usuario usuario2)
        {
            String contextura;
            try
            {
                conexion = new Conexion().Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText = "SELECT desc_contex FROM tb_Informacion_Usuario i join tb_contextura t " +
                                  "on i.cod_contex = t.cod_contex " +
                                  "WHERE cod_usu=@cod_usu";
                cmd.Parameters.AddWithValue("@cod_usu", usuario2.cod_usu);

                cmd.CommandType = CommandType.Text;

                conexion.Open();
                reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    contextura = Convert.ToString(reader["desc_contex"]);

                }
                else
                {
                    contextura = "";
                }
                reader.Close();
            }
            catch (Exception e)
            {
                // Debug.WriteLine(e.ToString());
                contextura = "";
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
            return contextura;
        }
        
    }
}
