﻿using DevBlog.BusinessLogic.DTO.Requests;
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

                SuccessResponse response = new();

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

                return Results.Ok(response);
            });


            app.MapGet("/blogs", async (IBlogService _blogService) =>
            {
                var result = await _blogService.GetAllBlogs();

                return Results.Ok(result);
            });

            app.MapGet("/blogs/{id:int}", async (IBlogService _blogService, int id) =>
            {
                var result = await _blogService.GetBlogById(id);

                return Results.Ok(result);
            });
        }
    }
}
