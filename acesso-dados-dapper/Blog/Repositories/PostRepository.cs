using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class PostRepository : Repository<Post>
    {
        public static List<Category> GetWithCategory()
        {
            var query = @"SELECT
                            *
                        FROM
                            [Category] c
                        INNER JOIN
                            [Post] p ON c.Id = p.CategoryId";

            var categories = new List<Category>();

            var items = Database.Connection.Query<Category, Post, Category>(query, (category, post) =>
            {
                var cat = categories.FirstOrDefault(x => x.Id == category.Id);

                if (cat == null)
                {
                    cat = category;

                    if (post != null)
                    {
                        cat.Posts.Add(post);
                    }

                    categories.Add(cat);
                }
                else
                {
                    cat.Posts.Add(post);
                }

                return category;
            }, splitOn: "Id");

            return categories;
        }
    }
}