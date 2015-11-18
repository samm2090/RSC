using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Core.Entities
{
    public class Actividad
    {
        [DisplayName("Codigo de actividad")]
        public int cod_act { get; set; }

        [DisplayName("Descripcion de actividad")]
        public String desc_act { get; set; }
    }
}
