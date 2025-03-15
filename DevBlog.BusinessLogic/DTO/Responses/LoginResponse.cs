using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.BusinessLogic.DTO.Responses
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string? Email { get; set; }
        public List<string>? Errors { get; set; } = new List<string>();
        public string Token { get; set; }
    }
}
