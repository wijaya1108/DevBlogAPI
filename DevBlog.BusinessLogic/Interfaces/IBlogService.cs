using DevBlog.BusinessLogic.DTO.Requests;
using DevBlog.BusinessLogic.DTO.Responses;

namespace DevBlog.BusinessLogic.Interfaces
{
    public interface IBlogService
    {
        Task<BlogCreateResponse?> CreateBlog(BlogCreateRequest request);
        Task<List<BlogResponse>> GetAllBlogs();
        Task<BlogResponse> GetBlogById(int id);
        Task<bool> UpdateBlog(BlogUpdateRequest request);
        Task<bool> DeleteBlog(int id);
    }
}
