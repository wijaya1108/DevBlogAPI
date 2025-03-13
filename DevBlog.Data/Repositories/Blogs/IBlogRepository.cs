using DevBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Data.Repositories.Blogs
{
    public interface IBlogRepository
    {
        Task<Blog> InsertBlog(Blog blog);
        Task<List<Blog>> GetAllBlogs();
        Task<Blog> GetBlogById(int id);
        Task<bool> UpdateBlog(Blog blog);
        Task<bool> DeleteBlog(int id);
    }
}
