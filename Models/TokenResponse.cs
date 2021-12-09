using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes_Api.Models
{
    public class TokenResponse
    {
        public string Token { get; set; }
    }
}
