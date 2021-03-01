using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolsaEmpleo.DTO.Job
{
    public class CreateJobRequest
    {
        public int CategoryId { get; set; }
        public int EmployerId { get; set; }
        public int PositionId { get; set; }
        public string JobName { get; set; }
        public string JobType { get; set; }
        public string Ubication { get; set; }
        public string Description { get; set; }
        public string HowApply { get; set; }
    }
}
