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
    public class InformacionUsuario_DAL
    {
        SqlConnection conexion;
        SqlCommand cmd;
        SqlDataReader reader;

        public String RegistrarInformacionUsuario(Usuario usuario,InformacionUsuario informacionUsuario){

            try{
                conexion = new Conexion().Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText="INSERT INTO tb_Informacion_Usuario(cod_usu,cod_talla,cod_estCiv,cod_rasgo,cod_contex,cod_ing,cod_act,"+
                                "hijos_usu) INTO(@cod_usu,@cod_talla,@cod_estCiv,@cod_rasgo,@cod_contex,@cod_ing,@cod_act)";
                cmd.Parameters.AddWithValue("@cod_usu", usuario.cod_usu);
                cmd.Parameters.AddWithValue("@cod_talla", informacionUsuario.cod_talla);
                cmd.Parameters.AddWithValue("@cod_estCiv", informacionUsuario.cod_estCiv);
                cmd.Parameters.AddWithValue("@cod_rasgo", informacionUsuario.cod_rasgo);
                cmd.Parameters.AddWithValue("@cod_contex", informacionUsuario.cod_contex);
                cmd.Parameters.AddWithValue("@cod_ing",informacionUsuario.cod_ing);
                cmd.Parameters.AddWithValue("@cod_act", informacionUsuario.cod_act);

                cmd.CommandType = CommandType.Text;
                conexion.Open();
                cmd.ExecuteNonQuery();

                return "Se registro informacion del usuario";
            }
            catch(Exception e){

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
