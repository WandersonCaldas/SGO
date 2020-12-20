using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGO.Core.Response
{
    public class ResponseMensagem
    {
        public static readonly ResponseMensagem MN001 = new ResponseMensagem("MN001", "USUÁRIO E/OU SENHA INVÁLIDOS.");
        public static readonly ResponseMensagem MN002 = new ResponseMensagem("MN002", "USUÁRIO NÃO ENCONTRADO.");
        public static readonly ResponseMensagem MN003 = new ResponseMensagem("MN003", "{0} INVÁLIDO.");
        public static readonly ResponseMensagem MN004 = new ResponseMensagem("MN004", "{0} JÁ ESTÁ CADASTRADO.");
        public static readonly ResponseMensagem MN005 = new ResponseMensagem("MN005", "{0} INVÁLIDO.");
        public static readonly ResponseMensagem MN006 = new ResponseMensagem("MN006", "{0} INVÁLIDA.");
        public static readonly ResponseMensagem MN007 = new ResponseMensagem("MN007", "{0} JÁ ESTÁ CADASTRADA.");
        public static readonly ResponseMensagem MN008 = new ResponseMensagem("MN008", "DESEJA SAIR DO SISTEMA?");
        public static readonly ResponseMensagem MN009 = new ResponseMensagem("MN009", "SENHA ENVIADA PARA O E-MAIL INFORMADO.");
        public static readonly ResponseMensagem MN010 = new ResponseMensagem("MN010", "Sistema de Gestão de Ocorrências");
        public static readonly ResponseMensagem MN011 = new ResponseMensagem("MN011", "SGO");
        public static readonly ResponseMensagem MN012 = new ResponseMensagem("MN012", "SENHA ALTERADA COM SUCESSO.");

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
