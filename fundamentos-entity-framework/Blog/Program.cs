using Blog.Data;
using Blog.Models;

namespace Blog;

class Program
{
    static void Main(string[] args)
    {
        using var context = new BlogDataContext();

        var tag = context.Tags.FirstOrDefault(x => x.Id == 1) ?? throw new InvalidOperationException("Tag not found.");

        context.Remove(tag);
        context.SaveChanges();
    }
}
