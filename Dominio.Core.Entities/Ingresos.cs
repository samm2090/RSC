using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Core.Entities
{
    public class Ingresos
    {
        [DisplayName("Codigo de ingresos")]
        public int cod_ing { get; set; }

        [DisplayName("Descripcion de ingresos")]
        public String desc_ing { get; set; }
    }
}
