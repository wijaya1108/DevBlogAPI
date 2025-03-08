using DevBlog.BusinessLogic.DTO.Requests;
using DevBlog.BusinessLogic.DTO.Responses;
using DevBlog.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevBlog.Endpoints
{
    public static class BlogsModule
    {
        public static void AddBlogEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/blogs", async (IBlogService _blogService,
                BlogCreateRequest request) =>
            {
                //TODO - validation
                var result = await _blogService.CreateBlog(request);

                SuccessResponse response = new();
                response.Data = result;

                if (result == null)
                {
                    response.Success = false;
                    response.StatusCode = BusinessLogic.Enums.StatusCodes.InternalServerError;
                    return Results.InternalServerError(response);
                }

                return Results.Ok(response);
            });
        }
    }
}
