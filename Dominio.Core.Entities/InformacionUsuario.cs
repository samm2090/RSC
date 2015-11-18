using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Core.Entities
{
    public class InformacionUsuario
    {   
        [DisplayName("Codigo de usuario")]
        public int cod_usu { get; set; }

        [DisplayName("Codigo de talla de usuario")]
        public int cod_talla { get; set; }

        [DisplayName("Codigo de estado civil de usuario")]
        public int cod_estCiv { get; set; }

        [DisplayName("Codigo de rasgo de usuario")]
        public int cod_rasgo { get; set; }

        [DisplayName("Codigo de contextura de usuario")]
        public int cod_contex { get; set; }

        [DisplayName("Codigo de ingresos")]
        public int cod_ing { get; set; }

        [DisplayName("Codigo de actividad de usuario")]
        public int cod_act { get; set; }

        [DisplayName("Numero de hijos de usuario")]
        [Required(ErrorMessage="Ingresar el numero de hijos")]
        public int hijos_usu { get; set; }
    }
}
