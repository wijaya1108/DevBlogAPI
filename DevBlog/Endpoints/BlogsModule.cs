using DevBlog.BusinessLogic.DTO.Requests;
using DevBlog.BusinessLogic.DTO.Responses;
using DevBlog.BusinessLogic.Interfaces;
using DevBlog.Validators;
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
                var validator = new BlogCreateRequestValidator();
                var validationResult = await validator.ValidateAsync(request);

                var response = new SuccessResponse();

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    response.Success = false;
                    response.StatusCode = BusinessLogic.Enums.StatusCodes.BadRequest;
                    response.ErrorList = errors;
                    return Results.BadRequest(response);
                }

                var result = await _blogService.CreateBlog(request);

                response.Data = result;

                return Results.CreatedAtRoute("GetBlogById", new { id = result?.Id }, result);
            });


            app.MapGet("/blogs", async (IBlogService _blogService) =>
            {
                var result = await _blogService.GetAllBlogs();
                var response = new SuccessResponse();

                response.Data = result;

                return Results.Ok(response);
            });


            app.MapGet("/blogs/{id:int}", async (IBlogService _blogService, int id) =>
            {
                var result = await _blogService.GetBlogById(id);
                var response = new SuccessResponse();

                response.Data = result;

                return Results.Ok(response);
            }).WithName("GetBlogById");


            app.MapPut("/blogs", async (IBlogService _blogService,
                BlogUpdateRequest request) =>
            {
                var result = await _blogService.UpdateBlog(request);
                var response = new SuccessResponse();

                if (result)
                    return Results.Ok(response);

                response.Success = result;
                response.StatusCode = BusinessLogic.Enums.StatusCodes.BadRequest;
                response.ErrorList.Add($"Blog with ID {request.Id} does not exist");
                return Results.BadRequest(response);
            });


            app.MapDelete("/blogs/{id:int}", async (IBlogService _blogService, int id) =>
            {
                var result = await _blogService.DeleteBlog(id);
                var response = new SuccessResponse();

                if (result)
                    return Results.Ok(response);

                response.Success = false;
                response.StatusCode = BusinessLogic.Enums.StatusCodes.BadRequest;
                response.ErrorList.Add($"Blog with ID {id} does not exist");
                return Results.BadRequest(response);
            });
        }
    }
}
