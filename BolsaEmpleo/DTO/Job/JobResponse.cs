using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolsaEmpleo.DTO.Job
{
    public class JobResponse
    {
        public int IdJob { get; set; }
        public string CategoryName { get; set; }
        public string Ubication { get; set; }
        public string PositionName { get; set; }
        public string EmployerName { get; set; }
        public string Description { get; set; }
        public string HowApply { get; set; }
        public string JobName { get; set; }
        public string JobType { get; set; }
        public string EmployerUbication { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
    }
}
