using DevBlog.BusinessLogic.DTO.Requests;
using DevBlog.BusinessLogic.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUser(UserCreateRequest request);
        Task<List<UserResponse>> GetAllUsers();
    }
}
