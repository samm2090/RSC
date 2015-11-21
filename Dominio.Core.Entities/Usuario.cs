using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Core.Entities
{
    public class Usuario
    {
        [DisplayName("Código de usuario")]
        public int cod_usu { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage="Nombre obligatorio")]
        [StringLength(50,MinimumLength=2,ErrorMessage="No mas de 50 caracteres" )]
        public String nom_usu { get; set; }

        [DisplayName("Apelllido paterno")]
        [Required(ErrorMessage = "Apellido paterno obligatorio")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "No mas de 50 caracteres")]
        public String apePat_usu { get; set; }

        [DisplayName("Apellido materno")]
        [Required(ErrorMessage = "Apellido materno obligatorio")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "No mas de 50 caracteres")]
        public String apeMat_usu  { get; set; }

        [DisplayName("Fecha de registro")]
        public DateTime fecReg_usu { get; set; }

        [DisplayName("Fecha de nacimiento")]
        [Required(ErrorMessage = "Fecha nacimiento obligatorio")]
        public DateTime fecNac_usu { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email obligatorio")]
        [EmailAddress(ErrorMessage="Email invalido")]
        public String email_usu { get; set; }

        [DisplayName("Contrasena")]
        [Required(ErrorMessage = "Contrasena obligatorio")]
        [StringLength(25, ErrorMessage = "Debe tener maximo 25 caracteres")] //Verificar
       // [StringLength(25,MinimumLength=6,ErrorMessage="Debe tener minimo 6 caracteres")]
        public String contr_usu { get; set; }

        [DisplayName("Sexo")]
        [Required(ErrorMessage = "Sexo obligatorio")]
        public String sexo_usu { get; set; }
            
        [DisplayName("Estado de cuenta")]
        public int cod_estCue { get; set; }

    }
}
