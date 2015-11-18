using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Core.Entities
{
    public class EstadoCuenta
    {   
        [DisplayName("Codigo de estado de cuenta")]
        public int cod_estCue { get; set; }

         [DisplayName("Descripcion de estado de cuenta")]
        public String desc_estCue { get; set; }
       
    }
}
