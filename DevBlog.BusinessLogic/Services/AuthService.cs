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

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

            //verify password
            //if success, return success response
            //create login endpoint
        }
    }
}
