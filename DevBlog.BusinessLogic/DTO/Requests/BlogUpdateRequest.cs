using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.BusinessLogic.DTO.Requests
{
    public class BlogUpdateRequest
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string? Content { get; init; }
        public int UserId { get; init; }
    }
}
