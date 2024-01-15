using BE_ExamMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_ExamMVC.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Blog> Blogs { get; set; }
    }
}
