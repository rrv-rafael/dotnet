using FluentBlog.Data;
using FluentBlog.Models;

namespace FluentBlog;

class Program
{
    static void Main(string[] args)
    {
        using var context = new FluentBlogDataContext();

        var user = context.Users.FirstOrDefault();
        
        var post = new Post
        {
            Author = user,
            Body = "Meu artigo",
            Category = new Category
            {
                Name = "Backend",
                Slug = "backend"
            },
            CreateDate = DateTime.Now,
            Slug = "meu-artigo",
            Summary = "Neste artigo vamos conferir...",
            Title = "Meu artigo",
        };
        
        context.Posts.Add(post);
        context.SaveChanges();
    }
}
