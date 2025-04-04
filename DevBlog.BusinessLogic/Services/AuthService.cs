﻿using DevBlog.BusinessLogic.DTO.Requests;
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
        private readonly ITokenService _tokenService;

        public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task<LoginResponse> LoginUser(LoginRequest request)
        {
            LoginResponse loginResponse = new();

            var user = await _userRepository.GetUserByEmail(request.Email);

            if (user == null)
            {
                loginResponse.Success = false;
                loginResponse.Errors.Add("User email does not exist");
                return loginResponse;
            }

            var isPasswordVerified = _passwordHasher.VerifyPassword(request.Password, user.Password);

            if (!isPasswordVerified)
            {
                loginResponse.Success = false;
                loginResponse.Errors.Add("Password is incorrect");
                return loginResponse;                
            }

            var token = await _tokenService.CreateToken(user);

            loginResponse.Success = true;
            loginResponse.Email = user.Email;
            loginResponse.Token = token;

            return loginResponse;
        }
    }
}
