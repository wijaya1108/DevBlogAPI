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
                _logger.LogError("User create operation failed: {0}", ex);
                return false;
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                var users = await _dbContext.Users.AsNoTracking().Where(u => u.IsDeleted == false).ToListAsync();
                return users;
            }
            catch (Exception ex)
            {
                _logger.LogError("Cannot retrieve the users: {0}", ex);
                return new List<User>();
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }
    }
}
