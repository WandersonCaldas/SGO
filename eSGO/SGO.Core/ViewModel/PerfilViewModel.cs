﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGO.Core.ViewModel
{
    public class PerfilViewModel
    {
        //tbl_perfil
        [Key]
        public int cod_perfil { get; set; }

        [Required]
        [Display(Name = "Perfil")]
        public string txt_perfil { get; set; }
        [Required]
        [Display(Name = "Ativo")]
        public int cod_ativo { get; set; }
        public string status { get; set; }
        public string mensagem { get; set; }
    }
}
