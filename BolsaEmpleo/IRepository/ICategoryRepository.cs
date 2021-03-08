using BolsaEmpleo.DTO.Category;
using BolsaEmpleo.DTO.Comun;
using BolsaEmpleo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolsaEmpleo.IRepository
{
    public interface ICategoryRepository
    {
        public Task<Response<List<GetCategoriesResponse>>> GetCategories();
        public Task<Response<bool>> Edit(GetCategoriesResponse request);
        public Task<Response<GetCategoriesResponse>> GetCategoy(int id);
        public Task<Response<bool>> Delete(int id);

    }
}
