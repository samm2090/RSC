using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dominio.Core.Entities;


namespace Infraestructura.Data.SQLServer
{
    public class Foto_DAL
    {

        SqlConnection conexion;
        SqlCommand cmd;
        SqlDataReader reader;

        public String InsertarFoto(Foto foto)
        {
            try
            {
                conexion = new Conexion().Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText = "Insert into tb_Foto(cod_usu,cod_foto,ruta) values (@cod_usu,@cod_foto,@ruta)";

                int cod_foto = 1;

                cmd.Parameters.AddWithValue("@cod_usu", foto.cod_usu);
                cmd.Parameters.AddWithValue("@cod_foto", cod_foto);
                cmd.Parameters.AddWithValue("@ruta", foto.ruta);
                cmd.CommandType = CommandType.Text;
                conexion.Open();
                cmd.ExecuteNonQuery();

                return "Se registro foto";

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return "Error en la BD";
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

        }

        public Foto buscarFoto(Usuario usuario)
        {
            Foto foto = new Foto();
            try
            {
                conexion = new Conexion().Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText = "select * from tb_Foto where cod_usu=@cod_usu and cod_foto=1";
                cmd.Parameters.AddWithValue("@cod_usu", usuario.cod_usu);
                cmd.CommandType = CommandType.Text;

                conexion.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    
                    foto.cod_usu = Convert.ToInt32(reader["cod_usu"]);
                    foto.cod_foto = Convert.ToInt32(reader["cod_foto"]);
                    foto.ruta = Convert.ToString(reader["ruta"]);
                }
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
            return foto;
        }
    }
}
