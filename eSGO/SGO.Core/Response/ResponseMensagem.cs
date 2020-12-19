using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGO.Core.Response
{
    public class ResponseMensagem
    {
        public static readonly ResponseMensagem MN001 = new ResponseMensagem("MN001", "Usuário e/ou senha inválidos.");
        public static readonly ResponseMensagem MN002 = new ResponseMensagem("MN002", "Usuário não encontrado.");
        public static readonly ResponseMensagem MN003 = new ResponseMensagem("MN003", "{0} inválido.");
        public static readonly ResponseMensagem MN004 = new ResponseMensagem("MN004", "{0} já está cadastrado.");
        public static readonly ResponseMensagem MN005 = new ResponseMensagem("MN005", "{0} inválido.");
        public static readonly ResponseMensagem MN006 = new ResponseMensagem("MN006", "{0} inválida.");
        public static readonly ResponseMensagem MN007 = new ResponseMensagem("MN007", "{0} já está cadastrada.");

        private string _codigo, _txt;
        private ResponseMensagem(string codigo, string txt)
        {
            _codigo = codigo;
            _txt = txt;
        }

        public string Codigo
        {
            get
            {
                return _codigo;
            }
        }

        public string Texto
        {
            get
            {
                return _txt;
            }
        }

        public string TextoFormatado(params string[] Args)
        {
            return string.Format(_txt, Args);
        }
    }
}
