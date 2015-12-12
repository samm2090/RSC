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
    public class Usuario_DAL
    {
        SqlConnection conexion;
        SqlCommand cmd;
        SqlDataReader reader;

        public Usuario BuscarUsuario(Usuario usuario)
        {
            Usuario usu = new Usuario();
            try
            {
                conexion = new Conexion().Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText = "SELECT * FROM TB_USUARIO " +
                                    "WHERE email_usu=@email_usu and contr_usu=@contr_usu";
                cmd.Parameters.AddWithValue("@email_usu", usuario.email_usu);
                cmd.Parameters.AddWithValue("@contr_usu", usuario.contr_usu);
                cmd.CommandType = CommandType.Text;

                conexion.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    usu.cod_usu = Convert.ToInt32(reader["cod_usu"]);
                    usu.nom_usu = Convert.ToString(reader["nom_usu"]);
                    usu.apePat_usu = Convert.ToString(reader["apePat_usu"]);
                    usu.apeMat_usu = Convert.ToString(reader["apeMat_usu"]);
                    usu.fecReg_usu = Convert.ToDateTime(reader["fecReg_usu"]);
                    usu.fecNac_usu = Convert.ToDateTime(reader["fecNac_usu"]);
                    usu.email_usu = Convert.ToString(reader["email_usu"]);
                    usu.contr_usu = Convert.ToString(reader["contr_usu"]);
                    usu.sexo_usu = Convert.ToString(reader["sexo_usu"]);
                    usu.cod_estCue = Convert.ToInt32(reader["cod_estCue"]);
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
            return usu;
        }

        public Boolean ValidarUsuario(Usuario usuario)
        {
            try
            {
                conexion = new Conexion().Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText = "SELECT email_usu,contr_usu FROM TB_USUARIO " +
                                "WHERE email_usu=@email_usu and contr_usu=@contr_usu";
                cmd.Parameters.AddWithValue("@email_usu", usuario.email_usu);
                cmd.Parameters.AddWithValue("@contr_usu", usuario.contr_usu);
                cmd.CommandType = CommandType.Text;

                conexion.Open();
                reader = cmd.ExecuteReader();

                String email, contrasena;
                email = Convert.ToString(reader["email_usu"]);
                contrasena = Convert.ToString(reader["contr_usu"]);
                if (usuario.email_usu.Equals(email) && usuario.contr_usu.Equals(contrasena))
                {
                    return true;
                }
                else return false;
            }
            catch(Exception e) {
                Debug.WriteLine(e.ToString());
                return false;
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

        public String RegistrarUsuario(Usuario usuario)
        {
     
            try
            {
                conexion = new Conexion().Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText="INSERT INTO TB_USUARIO(nom_usu,apePat_usu,apeMat_usu,fecNac_usu,email_usu,contr_usu,"+
                                "sexo_usu) VALUES(@nom_usu,@apePat_usu,@apeMat_usu,@fecNac_usu,@email_usu,@contr_usu,@sexo_usu)";
                cmd.Parameters.AddWithValue("@nom_usu", usuario.nom_usu);
                cmd.Parameters.AddWithValue("@apePat_usu", usuario.apePat_usu);
                cmd.Parameters.AddWithValue("@apeMat_usu", usuario.apeMat_usu);
                cmd.Parameters.AddWithValue("@fecNac_usu", usuario.fecNac_usu);
                cmd.Parameters.AddWithValue("@email_usu", usuario.email_usu);
                cmd.Parameters.AddWithValue("@contr_usu", usuario.contr_usu);
                cmd.Parameters.AddWithValue("@sexo_usu", usuario.sexo_usu);
                
                cmd.CommandType = CommandType.Text;

                conexion.Open();
                cmd.ExecuteNonQuery();

                return "Se registro usuario";                    

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
