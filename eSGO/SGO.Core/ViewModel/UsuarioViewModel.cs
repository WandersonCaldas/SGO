﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGO.Core.ViewModel
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {
            Perfil = new PerfilViewModel();
            Empresa = new EmpresaViewModel();           
        }

        //tbl_usuario
        [Key]
        public int cod_usuario { get; set; }
        [Required]
        [Display(Name = "Nome")]
        public string txt_usuario { get; set; }
        [Required]
        [Display(Name = "E-mail")]
        [EmailAddress]
        public string txt_email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string txt_senha { get; set; }
        [Required]
        [Display(Name = "Ativo")]
        public int cod_ativo { get; set; }
        [Required]
        [Display(Name = "Perfil")]
        public int cod_perfil { get; set; }
        [Required]
        [Display(Name = "Empresa")]
        public int cod_empresa { get; set; }
        public PerfilViewModel Perfil { get; set; }
        public EmpresaViewModel Empresa { get; set; }
        public string status { get; set; }
        public string mensagem { get; set; }

    }
}
