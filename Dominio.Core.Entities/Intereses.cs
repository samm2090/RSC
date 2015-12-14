using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Core.Entities
{
    public class Intereses
    {
        [DisplayName("Codigo de usuario")]
        public int cod_usu { get; set; }

        [DisplayName("Codigo de rango de talla")]
        public int cod_talla_ran { get; set; }

        [DisplayName("Codigo de rasgo")]
        public int cod_rasgo { get; set; }

        [DisplayName("Codigo de contextura")]
        public int cod_contex { get; set; }

        [DisplayName("Interes hijos")]
        public String hijos_interes { get; set; }

        public String ing_interes { get; set; }
                       
    }
}
