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
    public class Cualidad_DAL
    {
        SqlConnection conexion;
        SqlCommand cmd;
        SqlDataReader reader;

        public IEnumerable<Cualidad> ListarCualidades()
        {
            List<Cualidad> cualidades = new List<Cualidad>();

            try
            {
                conexion = new Conexion().Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText = "SELECT * FROM TB_CUALIDAD";
                cmd.CommandType = CommandType.Text;

                conexion.Open();
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

            return cualidades;
        }


        public List<string> buscarCualidades(Usuario usuario2)
        {
            List<String> cualidades = new List<String>();
            try
            {
                conexion = new Conexion().Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText = "SELECT desc_cua FROM tb_Cualidad i join tb_Cualidades_Usuario t " +
                                  "on i.cod_cua = t.cod_cua " +
                                  "WHERE cod_usu=@cod_usu";
                cmd.Parameters.AddWithValue("@cod_usu", usuario2.cod_usu);

                cmd.CommandType = CommandType.Text;

                conexion.Open();
                reader = cmd.ExecuteReader();
                 
                while (reader.Read())
                {
                    String cualidad;
                    cualidad = Convert.ToString(reader["desc_cua"]);

                    cualidades.Add(cualidad);
                }

                reader.Close();
            }
            catch (Exception e)
            {
                // Debug.WriteLine(e.ToString());
                cualidades = null;
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
            return cualidades;
        
        }
    }
}
