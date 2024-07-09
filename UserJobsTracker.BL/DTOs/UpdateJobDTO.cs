using System;
using System.ComponentModel.DataAnnotations;

namespace UserJobsTracker.BL.DTOs
{
    public class UpdateJobDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public int BranchId { get; set; }
    }
}
