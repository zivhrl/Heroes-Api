using Heroes_Api.Contracts;
using Heroes_Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class TrainersController : Controller
    {
        private ITrainersRepository _trainersRepo;
        public TrainersController(ITrainersRepository repo)
        {
            _trainersRepo = repo;
        }

        [HttpPost("signin")]
        public IActionResult signin([FromBody] SigninCredentials credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            SecurityToken token = _trainersRepo.signin(credentials).Result;
            if (token != null)
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                return Ok(new
                {
                    success = true,
                    token = handler.WriteToken(token)
                });
            }
            return Unauthorized();
        }

        [HttpPost("signup")]
        public IActionResult signup([FromBody] SignupCredentials credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            SecurityToken token = _trainersRepo.signup(credentials).Result;
            if (token != null)
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                return Ok(new
                {
                    success = true,
                    token = handler.WriteToken(token)
                });
            }
            return BadRequest();
        }
    }
}
