using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.BusinessLogic.DTO.Requests
{
    public record UserCreateRequest
    {
        public string FirstName { get; init; }
        public string? LastName { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
    }
}
