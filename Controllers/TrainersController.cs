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
        private ILoggerService _logger;
        public TrainersController(ITrainersRepository repo,ILoggerService logger)
        {
            _logger = logger;
            _trainersRepo = repo;
        }

        [HttpPost("signin")]
        public IActionResult signin([FromBody] SigninCredentials credentials)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("400");
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
            throw new Exception("500");
        }

        [HttpPost("signup")]
        public IActionResult signup([FromBody] SignupCredentials credentials)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("400");
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
            throw new Exception("500");
        }

        [HttpGet]
        public ActionResult exaption()
        {
            _logger.LogError("test error");
            throw new Exception("test Exception");
        }
    }
}
