﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.Data.SQLServer;
using Dominio.Core.Entities;

namespace Dominio.MainModule
{
    public class UsuarioManager
    {
        Usuario_DAL usuarioDAL = new Usuario_DAL();
        InformacionUsuario_DAL infoUsuDAL = new InformacionUsuario_DAL();
        Intereses_DAL interesesDAL = new Intereses_DAL();
        CualidadesUsuario_DAL cuaUsuDAL = new CualidadesUsuario_DAL();
        CualidadesInteres_DAL cuaIntDAL = new CualidadesInteres_DAL();

        public Boolean ValidarUsuario(Usuario usuario)
        {
            return usuarioDAL.ValidarUsuario(usuario);
        }

        public String RegistrarUsuario(Usuario usuario,InformacionUsuario infoUsu,Intereses intereses,List<Cualidad> cuaUsu,
                                       List<Cualidad> cuaInt)
        {
            try{
            usuarioDAL.RegistrarUsuario(usuario);

            infoUsuDAL.RegistrarInformacionUsuario(usuario,infoUsu);

            interesesDAL.RegistrarIntereses(usuario, intereses);

            cuaUsuDAL.IngresarCualidadesUsuarios(usuario, cuaUsu);

            cuaIntDAL.IngresarCualidadInteres(usuario, cuaInt);

            return "Se regisro usuario";

            }
            catch{
            return "No se registro";
            }
            
        }

        public String RegistrarUsuario(Usuario usuario)
        {
            try
            {
                usuarioDAL.RegistrarUsuario(usuario);

    
                return "Se regisro usuario";

            }
            catch
            {
                return "No se registro";
            }

        }
    }
}