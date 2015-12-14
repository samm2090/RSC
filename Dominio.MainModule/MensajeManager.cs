using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.Data.SQLServer;
using Dominio.Core.Entities;

namespace Dominio.MainModule
{
    public class MensajeManager
    {
        Mensaje_DAL mensajeDAL = new Mensaje_DAL();


        public String EnviarMensaje(Mensaje mensaje)
        {
            return mensajeDAL.EnviarMensaje(mensaje);
        }

        public List<Mensaje> listarMensajes(Mensaje mensaje)
        {
            return mensajeDAL.listarMensajes(mensaje);
        }
    }
}
