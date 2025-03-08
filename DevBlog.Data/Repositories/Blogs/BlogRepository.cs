using DevBlog.Data.Models;
using DevBlog.Data.Repositories.Users;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Data.Repositories.Blogs
{
    public class BlogRepository : IBlogRepository
    {
        private readonly DevBlogDbContext _dbContext;
        private readonly ILogger<BlogRepository> _logger;

        public BlogRepository(DevBlogDbContext dbCOntext, ILogger<BlogRepository> logger)
        {
            _dbContext = dbCOntext;
            _logger = logger;
        }

        public async Task<Blog> InsertBlog(Blog blog)
        {
            try
            {
                await _dbContext.Blogs.AddAsync(blog);
                await _dbContext.SaveChangesAsync();
                return blog;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured while creating the Blog: {0}", ex.Message);
                return null;
            }
        }
    }
}
