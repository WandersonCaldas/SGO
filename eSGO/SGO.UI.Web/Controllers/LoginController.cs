﻿using SGO.Core.Application.Interfaces;
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
    public class LoginController : Controller
    {
        private IUsuario _usuarioService;                        

        public LoginController()
        {
            _usuarioService = new RegraUsuario();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return Json(new { ok = true }, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            LoginViewModel retorno = new LoginViewModel();            
            retorno = _usuarioService.Autenticar(model);

            if (retorno.Result.status.Equals(ResponseStatus.SUCESSO.Texto))
            {                
                Session["cod_usuario"] = retorno.Usuario.cod_usuario;
                Session["txt_nome"] = retorno.Usuario.txt_usuario;
                Session["txt_email"] = retorno.Usuario.txt_email;
                Session["cod_perfil"] = retorno.Usuario.cod_perfil;
                Session["cod_empresa"] = retorno.Usuario.cod_empresa;
            }
            else if(retorno.Result.status.Equals(ResponseStatus.FALHA.Texto))
            {
                ViewBag.Message = retorno.Result.mensagem;
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }        


        [AllowAnonymous]
        public ActionResult RecuperarSenha()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult RecuperarSenha(RecuperarSenhaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            RecuperarSenhaViewModel retorno = new RecuperarSenhaViewModel();
            retorno = _usuarioService.RecuperarSenha(model.txt_email);

            if (retorno.Result.status.Equals(ResponseStatus.FALHA.Texto))
            {
                ViewBag.Message = retorno.Result.mensagem;
                return View(model);
            }

            ViewBag.Status = retorno.Result.status;
            ViewBag.Message = retorno.Result.mensagem;
            ViewBag.Url = "/Login";
            return View();
        }
    }
}