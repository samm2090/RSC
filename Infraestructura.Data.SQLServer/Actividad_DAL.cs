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
    public class Actividad_DAL
    {
        SqlConnection conexion;
        SqlCommand cmd;
        SqlDataReader reader;
  
        public IEnumerable<Actividad> ListarActividades()
        {
            List<Actividad> actividades = new List<Actividad>();

            try
            {
                conexion = new Conexion().Conectar() ;
                cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText="SELECT * FROM TB_ACTIVIDAD";
                cmd.CommandType = CommandType.Text;

                conexion.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Actividad actividad = new Actividad();
                 
                    actividad.cod_act = Convert.ToInt32(reader["cod_act"]);
                    actividad.desc_act = Convert.ToString(reader["desc_act"]);

                    actividades.Add(actividad);
                }
                reader.Close();
            }
            catch(Exception e)
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
          
            return actividades;
        }
    }
}
