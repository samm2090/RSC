using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Core.Entities
{
    public class Mensaje
    {

        [DisplayName("Codigo del mensaje")]
        public int cod_mens { get; set; }
        
        [DisplayName("Codigo de usuario")]
        public int cod_usu1 { get; set; }

        [DisplayName("Codigo del usuario")]
        public int cod_usu2 { get; set; }

        [DisplayName("Codigo del usuario")]
        public int cod_usu3 { get; set; }

        [DisplayName(" Mensaje")]
        [Required(ErrorMessage = "Mensaje ingresar mensaje")]
        public String mensaje { get; set; }

        [DisplayName("Fecha del mensaje")]
        public DateTime fecha_mens { get; set; }    

    }
}
