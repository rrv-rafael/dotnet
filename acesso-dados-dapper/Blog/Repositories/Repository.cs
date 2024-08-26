using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class Repository<T> where T : class
    {
        public IEnumerable<T> Get() => Database.Connection.GetAll<T>();

        public T Get(long id) => Database.Connection.Get<T>(id);

        public long Create(T model) => Database.Connection.Insert<T>(model);

        public bool Update(T model) => Database.Connection.Update<T>(model);

        public bool Delete(T model) => Database.Connection.Delete<T>(model);

        public bool Delete(long id)
        {
            var model = Database.Connection.Get<T>(id);
            return Database.Connection.Delete<T>(model);
        }
    }
}