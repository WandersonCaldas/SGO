using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGO.Core.ViewModel
{
    public class EmpresaViewModel
    {
        //tbl_empresa
        [Key]
        public int cod_empresa { get; set; }
        [Required]
        [Display(Name = "Empresa")]
        public string txt_empresa { get; set; }        
        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        public string txt_descricao { get; set; }
        [Required]
        [Display(Name = "Ativo")]
        public int cod_ativo { get; set; }
        public string status { get; set; }
        public string mensagem { get; set; }
    }
}
