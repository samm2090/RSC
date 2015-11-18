using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Core.Entities
{
    public class Contextura
    {
        [DisplayName("Codigo de contextura")]
        public int cod_contex { get; set; }

        [DisplayName("Descripcion de contextura")]
        public String desc_contex { get; set; }
    }
}
