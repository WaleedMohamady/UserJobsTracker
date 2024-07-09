using System;
using System.ComponentModel.DataAnnotations;

namespace UserJobsTracker.BL.DTOs
{
    public class CreateJobDTO
    {
        [Required]
        [MaxLength(50, ErrorMessage ="Maximum Length is 50")]
        public string Name { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public int BranchId { get; set; }
    }
}
