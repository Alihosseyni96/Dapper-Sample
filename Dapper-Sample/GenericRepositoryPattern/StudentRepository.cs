using Dapper_Sample.Models;

namespace Dapper_Sample.GenericRepositoryPattern
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
    }
}
