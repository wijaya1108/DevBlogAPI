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

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CreateUser(UserCreateRequest request)
        {
            //TODO - hash the password
            var existingUser = await _userRepository.GetUserByEmail(request.Email);
            
            if (existingUser == null)
            {
                var user = new User()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Password = request.Password,
                    IsDeleted = false
                };

                var result = await _userRepository.CreateUser(user);
                return result;
            }

            return false;
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
    }
}
