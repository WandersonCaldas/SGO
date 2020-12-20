using SGO.Core.Application.Interfaces;
using SGO.Core.Regra;
using SGO.Core.Response;
using SGO.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGO.UI.Web.Controllers
{
    public class HomeController : BaseController
    {
        private IUsuario _usuarioService;

        public HomeController()
        {
            _usuarioService = new RegraUsuario();
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
                
        public ActionResult AlterarSenha()
        {
            return View();
        }

        [HttpPost]        
        [ValidateAntiForgeryToken]
        public ActionResult AlterarSenha(LoginViewModel model)
        {
            model.txt_email = Session["txt_email"].ToString();

            if (!ModelState.IsValid && model.txt_senha == null)
            {
                return View(model);
            }            

            RecuperarSenhaViewModel retorno = new RecuperarSenhaViewModel();
            retorno = _usuarioService.AtualizarSenha(model.txt_email, model.txt_senha);

            if (retorno.Result.status.Equals(ResponseStatus.FALHA.Texto))
            {
                ViewBag.Message = retorno.Result.mensagem;
                return View(model);
            }
                       
            ViewBag.Status = retorno.Result.status;
            ViewBag.Message = ResponseMensagem.MN012.Texto;
            ViewBag.Url = "/Login";
            Session.Abandon();
            return View();
        }
    }
}