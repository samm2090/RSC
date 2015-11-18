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
    public class Usuario_DAL
    {
        SqlConnection conexion;
        SqlCommand cmd;
        SqlDataReader reader;

        public String RegistrarUsuario(Usuario usuario, InformacionUsuario informacionUsuario)
        {

            try
            {
                conexion = new Conexion().Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText="INSERT INTO TB_USUARIO(NOM_USU,APEPAT_USU,APEMAT_USU,FECNAC_USU,EMAIL_USU,CONTR_USU,"+
                                "SEXO_USU) VALUES(@NOM,@APEPAT,@APEMAT,@FECNAC,@EMAIL,@CONTR,@SEXO)";
                cmd.Parameters.AddWithValue("@NOM", usuario.nom_usu);
                cmd.Parameters.AddWithValue("@APEPAT", usuario.apePat_usu);
                cmd.Parameters.AddWithValue("@APEMAT", usuario.apeMat_usu);
                cmd.Parameters.AddWithValue("@FECNAC", usuario.fecNac_usu);
                cmd.Parameters.AddWithValue("@EMAIL", usuario.email_usu);
                cmd.Parameters.AddWithValue("@CONTR", usuario.contr_usu);
                cmd.Parameters.AddWithValue("@SEXO", usuario.sexo_usu);

                cmd.CommandType = CommandType.Text;

                conexion.Open();
                cmd.ExecuteNonQuery();

                return "Se registro usuario";                    

            }
            catch(Exception e)
            {
                return e.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();

                conexion = null;
                cmd = null;
            }
                    
        }

        public String ActualizarUsuario(Usuario usuario)
        {
            try
            {

                conexion = new Conexion().Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText = "UPDATE TB_USUARIO SET nom_usu=@nom_usu, apePat_usu=@apePat_usu,apeMat_usu=@apeMat_usu," +
                                  "fecNac_usu=@fecNac_usu,email_usu=@email_usu,contr_usu=@contr_usu,sexo_usu=@sexo_usu "+
                                  "WHERE cod_usu=@cod_usu";
                cmd.Parameters.AddWithValue("@nom_usu", usuario.nom_usu);
                cmd.Parameters.AddWithValue("@apePat_usu", usuario.apePat_usu);
                cmd.Parameters.AddWithValue("@apeMat_usu", usuario.apeMat_usu);
                cmd.Parameters.AddWithValue("@fecNac_usu", usuario.fecNac_usu);
                cmd.Parameters.AddWithValue("@email_usu", usuario.email_usu);
                cmd.Parameters.AddWithValue("@contr_usu", usuario.contr_usu);
                cmd.Parameters.AddWithValue("@sexo_usu", usuario.sexo_usu);
                cmd.Parameters.AddWithValue("@cod_usu", usuario.cod_usu);

                cmd.CommandType = CommandType.Text;

                conexion.Open();
                cmd.ExecuteNonQuery();
                return "Se actualizo usuario";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();

                conexion = null;
                cmd = null;
            }
        }

        public String DesactivarUsuario(Usuario usuario)
        {
            try
            {
                conexion = new Conexion().Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText = "UPDATE TB_USUARIO SET cod_estCue=0 WHERE cod_usu=@cod_usu";
                cmd.Parameters.AddWithValue("@cod_usu", usuario.cod_usu);
                cmd.CommandType = CommandType.Text;

                conexion.Open();
                cmd.ExecuteNonQuery();
                return "Se desactivo usuario";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();

                conexion = null;
                cmd = null;
            }
        }

    }
}
