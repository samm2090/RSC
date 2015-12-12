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
                cmd.CommandText = "Insert into tb_Foto(cod_usu,foto) select @cod_usu,bulkcolumn from openrowset " +
                                "(bulk @ruta,single_blob) as BLOB";

                cmd.Parameters.AddWithValue("@cod_usu", foto.cod_usu);
                cmd.Parameters.AddWithValue("@ruta", foto.ruta);
                cmd.CommandType = CommandType.Text;

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
    }
}
