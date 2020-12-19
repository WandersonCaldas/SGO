using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGO.Core.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        [EmailAddress]
        public string txt_email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string txt_senha { get; set; }
    }
}
