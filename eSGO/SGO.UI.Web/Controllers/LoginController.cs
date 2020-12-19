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
       
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Index");
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

            return RedirectToAction("Index", "Home");
        }
    }
}