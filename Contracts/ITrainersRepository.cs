using Heroes_Api.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes_Api.Contracts
{
    public interface ITrainersRepository
    {
        Task<SecurityToken> signin(SigninCredentials credentials);
        Task<SecurityToken> signup(SignupCredentials credentials);
    }
}
