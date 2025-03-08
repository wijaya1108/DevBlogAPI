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
            await _dbContext.Blogs.AddAsync(blog);
            await _dbContext.SaveChangesAsync();
            return blog;
        }
    }
}
