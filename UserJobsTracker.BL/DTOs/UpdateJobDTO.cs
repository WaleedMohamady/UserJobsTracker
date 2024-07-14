using System;
using System.ComponentModel.DataAnnotations;

namespace UserJobsTracker.BL.DTOs
{
    public class UpdateJobDTO
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        public DateTime? LeaveDate { get; set; }

        [Required]
        public int BranchId { get; set; }
        public string CreatedById { get; set; }
    }
}
