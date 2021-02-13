using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BolsaEmpleo.Models
{
    public partial class JobCategoryJobPosition
    {
        public JobCategoryJobPosition()
        {
            JobCategoryPosition = new HashSet<JobCategoryPosition>();
        }

        public int IdCategory { get; set; }
        public int IdPosition { get; set; }

        public virtual JobCategory IdCategoryNavigation { get; set; }
        public virtual JobPosition IdPositionNavigation { get; set; }
        public virtual ICollection<JobCategoryPosition> JobCategoryPosition { get; set; }
    }
}
