using BolsaEmpleo.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolsaEmpleo.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        IPositionRepository _positionRepository;

        public PositionController(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        [Route("byCategory/{categoryId}")]
        public async Task<IActionResult> GetpositionsByCategoryId(int categoryId)
        {
            var response = await _positionRepository.GetPositions(categoryId);

            if (response.Ok)
            {
                return Ok(response.Data);
            }

            return BadRequest(response.Mensaje);
        }
    }
}
