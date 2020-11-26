using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using podcast_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace podcast_web.App_Start
{
    public class IdentityConfig
    {
        //public void Configuration(IAppBuilder app)
        //{
        //    app.CreatePerOwinContext(() => new PodcastLibContext());
        //    app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
        //    app.CreatePerOwinContext<RoleManager<Role>>((options, context) =>
        //        new RoleManager<Role>(
        //            new RoleStore<Role>(context.Get<PodcastLibContext>()));

        //    app.UseCookieAuthentication(new CookieAuthenticationOptions
        //    {
        //        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        //        LoginPath = new PathString("/Auth/Login"),
        //    });
        //}
    }
}