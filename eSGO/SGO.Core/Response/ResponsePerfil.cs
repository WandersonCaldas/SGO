using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGO.Core.Response
{
    public class ResponsePerfil
    {
        public static readonly ResponsePerfil ADMINISTRADOR = new ResponsePerfil(1, "ADMINISTRADOR");
        public static readonly ResponsePerfil EMPRESA = new ResponsePerfil(2, "EMPRESA");        

        private int _codigo;
        private string _txt;

        private ResponsePerfil(int codigo, string txt)
        {
            _codigo = codigo;
            _txt = txt;
        }

        public ResponsePerfil()
        {
        }

        public int Codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                _codigo = value;
            }
        }

        public string Texto
        {
            get
            {
                return _txt;
            }

            set
            {
                _txt = value;
            }
        }
    }
}
