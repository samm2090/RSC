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
    public class Actividad_DAL
    {
        Conexion conexion;
        SqlCommand cmd;
        SqlDataReader reader;
  
        public IEnumerable<Actividad> ListarActividades()
        {
            List<Actividad> actividades = new List<Actividad>();

            try
            {
                conexion = new Conexion();
                cmd = new SqlCommand("SELECT * FROM TB_ACTIVIDAD",conexion.Conectar());
                cmd.CommandType = CommandType.Text;

                conexion.Conectar().Open();
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
                Console.Write(e.Message);
            }
            finally
            {
                if (conexion.Conectar().State == ConnectionState.Open)
                {
                    conexion.Conectar().Close();
                }
            }

            conexion.Conectar().Dispose();
            cmd.Dispose();  

            return actividades;
        }
    }
}
