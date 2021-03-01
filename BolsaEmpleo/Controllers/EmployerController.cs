using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BolsaEmpleo.IRepository;

namespace BolsaEmpleo.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private IEmployerRepository _employerRepository;

        public EmployerController(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }

        [Route("getEmployers")]
        public async Task<IActionResult> GetEmployers()
        {
            var response = await _employerRepository.GetEmployers();

            if (response.Ok)
            {
                return Ok(response.Data);
            }

            return BadRequest(response.Mensaje);
        }
    }
}
