using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class CategoryRepository : Repository<Category>
    {

        public static int Get(string slug)
        {
            var query = @"SELECT
                            Id
                        FROM
                            [Category]
                        WHERE
                            Slug = @Slug";

            var id = Database.Connection.QuerySingleOrDefault<int>(query, new
            {
                Slug = slug
            });

            return id;
        }
    }
}