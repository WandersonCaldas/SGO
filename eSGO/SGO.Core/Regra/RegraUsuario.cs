using AutoMapper;
using SGO.Core.Application.Interfaces;
using SGO.Core.Model;
using SGO.Core.Response;
using SGO.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGO.Core.Regra
{
    public class RegraUsuario : IUsuario
    {
        private Repository.tbl_usuario _db = new Repository.tbl_usuario();
        public LoginViewModel Autenticar(LoginViewModel obj)
        {
            List<UsuarioViewModel> usuarios = new List<UsuarioViewModel>();
            usuarios = Mapper.Map<List<UsuarioViewModel>>(_db.Listar().Where(x => x.txt_email == obj.txt_email.Trim()));

            if (usuarios.Count == 0)
            {
                obj.Result.status = ResponseStatus.FALHA.Texto;
                obj.Result.mensagem = ResponseMensagem.MN002.Texto;
                return obj;
            } else
            {
                if (usuarios.Where(x => x.txt_senha == obj.txt_senha.Trim()).Count() == 0)
                {
                    obj.Result.status = ResponseStatus.FALHA.Texto;
                    obj.Result.mensagem = ResponseMensagem.MN006.TextoFormatado("SENHA");
                    return obj;
                }
                else if (usuarios.Where(x => x.cod_ativo == ResponseAtivo.INATIVO.Codigo).Count() > 0)
                {
                    obj.Result.status = ResponseStatus.FALHA.Texto;
                    obj.Result.mensagem = ResponseMensagem.MN003.TextoFormatado("USUÁRIO");
                    return obj;
                }
            }

            obj.Usuario = Mapper.Map<UsuarioViewModel>(_db.Consultar(usuarios[0].cod_usuario));
            obj.Result.status = ResponseStatus.SUCESSO.Texto;
            return obj;
        }        

        public RecuperarSenhaViewModel AtualizarSenha(string email, string senha)
        {
            RecuperarSenhaViewModel retorno = new RecuperarSenhaViewModel();

            try
            {
                tbl_usuario obj = new tbl_usuario();
                obj.txt_email = email;
                obj.txt_senha = senha;

                _db.AtualizarSenha(obj);
            }
            catch (Exception ex)
            {
                retorno = new RecuperarSenhaViewModel();
                retorno.Result.status = ResponseStatus.FALHA.Texto;
                retorno.Result.mensagem = ex.Source + " - " + ex.Message + " - " + ex.StackTrace;
                return retorno;
            }

            retorno = new RecuperarSenhaViewModel();
            retorno.Result.status = ResponseStatus.SUCESSO.Texto;
            return retorno;
        }

        public RecuperarSenhaViewModel RecuperarSenha(string email)
        {
            RecuperarSenhaViewModel obj = new RecuperarSenhaViewModel();
            List<UsuarioViewModel> usuarios = new List<UsuarioViewModel>();
            usuarios = Mapper.Map<List<UsuarioViewModel>>(_db.Listar().Where(x => x.txt_email == email.Trim()));

            if (usuarios.Count == 0)
            {
                obj.Result.status = ResponseStatus.FALHA.Texto;
                obj.Result.mensagem = ResponseMensagem.MN002.Texto;
                return obj;
            }

            string senha = Guid.NewGuid().ToString().Substring(1, 6);
            
            RecuperarSenhaViewModel retornoUsuario = new RecuperarSenhaViewModel();
            retornoUsuario = AtualizarSenha(email, senha.ToString());
            if (!retornoUsuario.Result.status.Equals("SUCESSO"))
            {
                obj = new RecuperarSenhaViewModel();
                obj.Result.status = retornoUsuario.Result.status;
                obj.Result.mensagem = retornoUsuario.Result.mensagem;
                return obj;
            }

            string txt_mensagem = "<div align='card' class='form-control' width='80%'>";
            txt_mensagem += "<div class='card-body'>";           
            txt_mensagem += "<h4 class='card-title'>" + Response.ResponseMensagem.MN011.Texto + " - " + Response.ResponseMensagem.MN010.Texto + "</h4> ";
            txt_mensagem += "<p class='card-text'>";
            txt_mensagem += "<b>E-mail:</b> " + email.Trim();
            txt_mensagem += "<br /><b>Senha:</b> " + senha;
            txt_mensagem += "<br /><b>Acesse:</b> <a href='" + ConfigurationManager.AppSettings["endereco_aplicacao"] + "/Login' target='_blank' class='card-link'>" + Response.ResponseMensagem.MN011.Texto + " - " + Response.ResponseMensagem.MN010.Texto + "</a>";
            txt_mensagem += "</p>";            
            txt_mensagem += "<br /<br />Este é um e-mail automático, por favor não responder.";
            txt_mensagem += "</div>";

            Application.Util.Email.EnviarEmail(Response.ResponseMensagem.MN011.Texto, email.Trim(), Response.ResponseMensagem.MN011.Texto + " - Recuperar senha", txt_mensagem);

            obj.Result.status = ResponseStatus.SUCESSO.Texto;
            obj.Result.mensagem = ResponseMensagem.MN009.Texto;
            return obj;
        }
    }
}
