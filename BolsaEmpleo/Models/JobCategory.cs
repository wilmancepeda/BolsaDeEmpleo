using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BolsaEmpleo.Models
{
    public partial class JobCategory
    {
        public JobCategory()
        {
            JobCategoryJobPosition = new HashSet<JobCategoryJobPosition>();
        }

        public int IdCategory { get; set; }
        public string CategoryName { get; set; }
        public string Status { get; set; }

        public virtual ICollection<JobCategoryJobPosition> JobCategoryJobPosition { get; set; }
    }
}
