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
    public class JobController : Controller
    {
        IJobRepository _jobRepository;

        public JobController(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        //[Route("index")]
        public async Task<IActionResult> Index()
        {
            var reponse = await _jobRepository.GetJobsForJobIndex();

            if (reponse.Ok)
            {
                return Ok(reponse.Data);
            }

            return BadRequest(reponse.Mensaje);
        }

        [Route("{query}")]
        public async Task<IActionResult> Index(string query)
        {
            var reponse = await _jobRepository.GetJobsForJobIndex(query);

            if (reponse.Ok)
            {
                return Ok(reponse.Data);
            }

            return BadRequest(reponse.Mensaje);
        }
    }
}
