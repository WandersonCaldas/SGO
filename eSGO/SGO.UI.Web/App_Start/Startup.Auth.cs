using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;
using SGO.UI.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SGO.UI.Web
{
    public partial class Startup
    {        
        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {

                CookieManager = new SystemWebCookieManager()
            });

        }
    }
}