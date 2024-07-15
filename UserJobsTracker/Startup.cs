using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Web.Mvc;
using UserJobsTracker.App_Start;
using UserJobsTracker.BL.Managers;
using UserJobsTracker.DAL.Context;

namespace UserJobsTracker
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Autofac Configuration
            var container = AutofacConfig.RegisterDependencies();

            // Other OWIN configuration
            app.CreatePerOwinContext(UserJobsTrackerDbContext.Create);
            app.CreatePerOwinContext<SystemUsersManager>(SystemUsersManager.Create);

            // DateTime ModelBinder
            ModelBinders.Binders.Add(typeof(DateTime), new DateTimeModelBinder());
            ModelBinders.Binders.Add(typeof(DateTime?), new DateTimeModelBinder());

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Users/Login"),
                ExpireTimeSpan = TimeSpan.FromDays(1),
            });
        }
    }
}