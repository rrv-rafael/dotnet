using Blog.Data;
using Microsoft.EntityFrameworkCore;

namespace Blog;

class Program
{
    static void Main(string[] args)
    {
        using var context = new BlogDataContext();

        var post = context
            .Posts
            .AsNoTracking()
            .Include(x => x.Author)
            .Include(x => x.Category)
            .OrderByDescending(x => x.LastUpdateDate)
            .FirstOrDefault() ?? throw new InvalidOperationException("Post not found.");

        post.Author.Name = "André Baltieri";

        context.Posts.Update(post);
        context.SaveChanges();
    }
}
