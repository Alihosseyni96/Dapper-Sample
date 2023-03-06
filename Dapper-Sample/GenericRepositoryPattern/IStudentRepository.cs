using Dapper_Sample.Models;

namespace Dapper_Sample.GenericRepositoryPattern
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
    }
}
