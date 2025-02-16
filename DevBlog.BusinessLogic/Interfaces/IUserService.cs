using DevBlog.BusinessLogic.DTO.Requests;
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
    }
}
