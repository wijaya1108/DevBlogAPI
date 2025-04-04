﻿using DevBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Data.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task<User> GetUserByEmail(string email);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
    }
}
