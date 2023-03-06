using Dapper;
using System.Data.SqlClient;
using System.Reflection;

namespace Dapper_Sample.GenericRepositoryPattern
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected string connectionString = "server=.; database=TestDb; Integrated Security=true";

        public void Delete(T entity)
        {
            var query = $"delete from {typeof(T).Name}s where Id = @Id";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute(query, entity);
            }
        }

        public IEnumerable<string> GetColumns()
        {
            return typeof(T)
                    .GetProperties()
                    .Where(e => e.Name != "Id" && !e.PropertyType.GetTypeInfo().IsGenericType)
                    .Select(e => e.Name);
        }

        public void Insert(T entity)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns);
            var stringOfParameters = string.Join(", ", columns.Select(e => "@" + e));
            var query = $"insert into {typeof(T).Name}s ({stringOfColumns}) values ({stringOfParameters})";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute(query, entity);
            }
        }

        public IEnumerable<T> Query(string where = null)
        {
            var query = $"select * from {typeof(T).Name}s ";

            if (!string.IsNullOrWhiteSpace(where))
                query += where;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<T>(query);
            }
        }

        public void Update(T entity)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns.Select(e => $"{e} = @{e}"));
            var query = $"update {typeof(T).Name}s set {stringOfColumns} where Id = @Id";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute(query, entity);
            }
        }
    }
}
