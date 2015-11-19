using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Core.Entities
{
    public class CualidadesInteres
    {
        [DisplayName("Codigo de usuario")]
        public int cod_usu { get; set; }

        [DisplayName("Codigo de cualidad")]
        public int cod_cua { get; set; }
    }
}
