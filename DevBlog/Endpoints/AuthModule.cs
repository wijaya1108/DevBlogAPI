using DevBlog.BusinessLogic.DTO.Requests;
using DevBlog.BusinessLogic.DTO.Responses;
using DevBlog.BusinessLogic.Interfaces;
using DevBlog.Validators;

namespace DevBlog.Endpoints
{
    public static class AuthModule
    {
        public static void AddAuthEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/login", async (IAuthService _authService, LoginRequest request) =>
            {
                var validator = new LoginRequestValidator();
                var validationResult = await validator.ValidateAsync(request);

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    LoginResponse loginResponse = new()
                    {
                        Success = false,
                        Errors = errors
                    };

                    return Results.BadRequest(loginResponse);
                }

                var result = await _authService.LoginUser(request);

                return Results.Ok(result);
            });
        }
    }
}
