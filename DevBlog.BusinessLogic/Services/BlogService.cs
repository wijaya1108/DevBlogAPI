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

        public async Task<List<BlogResponse>> GetAllBlogs()
        {
            var blogs = await _blogRepository.GetAllBlogs();

            List<BlogResponse> blogResponseList = new List<BlogResponse>();

            if (blogs != null)
            {
                blogResponseList = blogs.Select(b => new BlogResponse(
                    b.Id,
                    b.Title,
                    b.Content,
                    b.CreatedOn,
                    b.ModifiedOn,
                    b.IsDeleted,
                    b.UserId,
                    b.UserDetails.FirstName,
                    b.UserDetails?.LastName)).ToList();

                return blogResponseList;
            }

            return blogResponseList;
        }

        public async Task<BlogResponse> GetBlogById(int id)
        {
            var blog = await _blogRepository.GetBlogById(id);

            if (blog != null)
            {
                var blogResponse = new BlogResponse(
                    blog.Id,
                    blog.Title,
                    blog.Content,
                    blog.CreatedOn,
                    blog.ModifiedOn,
                    blog.IsDeleted,
                    blog.UserId,
                    blog.UserDetails.FirstName,
                    blog.UserDetails?.LastName
                    );

                return blogResponse;
            }

            return null;
        }

        public async Task<bool> UpdateBlog(BlogUpdateRequest request)
        {
            var blog = new Blog()
            {
                Id = request.Id,
                Title = request.Title,
                Content = request.Content,
                UserId = request.UserId,
                ModifiedOn = DateTime.Now
            };

            var result = await _blogRepository.UpdateBlog(blog);

            return result;
        }

        public async Task<bool> DeleteBlog(int id)
        {
            var result = await _blogRepository.DeleteBlog(id);

            return result;
        }
    }
}
