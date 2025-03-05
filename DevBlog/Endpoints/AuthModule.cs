using DevBlog.BusinessLogic.DTO.Requests;
using DevBlog.BusinessLogic.Interfaces;

namespace DevBlog.Endpoints
{
    public static class AuthModule
    {
        public static void AddAuthEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/login", async (IAuthService _authService, LoginRequest request) =>
            {
                //TODO - validation
                var result = await _authService.LoginUser(request);

                return result;
            });
        }
    }
}
