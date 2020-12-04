using BlazorBattle.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattle.Client.Services
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Regsiter(UserRegister request);
    }
}
