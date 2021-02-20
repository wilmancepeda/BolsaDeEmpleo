using BolsaEmpleo.DTO.Job;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolsaEmpleo.Models
{
    public partial class BolsaEmpleoContext : DbContext
    {
        public DbSet<JobByCategoryResponse> JobByCategory { get; set; }
    
    }
}
