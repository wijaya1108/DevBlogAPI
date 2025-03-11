using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Data.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }

        public User? UserDetails { get; set; }
    }
}
