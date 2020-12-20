using SGO.Core.Application.AutoMapper;
using SGO.UI.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;

namespace SGO.UI.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutoMapperConfig.RegisterMappings();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.Add(
                typeof(decimal), new DecimalModelBinder());
            ModelBinders.Binders.Add(
                typeof(decimal?), new DecimalModelBinder());
        }
    }
}
