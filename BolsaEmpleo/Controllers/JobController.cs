using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BolsaEmpleo.DTO.Job;
using BolsaEmpleo.IRepository;
using BolsaEmpleo.Models;
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
            var reponse = await _jobRepository.GetLastJobsForIndex();

            if (reponse.Ok)
            {
                return Ok(reponse.Data);
            }

            return BadRequest(reponse.Mensaje);
        }

        [Route("{query}")]
        public async Task<IActionResult> Index(string query)
        {
            var reponse = await _jobRepository.GetLastJobsForIndex(query);

            if (reponse.Ok)
            {
                return Ok(reponse.Data);
            }

            return BadRequest(reponse.Mensaje);
        }

        [Route("byCategory/{categoryId}")]
        public async Task<IActionResult> GetJobsByCategory(int categoryId)
        {
            var reponse = await _jobRepository.GetJobsByCategory(categoryId);

            if (reponse.Ok)
            {
                return Ok(reponse.Data);
            }

            return BadRequest(reponse.Mensaje);
        }

        [Route("getJob/{id}")]
        public async Task<IActionResult> GetJob(int id)
        {
            var reponse = await _jobRepository.GetJobById(id);

            if (reponse.Ok)
            {
                if (reponse.Data != null)
                {
                    return Ok(reponse.Data);
                }
                
            }

            return BadRequest(reponse.Mensaje);
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> GetJob(CreateJobRequest job)
        {
            var reponse = await _jobRepository.CreateJob(job);

            if (reponse.Ok)
            {
                if (reponse.Data)
                {
                    return Ok(reponse.Mensaje);
                }

            }

            return BadRequest(reponse.Mensaje);
        }

        [Route("delete/{id}")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var reponse = await _jobRepository.Delete(id);

            if (reponse.Data)
            {
                 return Ok(reponse.Mensaje);
            }

            
            return BadRequest(reponse.Mensaje);
        }
    }
}
