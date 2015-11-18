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
    public class EstadoCuenta_DAL
    {
        SqlConnection conexion;
        SqlCommand cmd;
        SqlDataReader reader;

        public EstadoCuenta BuscarEstado(EstadoCuenta estadoCuenta){
            try
            {
                conexion = new Conexion().Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion;


                cmd.CommandText = "SELECT * FROM tb_Estado_Cuenta WHERE cod_estCue=@cod_estCue";
                cmd.Parameters.AddWithValue("@cod_estCue", estadoCuenta.cod_estCue);
              


                cmd.CommandType = CommandType.Text;
                conexion.Open();
                reader = cmd.ExecuteReader();

                EstadoCuenta estado = new EstadoCuenta();


                estado.cod_estCue = Convert.ToInt32(reader["cod_estCue"]);
                estado.desc_estCue = Convert.ToString(reader["desc_estCue"]);

                reader.Close();

                return estado;
               }
            catch(Exception e)
            {
                Console.Write(e.Message);
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
            return null;
        }
        


   
    }
}
