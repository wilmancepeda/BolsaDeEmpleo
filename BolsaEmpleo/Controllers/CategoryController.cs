using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BolsaEmpleo.DTO.Category;
using BolsaEmpleo.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BolsaEmpleo.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [Route("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var response = await _categoryRepository.GetCategories();

            if (response.Ok)
            {
                return Ok(response.Data);
            }

            return BadRequest(response.Mensaje);
        }

        [Route("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var response = await _categoryRepository.GetCategoy(id);

            if (response.Ok)
            {
                return Ok(response.Data);
            }

            return BadRequest(response.Mensaje);
        }

        [Route("edit/{id}")]
        [HttpPost]
        public async Task<IActionResult> EditCategory(GetCategoriesResponse request)
        {
            var response = await _categoryRepository.Edit(request);

            if (response.Ok)
            {
                return Ok(response.Data);
            }

            return BadRequest(response.Mensaje);
        }

        [Route("delete/{id}")]
        [HttpPost]
        public async Task<IActionResult> EditCategory(int id)
        {
            var response = await _categoryRepository.Delete(id);

            if (response.Ok)
            {
                return Ok(response.Data);
            }

            return BadRequest(response.Mensaje);
        }
    }
}
