using DevBlog.BusinessLogic.DTO.Requests;
using DevBlog.BusinessLogic.DTO.Responses;
using DevBlog.BusinessLogic.Interfaces;
using DevBlog.Data.Models;
using DevBlog.Data.Repositories.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.BusinessLogic.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<BlogCreateResponse?> CreateBlog(BlogCreateRequest request)
        {
            Blog newBlog = new Blog();
            newBlog.Title = request.Title;
            newBlog.Content = request.Content;
            newBlog.UserId = request.UserId;
            newBlog.CreatedOn = DateTime.Now;
            newBlog.ModifiedOn = DateTime.Now;
            newBlog.IsDeleted = false;

            var result = await _blogRepository.InsertBlog(newBlog);

            var blogResponse = new BlogCreateResponse(
                    result.Id,
                    result.Title,
                    result.Content,
                    result.UserId,
                    result.CreatedOn,
                    result.ModifiedOn,
                    result.IsDeleted);

            return blogResponse;
        }
    }
}
