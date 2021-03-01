using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BolsaEmpleo.IRepository;
using BolsaEmpleo.DTO.User;

namespace BolsaEmpleo.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("getUser/{userLogin}")]
        public async Task<IActionResult> Index(string userLogin)
        {
            var reponse = await _userRepository.GetUser(userLogin);

            if (reponse.Ok)
            {
                return Ok(reponse.Data);
            }

            return BadRequest(reponse.Mensaje);
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserRequest user)
        {
            var reponse = await _userRepository.CreateUser(user);

            if (reponse.Ok)
            {
                if (reponse.Data != null)
                {
                    return Ok(reponse.Data);
                }

            }

            return BadRequest(reponse.Mensaje);
        }
    }
}
