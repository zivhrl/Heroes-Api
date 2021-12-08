using Heroes_Api.Contracts;
using Heroes_Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Heroes_Api.Services
{
    public class TrainersSqlRepository : ITrainersRepository
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private IConfiguration configuration;

        public TrainersSqlRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration config)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            configuration = config;
        }


        public async Task<SecurityToken> signin(SigninCredentials credentials)
        {
            ApplicationUser user = await userManager.FindByNameAsync(credentials.UserName);
            SignInResult signInResult = await signInManager.PasswordSignInAsync(user, credentials.Password, false, false);
            if (signInResult.Succeeded)
            {
                SecurityToken token = generateSecurityToken(user);
                return token;
            }
            throw new Exception("401");
        }

        public async Task<SecurityToken> signup(SignupCredentials credentials)
        {
            ApplicationUser user = new ApplicationUser { UserName = credentials.UserName, Email = credentials.Email };
            IdentityResult result = await userManager.CreateAsync(user, credentials.Password);
            if (result.Succeeded)
            {
                SecurityToken token = generateSecurityToken(user);
                return token;
            }
            throw new Exception("409");
        }

        private SecurityToken generateSecurityToken(ApplicationUser user)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            byte[] secret = Encoding.ASCII.GetBytes(configuration["jwtSecret"]);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Sid, user.Id),
                }),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature),
                Issuer = configuration["jwtIssuer"],
                Audience = configuration["jwtAudiance"]
            };
            SecurityToken token = handler.CreateToken(descriptor);
            return token;
        }
    }
}
