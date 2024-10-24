using Microsoft.EntityFrameworkCore;

namespace FluentBlog.Data
{
    public class BlogDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=FluentBlog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True");
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}