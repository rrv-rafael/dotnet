using Blog.Data;
using Blog.Models;

namespace Blog;

class Program
{
    static void Main(string[] args)
    {
        using var context = new BlogDataContext();

        var tags = context.Tags.Where(x => x.Name.Contains("ASP")).ToList();

        foreach (var tag in tags)
        {
            Console.WriteLine(tag.Name);
        }
    }
}
