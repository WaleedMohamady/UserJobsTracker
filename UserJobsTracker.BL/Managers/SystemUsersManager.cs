using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using UserJobsTracker.DAL.Context;
using UserJobsTracker.DAL.Models;

namespace UserJobsTracker.BL.Managers
{
    public class SystemUsersManager : UserManager<SystemUser>
    {
        public SystemUsersManager(IUserStore<SystemUser> store) : base(store) { }
        public static SystemUsersManager Create(IdentityFactoryOptions<SystemUsersManager> options, IOwinContext context)
        {
            var manager = new SystemUsersManager(new UserStore<SystemUser>(context.Get<UserJobsTrackerDbContext>()));
            // Configure validation logic for usernames, passwords, etc.
            return manager;
        }
    }
}
