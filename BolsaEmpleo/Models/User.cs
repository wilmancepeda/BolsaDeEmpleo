using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BolsaEmpleo.Models
{
    public partial class User
    {
        public User()
        {
            Employer = new HashSet<Employer>();
        }

        public int IdUser { get; set; }
        public byte UserTypeId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserLogin { get; set; }
        public string Password { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual UserType UserType { get; set; }
        public virtual ICollection<Employer> Employer { get; set; }
    }
}
