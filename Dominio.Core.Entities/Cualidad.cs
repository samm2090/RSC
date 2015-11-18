using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Dominio.Core.Entities
{
    public class Cualidad
    {
        [DisplayName("Codigo de cualidad")]
        public int cod_cua { get; set; }

        [DisplayName("Descripcion de cualidad")]
        public String desc_cua { get; set; }
    }
}
