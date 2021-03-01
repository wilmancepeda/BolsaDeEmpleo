using BolsaEmpleo.DTO.Seguridad;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BolsaEmpleo.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class CuentaController : Controller
    {
        //private UserManager<IdentityUser> _userManager;
        //private IConfiguration _configuration;
        //private SignInManager<IdentityUser> _signInManager;

        //public CuentaController(UserManager<IdentityUser> userManager, IConfiguration configuration, SignInManager<IdentityUser> signInManager)
        //{
        //    _userManager = userManager;
        //    _configuration = configuration;
        //    _signInManager = signInManager;
        //}

        //[Route("create")]
        //public async Task<ActionResult<AutenticationResponse>> Create([FromBody] UserCredential credential)
        //{
        //    var user = new IdentityUser { UserName = credential.Email, Email = credential.Email };

        //    var result = await _userManager.CreateAsync(user, credential.Password);

        //    if (result.Succeeded)
        //    {
        //        return await CreateToken(credential);
        //    }
        //    else
        //    {
        //        return BadRequest(result.Errors);
        //    }

        //}

        //[Route("login")]
        //public async Task<ActionResult<AutenticationResponse>> Login([FromBody] UserCredential credential)
        //{
            
        //    var result = await _signInManager.PasswordSignInAsync(credential.Email, credential.Password,
        //                                            isPersistent: false, lockoutOnFailure:false);

        //    if (result.Succeeded)
        //    {
        //        return await CreateToken(credential);
        //    }
        //    else
        //    {
        //        return BadRequest("Login incorrecto");
        //    }

        //}
        //public async Task<ActionResult<AutenticationResponse>> CreateToken(UserCredential credential)
        //{
        //    var claims = new List<Claim>()
        //    {
        //        new Claim("Email", credential.Email)
        //    };

        //    var user = await _userManager.FindByEmailAsync(credential.Email);
            
        //    var claimDb = await _userManager.GetClaimsAsync(user);
        //    claims.AddRange(claimDb);

        //    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["JwtKey"]));

        //    var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var expiration = DateTime.UtcNow.AddYears(1);

        //    var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiration, signingCredentials: cred);

        //    return new AutenticationResponse {
        //         Token = new JwtSecurityTokenHandler().WriteToken(token),
        //         Expiration = expiration
        //    };
        //}
    }
}
