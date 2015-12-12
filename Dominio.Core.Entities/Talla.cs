using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Core.Entities
{
    public class Talla
    {

        [DisplayName("Codigo de la talla")]
        public int cod_talla { get; set; }


        [DisplayName("Descripcion de la talla")]
        public String desc_talla { get; set; }

        public int cod_talla_ran { get; set; }
    }
}
