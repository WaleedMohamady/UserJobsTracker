using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
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

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Users/Login"),
            });
        }
    }

}