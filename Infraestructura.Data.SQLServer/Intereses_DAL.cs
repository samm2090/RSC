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
    public class Intereses_DAL
    {
        SqlConnection conexion;
        SqlCommand cmd;

        public String RegistrarIntereses(Usuario usuario, Intereses intereses)
        {

            try
            {
                conexion = new Conexion().Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText = "INSERT INTO tb_Intereses(cod_usu,cod_talla_ran,cod_rasgo,cod_contex,cod_ing,hijos_interes) " +
                                    "VALUES(@cod_usu,@cod_talla_ran,@cod_rasgo,@cod_contex,@cod_ing,@hijos_interes)";
                cmd.Parameters.AddWithValue("@cod_usu", usuario.cod_usu);
                cmd.Parameters.AddWithValue("@cod_talla_ran", intereses.cod_talla_ran);
                cmd.Parameters.AddWithValue("@cod_rasgo", intereses.cod_rasgo);
                cmd.Parameters.AddWithValue("@cod_contex", intereses.cod_contex);
                cmd.Parameters.AddWithValue("@cod_ing", intereses.cod_ing);
                cmd.Parameters.AddWithValue("@hijos_interes", intereses.hijos_interes);

                cmd.CommandType = CommandType.Text;
                conexion.Open();
                cmd.ExecuteNonQuery();

                return "Se registro Intereses";
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
