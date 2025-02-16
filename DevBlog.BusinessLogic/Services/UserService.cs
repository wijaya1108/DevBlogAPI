using DevBlog.BusinessLogic.DTO.Requests;
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
            //TODO - check if user is already there by email/name
            //TODO - hash the password

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
    }
}
