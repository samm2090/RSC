using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Core.Entities
{
    public class Rasgo
    {
        [DisplayName("Código de rasgo")]
        public int cod_rasgo { get; set; }

        [DisplayName("Descripción de rasgo")]
        [Required(ErrorMessage="Debe Ingresar el rasgo")]
        [StringLength(30,MinimumLength=2,ErrorMessage="No más de 30 carácteres")]
        public String desc_rasgo { get; set; }
    }

}
