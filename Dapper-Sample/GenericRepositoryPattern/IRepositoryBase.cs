namespace Dapper_Sample.GenericRepositoryPattern
{
    public interface IRepositoryBase<T> where T : class
    {
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        IEnumerable<T> Query(string where = null);

        IEnumerable<string> GetColumns();

    }
}
