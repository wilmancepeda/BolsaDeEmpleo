using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
