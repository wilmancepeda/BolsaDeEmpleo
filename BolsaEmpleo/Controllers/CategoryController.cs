using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BolsaEmpleo.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BolsaEmpleo.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IActionResult> Index()
        {
            return Ok(await _categoryRepository.GetCategories());
        }
    }
}
