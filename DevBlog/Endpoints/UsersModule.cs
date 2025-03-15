using DevBlog.BusinessLogic.DTO.Requests;
using DevBlog.BusinessLogic.DTO.Responses;
using DevBlog.BusinessLogic.Interfaces;
using DevBlog.Validators;
using Microsoft.AspNetCore.Mvc;

namespace DevBlog.Endpoints
{
    public static class UsersModule
    {
        public static void AddUserEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/users", async ([FromBody] UserCreateRequest request,
                IUserService _userService) =>
            {
                SuccessResponse response = new();

                var validator = new UserCreateRequestValidator();
                var validationResult = await validator.ValidateAsync(request);

                if (!validationResult.IsValid)
                {
                    List<string> errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    response.Success = false;
                    response.StatusCode = BusinessLogic.Enums.StatusCodes.BadRequest;
                    response.ErrorList = errors;
                    return Results.BadRequest(response);
                }

                var result = await _userService.CreateUser(request);

                if (result != null)
                {
                    return Results.CreatedAtRoute("GetUserById", new { id = result.Id }, result);
                }

                response.Success = false;
                response.StatusCode = BusinessLogic.Enums.StatusCodes.BadRequest;
                return Results.BadRequest(response);

            }).Accepts<UserCreateRequest>("application/json");


            app.MapGet("/users", async (IUserService _userService) =>
            {
                var result = await _userService.GetAllUsers();

                SuccessResponse response = new();
                response.Data = result;

                return Results.Ok(response);
            }).RequireAuthorization();


            app.MapGet("/users/{id:int}", async (IUserService _userService,
                int id) =>
            {
                var result = await _userService.GetUserById(id);

                SuccessResponse response = new();
                response.Data = result;

                return Results.Ok(response);
            }).WithName("GetUserById");
        }
    }
}
