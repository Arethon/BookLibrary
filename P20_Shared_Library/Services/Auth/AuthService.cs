using P20_Shared_Library.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P20_Shared_Library.Services.Auth
{
    public class AuthService : IAuthService
    {
        public Task<ServiceResponse<bool>> ChangePassword(string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<string>> Login(UserLoginDto userLoginDto)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<int>> Register(UserRegisterDto userLoginDto)
        {
            throw new NotImplementedException();
        }
    }
}
