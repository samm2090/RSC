﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Dominio.Core.Entities
{
    public class Foto
    {   
        [DisplayName("Codigo de usuario")]
        public int cod_usu { get; set; }

        [DisplayName("Codigo de foto")]
        public int cod_foto { get; set; }

        [DisplayName("Ruta")]
        public String ruta { get; set; }

    }
}
