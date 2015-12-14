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
    public class Mensaje_DAL
    {
        SqlConnection conexion;
        SqlCommand cmd;
        SqlDataReader reader;

        public String EnviarMensaje(Mensaje mensaje)
        {
            try{
                conexion = new Conexion().Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText="INSERT INTO tb_mensaje(cod_usu1,cod_usu2,mensaje) VALUES"+
                                "(@cod_usu1,@cod_usu2,@mensaje)";
                cmd.Parameters.AddWithValue("@cod_usu1", mensaje.cod_usu1);
                cmd.Parameters.AddWithValue("@cod_usu2", mensaje.cod_usu2);
                cmd.Parameters.AddWithValue("@mensaje", mensaje.mensaje);

                cmd.CommandType = CommandType.Text;

                conexion.Open();
                cmd.ExecuteNonQuery();

                return "Se envio mensaje";                    

            }
            catch(Exception e)
            {
                Debug.WriteLine(e.ToString());
                return "Error en la BD";
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();

                conexion.Dispose();
                cmd.Dispose();
            }

        }

        public String ResponderMensaje(Usuario usuario1, Usuario usuario2, Mensaje mensaje)
        {
            try
            {
                conexion = new Conexion().Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText = "INSERT INTO tb_mensaje(cod_usu1,cod_usu2,cod_usu3,mensaje) VALUES" +
                                 "(@cod_usu1,@cod_usu2,@cod_usu3,@mensaje)";
                cmd.Parameters.AddWithValue("@cod_usu1", usuario1.cod_usu);
                cmd.Parameters.AddWithValue("@cod_usu2", usuario2.cod_usu);
                cmd.Parameters.AddWithValue("@cod_usu3", usuario2.cod_usu);
                cmd.Parameters.AddWithValue("@mensaje", mensaje.mensaje);

                cmd.CommandType = CommandType.Text;

                conexion.Open();
                cmd.ExecuteNonQuery();

                return "Se envio mensaje";

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return "Error en la BD";
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();

                conexion.Dispose();
                cmd.Dispose();
            }

        }


        public List<Mensaje> listarMensajes(Mensaje mensaje)
        {
            List<Mensaje> mensajes = new List<Mensaje>();
            try
            {
                conexion = new Conexion().Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText = "pr_listarMensajes";

                cmd.Parameters.AddWithValue("@cod_usu1", mensaje.cod_usu1);
                cmd.Parameters.AddWithValue("@cod_usu2", mensaje.cod_usu2);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Mensaje men = new Mensaje();

                    men.cod_mens = Convert.ToInt32(reader["cod_mens"]);
                    men.cod_usu1 = Convert.ToInt32(reader["cod_usu1"]);
                    men.cod_usu2 = Convert.ToInt32(reader["cod_usu2"]);
                    men.mensaje = Convert.ToString(reader["mensaje"]);
                    men.fecha_mens = Convert.ToDateTime(reader["fecha_mens"]);
                    mensajes.Add(men);
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

            return mensajes;
        }
    }
}
