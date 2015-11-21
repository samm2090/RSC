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
    public class CualidadesUsuario_DAL
    {
        SqlConnection conexion;
        SqlCommand cmd;
        
        public String IngresarCualidadesUsuarios(Usuario usuario, List<Cualidad> cualidades)
        {
            try
            {
                conexion = new Conexion().Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.Text;
                conexion.Open();
                foreach (Cualidad cualidad in cualidades)
                {
                    cmd.CommandText = "INSERT INTO tb_Cualidades_Usuario(cod_usu,cod_cua) INTO(@cod_usu,@cod_cua)";
                    cmd.Parameters.AddWithValue("@cod_usu", usuario.cod_usu);
                    cmd.Parameters.AddWithValue("@cod_cua", cualidad.cod_cua);

                    cmd.ExecuteNonQuery();
                }

                return "Se registro cualidades de Interes";
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
