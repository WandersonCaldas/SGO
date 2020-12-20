using SGO.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGO.Core.Application.Interfaces
{
    public interface IUsuario
    {        
        LoginViewModel Autenticar(LoginViewModel obj);
        RecuperarSenhaViewModel RecuperarSenha(string email);
        RecuperarSenhaViewModel AtualizarSenha(string email, string senha);        
    }
}
