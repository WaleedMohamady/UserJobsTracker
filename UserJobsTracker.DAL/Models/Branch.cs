using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserJobsTracker.DAL.Models
{
    public class Branch
    {
        public Branch()
        {
            SystemUsers = new HashSet<SystemUser>();
            Jobs = new HashSet<Job>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public virtual ICollection<SystemUser> SystemUsers { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
