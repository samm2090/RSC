﻿using System;
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
    public class EstadoCivil_DAL
    {
        SqlConnection conexion;
        SqlCommand cmd;
        SqlDataReader reader;

        public IEnumerable<EstadoCivil> ListarEstadosCiviles()
        {
            List<EstadoCivil> estadosCiviles = new List<EstadoCivil>();

            try
            {
                conexion = new Conexion().Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText="SELECT * FROM TB_ESTADOCIVIL";
                cmd.CommandType = CommandType.Text;

                conexion.Open();
                reader = cmd.ExecuteReader();
               
                while (reader.Read())
                {
                    EstadoCivil estadoCivil = new EstadoCivil();

                    estadoCivil.cod_estCiv = Convert.ToInt32(reader["cod_estCiv"]);
                    estadoCivil.desc_estCiv = Convert.ToString(reader["desc_estCiv"]);

                    estadosCiviles.Add(estadoCivil);
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

            return estadosCiviles;
        }


        public string buscarEstCiv(Usuario usuario2)
        {
           String estCiv;
            try
            {
                conexion = new Conexion().Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText = "SELECT desc_estCiv FROM tb_Informacion_Usuario i join tb_estadoCivil t " +
                                  "on i.cod_estCiv = t.cod_estCiv " +
                                  "WHERE cod_usu=@cod_usu";
                cmd.Parameters.AddWithValue("@cod_usu", usuario2.cod_usu);

                cmd.CommandType = CommandType.Text;

                conexion.Open();
                reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    estCiv = Convert.ToString(reader["desc_estCiv"]);

                }
                else
                {
                    estCiv = "";
                }
                reader.Close();
            }
            catch (Exception e)
            {
                // Debug.WriteLine(e.ToString());
                estCiv = "";
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
            return estCiv;
        
        }

    }
}
