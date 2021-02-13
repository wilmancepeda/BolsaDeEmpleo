using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BolsaEmpleo.Models
{
    public partial class JobPosition
    {
        public JobPosition()
        {
            JobCategoryJobPosition = new HashSet<JobCategoryJobPosition>();
        }

        public int IdPosition { get; set; }
        public string PositionName { get; set; }
        public string Status { get; set; }

        public virtual ICollection<JobCategoryJobPosition> JobCategoryJobPosition { get; set; }
    }
}
