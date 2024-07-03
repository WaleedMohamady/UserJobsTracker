using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using UserJobsTracker.DAL.Models;

namespace UserJobsTracker.DAL.Context
{
    public class UserJobsTrackerDbContext : IdentityDbContext<SystemUser>
    {
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public UserJobsTrackerDbContext() : base("DefaultConnection") { }
        public static UserJobsTrackerDbContext Create()
        {
            return new UserJobsTrackerDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SystemUser>().ToTable("SystemUsers");
        }
    }
}
