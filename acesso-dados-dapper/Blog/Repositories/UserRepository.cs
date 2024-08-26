using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository : Repository<User>
    {
        public static List<User> GetWithRoles()
        {
            var query = @"SELECT
                            u.*,
                            r.*
                        FROM
                            [User] u
                        LEFT JOIN
                            [UserRole] ur ON u.Id = ur.UserId
                        LEFT JOIN
                            [Role] r ON ur.RoleId = r.Id";

            var users = new List<User>();

            var items = Database.Connection.Query<User, Role, User>(query, (user, role) =>
            {
                var usr = users.FirstOrDefault(x => x.Id == user.Id);

                if (usr == null)
                {
                    usr = user;

                    if (role != null)
                    {
                        usr.Roles.Add(role);
                    }

                    users.Add(usr);
                }
                else
                {
                    usr.Roles.Add(role);
                }

                return user;
            }, splitOn: "Id");

            return users;
        }

        public static int Get(string email)
        {
            var query = @"SELECT
                            Id
                        FROM
                            [User]
                        WHERE
                            Email = @Email";

            var id = Database.Connection.QuerySingleOrDefault<int>(query, new
            {
                Email = email
            });

            return id;
        }
    }
}