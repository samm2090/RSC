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

        public String EnviarMensaje(Usuario usuario1, Usuario usuario2, Mensaje mensaje)
        {
            try{
            conexion = new Conexion().Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText="INSERT INTO tb_mensaje(cod_usu1,cod_usu2,cod_usu3,mensaje) VALUES"+
                                "(@cod_usu1,@cod_usu2,@cod_usu3,@mensaje)";
                cmd.Parameters.AddWithValue("@cod_usu1", usuario1.cod_usu);
                cmd.Parameters.AddWithValue("@cod_usu2", usuario2.cod_usu);
                cmd.Parameters.AddWithValue("@cod_usu3", usuario1.cod_usu);
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

    }
}
