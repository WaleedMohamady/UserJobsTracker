using Autofac.Integration.Mvc;
using Autofac;
using System.Web.Mvc;
using UserJobsTracker.BL.Managers;
using UserJobsTracker.DAL.Context;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using UserJobsTracker.DAL.Models;
using UserJobsTracker.DAL.Repositories;

namespace UserJobsTracker.App_Start
{
    public static class AutofacConfig
    {
        public static IContainer RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            // Register DbContext
            builder.RegisterType<UserJobsTrackerDbContext>().AsSelf().InstancePerRequest();

            // Register UserManager
            builder.RegisterType<SystemUsersManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<BranchesManager>().AsSelf().InstancePerRequest();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerRequest();

            // Register IUserStore<SystemUser>
            builder.RegisterType<UserStore<SystemUser>>().As<IUserStore<SystemUser>>().InstancePerRequest();

            // Register Controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Build the container
            var container = builder.Build();

            // Set the dependency resolver for MVC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }
    }
}