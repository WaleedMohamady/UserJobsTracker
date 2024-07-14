using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserJobsTracker.BL.DTOs
{
    public class UpdateJobNameDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
