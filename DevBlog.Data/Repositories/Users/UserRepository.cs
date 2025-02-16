using DevBlog.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Data.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DevBlogDbContext _dbContext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(DevBlogDbContext dbContext, ILogger<UserRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<bool> CreateUser(User user)
        {
            try
            {
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("User create operation failed: {0}", ex.Message);
                return false;
            }
        }
    }
}
