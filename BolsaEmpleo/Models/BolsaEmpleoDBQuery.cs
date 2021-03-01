using BolsaEmpleo.DTO;
using BolsaEmpleo.DTO.Category;
using BolsaEmpleo.DTO.Job;
using BolsaEmpleo.DTO.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

        public DbSet<JobResponse> JobResponse { get; set; }
        public DbSet<UserReponse> UserReponse { get; set; }
        public DbSet<GetPositionsByCategoryResponse> GetPositionsByCategoryResponse { get; set; }

        //public DbSet<GetCategoriesResponse> GetCategoriesResponse { get; set; }
    }
}
