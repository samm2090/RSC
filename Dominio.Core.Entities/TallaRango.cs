using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Core.Entities
{
    public class TallaRango
    {

        [DisplayName("Codigo del rango de la talla")]
        public int cod_talla_ran { get; set; }


        [DisplayName("Descripcion del rango de la talla")]
        public String desc_talla_ran { get; set; }
        
    }
}
