using DevBlog.BusinessLogic.DTO.Requests;
using DevBlog.BusinessLogic.DTO.Responses;
using DevBlog.BusinessLogic.Interfaces;
using DevBlog.Data.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.BusinessLogic.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<LoginResponse> LoginUser(LoginRequest request)
        {
            LoginResponse loginResponse = new();

            var user = await _userRepository.GetUserByEmail(request.Email);

            if (user == null)
            {
                loginResponse.Success = false;
                loginResponse.Message = "User email does not exist";
                return loginResponse;
            }

            var isPasswordVerified = _passwordHasher.VerifyPassword(request.Password, user.Password);

            if (!isPasswordVerified)
            {
                loginResponse.Success = false;
                loginResponse.Message = "Password is incorrect";
                return loginResponse;                
            }

            loginResponse.Success = true;
            loginResponse.Email = user.Email;
            return loginResponse;
        }
    }
}
