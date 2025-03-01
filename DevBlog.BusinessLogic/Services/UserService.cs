using DevBlog.BusinessLogic.DTO.Requests;
using DevBlog.BusinessLogic.DTO.Responses;
using DevBlog.BusinessLogic.Interfaces;
using DevBlog.Data.Models;
using DevBlog.Data.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserResponse> CreateUser(UserCreateRequest request)
        {
            var existingUser = await _userRepository.GetUserByEmail(request.Email);
            
            if (existingUser != null)
            {
                return null;
            }

            var hashedPassword = _passwordHasher.Hash(request.Password);

            var user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = hashedPassword,
                IsDeleted = false
            };

            var result = await _userRepository.CreateUser(user);
            var newUser = new UserResponse(result.Id, result.FirstName, result.LastName, result.Email);
            return newUser;

        }

        public async Task<List<UserResponse>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();

            if (!users.Any())
                return new List<UserResponse>();

            List<UserResponse> userResponses = users.Select(user => new UserResponse(
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email
                )).ToList();

            return userResponses;

        }

        public async Task<UserResponse> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            UserResponse userResponse;

            if (user != null)
            {
                userResponse = new(user.Id, user.FirstName, user.LastName, user.Email);
                return userResponse;
            }

            return null;
        }
    }
}
