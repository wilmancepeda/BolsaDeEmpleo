using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolsaEmpleo.DTO.Job
{
    public class JobByCategoryResponse
    {
        public string CategoryName { get; set; }
        public string Ubication { get; set; }
        public string PositionName { get; set; }
        public string EmployerName { get; set; }
    }
}
