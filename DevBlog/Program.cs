
using DevBlog.BusinessLogic.DTO.Requests;
using DevBlog.BusinessLogic.Interfaces;
using DevBlog.BusinessLogic.Services;
using DevBlog.Data;
using DevBlog.Data.Repositories.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace DevBlog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            //register DbContext as a service
            builder.Services.AddDbContext<DevBlogDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DevDbConnection"))
            );

            //register DI services
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(options =>
                {
                    options.WithTitle("DevBlog API")
                    .WithTheme(ScalarTheme.BluePlanet)
                    .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            //User endpoints
            app.MapPost("/users", async ([FromBody] UserCreateRequest request,
                IUserService _userService) =>
            {
                var result = await _userService.CreateUser(request);

                return Results.Ok(result);

            }).Accepts<UserCreateRequest>("application/json");

            //https://localhost:7070/openapi/v1.json
            //https://localhost:7058/scalar/v1

            app.Run();
        }
    }
}
