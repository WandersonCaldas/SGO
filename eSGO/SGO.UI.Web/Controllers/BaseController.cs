using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace SGO.UI.Web.Controllers
{
    public class BaseController : Controller
    {       
        protected override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("pt-BR");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("pt-BR");

            if (Session["cod_usuario"] == null)
            {
                Session.Abandon();
                filterContext.Result = RedirectToAction("Index", "Login");
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}