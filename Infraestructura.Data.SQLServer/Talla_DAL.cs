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
    public class Talla_DAL
    {
        SqlConnection conexion;
        SqlCommand cmd;
        SqlDataReader reader;

        public IEnumerable<Talla> ListarTallas()
        {
            List<Talla> tallas = new List<Talla>();

            try
            {
                conexion = new Conexion().Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText = "SELECT * FROM TB_TALLA";
                cmd.CommandType = CommandType.Text;

                conexion.Open();
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

            return tallas;
        }


        public String buscarTalla(Usuario usuario2)
        {
            String talla;
            try
            {
                conexion = new Conexion().Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText = "SELECT desc_talla FROM tb_Informacion_Usuario i join tb_Talla t " +
                                  "on i.cod_talla = t.cod_talla " +
                                  "WHERE cod_usu=@cod_usu";
                cmd.Parameters.AddWithValue("@cod_usu", usuario2.cod_usu);

                cmd.CommandType = CommandType.Text;

                conexion.Open();
                reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    talla = Convert.ToString(reader["desc_talla"]);

                }
                else
                {
                    talla = "";
                }
                reader.Close();
            }
            catch (Exception e)
            {
                // Debug.WriteLine(e.ToString());
                talla = "";
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
            return talla;
        }
    }
}
