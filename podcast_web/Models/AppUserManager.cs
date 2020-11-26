using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace podcast_web.Models
{
    // : UserManager<User>
    public class AppUserManager 
    {
        //public AppUserManager(IUserStore<User> store)
        //    : base(store)
        //{
        //}

        //// this method is called by Owin therefore this is the best place to configure your User Manager
        //public static AppUserManager Create(
        //    IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        //{
        //    var manager = new AppUserManager(
        //        new UserStore<User>(context.Get<PodcastLibContext>()));

        //    // optionally configure your manager
        //    // ...

        //    return manager;
        //}
    }
    
}
