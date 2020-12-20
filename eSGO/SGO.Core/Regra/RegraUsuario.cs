using AutoMapper;
using SGO.Core.Application.Interfaces;
using SGO.Core.Model;
using SGO.Core.Response;
using SGO.Core.ViewModel;
using System;
using System.Collections.Generic;
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
    }
}
