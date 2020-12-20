using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGO.Core.Model
{
    public class tbl_usuario
    {
        public tbl_usuario()
        {
            this.tbl_perfil = new tbl_perfil();
            this.tbl_empresa = new tbl_empresa();
        }
        public int cod_usuario{ get; set; }
        public string txt_usuario { get; set; }
        public string txt_email{ get; set; }
        public string txt_senha { get; set; }
        public int cod_ativo { get; set; }
        public int cod_perfil { get; set; }
        public int cod_empresa { get; set; }
        public tbl_perfil tbl_perfil { get; set; }
        public tbl_empresa tbl_empresa { get; set; }
    }
}
