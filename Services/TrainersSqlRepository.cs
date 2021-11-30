using Heroes_Api.Contracts;
using Heroes_Api.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes_Api.Services
{
    public class TrainersSqlRepository : ITrainersRepository
    {
        public Task<SecurityToken> signin(SigninCredentials credentials)
        {
            throw new NotImplementedException();
        }

        public Task<SecurityToken> signup(SignupCredentials credentials)
        {
            throw new NotImplementedException();
        }
    }
}
