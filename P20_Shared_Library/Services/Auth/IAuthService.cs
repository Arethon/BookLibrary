using P20_Shared_Library.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P20_Shared_Library.Services.Auth
{
    public interface IAuthService
    {
        Task<ServiceResponse<string>> Login(UserLoginDto userLoginDto);
        Task<ServiceResponse<int>> Register(UserRegisterDto userLoginDto);

        Task<ServiceResponse<bool>> ChangePassword(string newPassword);
    }
}
