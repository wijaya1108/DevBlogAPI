using DevBlog.Data.Models;
using DevBlog.Data.Repositories.Users;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Blog>> GetAllBlogs()
        {
            //var blogs = await _dbContext.Blogs
            //    .AsNoTracking()
            //    .Where(b => b.IsDeleted == false)
            //    .ToListAsync();

            //foreach (var blog in blogs)
            //{
            //    blog.User = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == blog.UserId);
            //}

            var blogs = await _dbContext.Blogs
                .AsNoTracking()
                .Include(b => b.UserDetails)
                .Where(b => !b.IsDeleted)
                .ToListAsync();

            return blogs;
        }

        public async Task<Blog> InsertBlog(Blog blog)
        {
            await _dbContext.Blogs.AddAsync(blog);
            await _dbContext.SaveChangesAsync();
            return blog;
        }

        public async Task<Blog> GetBlogById(int id)
        {
            var blog = await _dbContext.Blogs
                .AsNoTracking()
                .Include(b => b.UserDetails)
                .FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);

            return blog;
        }

        public async Task<bool> UpdateBlog(Blog blog)
        {
            var existingBlog = await _dbContext.Blogs.FirstOrDefaultAsync(b => b.Id == blog.Id && !b.IsDeleted);

            if (existingBlog != null)
            {
                existingBlog.Title = blog.Title;
                existingBlog.Content = blog.Content;
                existingBlog.UserId = blog.UserId;
                existingBlog.ModifiedOn = blog.ModifiedOn;

                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> DeleteBlog(int id)
        {
            var existingBlog = await _dbContext.Blogs.FirstOrDefaultAsync(b => b.Id == id);

            if (existingBlog != null)
            {
                existingBlog.IsDeleted = true;
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
