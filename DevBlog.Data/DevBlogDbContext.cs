using DevBlog.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Data
{
    public class DevBlogDbContext : DbContext
    {
        public DevBlogDbContext(DbContextOptions<DevBlogDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Blog> Blogs { get; set; }
    }
}
