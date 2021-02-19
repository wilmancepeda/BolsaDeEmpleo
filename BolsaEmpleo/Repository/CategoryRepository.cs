using BolsaEmpleo.DTO.Comun;
using BolsaEmpleo.IRepository;
using BolsaEmpleo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolsaEmpleo.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BolsaEmpleoContext _db;

        public CategoryRepository(BolsaEmpleoContext db)
        {
            _db = db;
        }
        public async Task<Response<List<JobCategory>>> GetCategories()
        {
            var response = new Response<List<JobCategory>>();

            try
            {
                response.Data = await _db.JobCategory.ToListAsync();
                response.Ok = true;

                return response;
            }
            catch (Exception)
            {
                response.Ok = false;
                response.Mensaje = "Ops! Algo inesperado ha ocurrido. Favor inténtelo más tarde";

                return response;
            }
        }
    }
}
