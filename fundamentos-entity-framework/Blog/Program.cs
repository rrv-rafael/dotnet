using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog;

class Program
{
    static void Main(string[] args)
    {
        using var context = new BlogDataContext();

        var tag = context.Tags.AsNoTracking().FirstOrDefault(x => x.Id == 1) ?? throw new InvalidOperationException("Tag is not found");

        Console.WriteLine(tag.Name);
    }
}
