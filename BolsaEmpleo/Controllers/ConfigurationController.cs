using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BolsaEmpleo.IRepository;
using BolsaEmpleo.Models;
using BolsaEmpleo.DTO.Configuration;

namespace BolsaEmpleo.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private IConfigurationRepository _configurationRepository;

        public ConfigurationController(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var reponse = await _configurationRepository.GetConfigurations();

            if (reponse.Ok)
            {
                return Ok(reponse.Data);
            }

            return BadRequest(reponse.Mensaje);
        }

        [Route("{id}")]
        public async Task<IActionResult> GetConfiguration(byte id)
        {
            var reponse = await _configurationRepository.GetConfiguration(id);

            if (reponse.Ok & reponse.Data != null)
            {
                return Ok(reponse.Data);
            }

            return BadRequest(reponse.Mensaje);
        }

        [Route("edit/{id}")]
        [HttpPost]
        public async Task<IActionResult> EditConfiguration(ConfigurationEditRequest request)
        {
            var reponse = await _configurationRepository.EditConfiguration(request);

            if (reponse.Ok & reponse.Data)
            {
                return Ok(reponse.Data);
            }

            return BadRequest(reponse.Mensaje);
        }
    }
}
