using FluentBlog.Data;
using FluentBlog.Models;

namespace FluentBlog;

class Program
{
    static void Main(string[] args)
    {
        using var context = new FluentBlogDataContext();
        
        context.Users.Add(new User
        {
            Bio = "12x Microsoft MVP",
            Email = "andre@balta.io",
            Image = "https://balta.io",
            Name = "Andre Baltieri",
            PasswordHash = "1234",
            Slug = "andre-baltieri"
        });
        
        context.SaveChanges();
    }
}
