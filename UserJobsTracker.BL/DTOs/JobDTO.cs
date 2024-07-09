using System;
using UserJobsTracker.DAL.Models;

namespace UserJobsTracker.BL.DTOs
{
    public class JobDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime HireDate { get; set; }
    }
}
