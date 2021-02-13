using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BolsaEmpleo.Models
{
    public partial class Employer
    {
        public Employer()
        {
            Job = new HashSet<Job>();
        }

        public int IdEmployer { get; set; }
        public int IdUser { get; set; }
        public string EmployerName { get; set; }
        public string Ubication { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Status { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<Job> Job { get; set; }
    }
}
