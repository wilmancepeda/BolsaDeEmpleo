using BolsaEmpleo.DTO.Category;
using BolsaEmpleo.DTO.Comun;
using BolsaEmpleo.IRepository;
using BolsaEmpleo.Models;
using Microsoft.Data.SqlClient;
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

        public async Task<Response<GetCategoriesResponse>> GetCategoy(int id)
        {
            var response = new Response<GetCategoriesResponse>();

            try
            {
                var categories = await _db.JobCategory.Where(c => c.IdCategory == id)
                    .Select(c => new GetCategoriesResponse() { IdCategory = c.IdCategory, CategoryName = c.CategoryName })
                    .ToListAsync();

                response.Data = categories.FirstOrDefault();
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

        public async Task<Response<List<GetCategoriesResponse>>> GetCategories()
        {
            var response = new Response<List<GetCategoriesResponse>>();

            try
            {
                response.Data = await _db.JobCategory.Where(c => c.Status == "A")
                                    .Select(c =>  new GetCategoriesResponse() { IdCategory = c.IdCategory, CategoryName = c.CategoryName })
                                    .ToListAsync();

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

        public async Task<Response<bool>> Edit(GetCategoriesResponse request)
        {
            var response = new Response<bool>();

            try
            {
                var categories = await _db.JobCategory.Where(c => c.IdCategory == request.IdCategory)
                                            .ToListAsync();

                var category = categories.FirstOrDefault();
                category.CategoryName = request.CategoryName;

                _db.JobCategory.Update(category);

                int result = await _db.SaveChangesAsync();

                if (result > 0)
                {
                    response.Data = true;
                    response.Ok = true;
                    response.Mensaje = "Actualizado correctamente";
                    return response;
                }

                response.Data = false;
                response.Ok = true;
                response.Mensaje = "No se pudo actualizar. Por favor, inténte nuevamente";
                
                return response;
            }
            catch (Exception e)
            {
                response.Ok = false;
                response.Data = false;
                //response.Mensaje = "Ops! Algo inesperado ha ocurrido. Favor inténtelo más tarde";
                response.Mensaje = e.Message;
                return response;
            }
        }

        public async Task<Response<bool>> Delete(int id)
        {
            var response = new Response<bool>();

            try
            {
                var result = await _db.Database.ExecuteSqlRawAsync("inactiveCategory @id",
                new SqlParameter("@id", id));

                if (result > 0)
                {
                    response.Data = true;
                    response.Mensaje = "Eliminado con exito";
                    response.Ok = true;
                    return response;
                }

                response.Data = false;
                response.Mensaje = "No se pudo eliminar. Por favor, inténte nuevamente";
                response.Ok = true;

                return response;
            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;
                response.Ok = false;
                response.Data = false;
                return response;
            }
        }
    }
}
