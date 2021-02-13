using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BolsaEmpleo.Models
{
    public partial class Job
    {
        public Job()
        {
            JobCategoryPosition = new HashSet<JobCategoryPosition>();
        }

        public int IdJob { get; set; }
        public int CategoryId { get; set; }
        public int EmployerId { get; set; }
        public int PositionId { get; set; }
        public string JobName { get; set; }
        public string JobType { get; set; }
        public string Ubication { get; set; }
        public string Description { get; set; }
        public string HowApply { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Status { get; set; }

        public virtual Employer Employer { get; set; }
        public virtual ICollection<JobCategoryPosition> JobCategoryPosition { get; set; }
    }
}
