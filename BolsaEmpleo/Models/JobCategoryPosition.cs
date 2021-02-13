using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BolsaEmpleo.Models
{
    public partial class JobCategoryPosition
    {
        public int IdJob { get; set; }
        public int IdCategory { get; set; }
        public int IdPosition { get; set; }

        public virtual JobCategoryJobPosition Id { get; set; }
        public virtual Job IdJobNavigation { get; set; }
    }
}
