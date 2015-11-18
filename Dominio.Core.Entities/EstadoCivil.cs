using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Core.Entities
{
    public class EstadoCivil
    {
        [DisplayName("Codigo de estado civil")]
        public int cod_estCiv { get; set; }

        [DisplayName("Descripcion de estado civil")]
        public String desc_estCiv { get; set; }
    }
}
