using BolsaEmpleo.DTO.Category;
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
        public async Task<Response<List<GetCategoriesResponse>>> GetCategories()
        {
            var response = new Response<List<GetCategoriesResponse>>();

            try
            {
                response.Data = await _db.JobCategory.Select(c =>  new GetCategoriesResponse() { IdCategory = c.IdCategory, CategoryName = c.CategoryName }).ToListAsync();

                response.Ok = true;
                
                return response;
            }
            catch (Exception e)
            {
                response.Ok = false;
                //response.Mensaje = "Ops! Algo inesperado ha ocurrido. Favor inténtelo más tarde";
                response.Mensaje = e.Message;
                return response;
            }
        }
    }
}
