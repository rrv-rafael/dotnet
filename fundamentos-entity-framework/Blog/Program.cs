using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog;

class Program
{
    static void Main(string[] args)
    {
        using var context = new BlogDataContext();

        var posts = context.Posts.AsNoTracking().Include(x => x.Author).Include(x => x.Category).OrderByDescending(x => x.LastUpdateDate).ToList();

        foreach (var post in posts)
        {
            Console.WriteLine($"{post.Title} escrito por {post.Author?.Name} em {post.Category?.Name}");
        }
    }
}
