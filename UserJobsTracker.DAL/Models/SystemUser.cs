using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserJobsTracker.DAL.Models
{
    public class SystemUser : IdentityUser
    {
        public int? DefaultBranchId { get; set; }

        [ForeignKey("DefaultBranchId")]
        public virtual Branch Branch { get; set; }
    }
}
