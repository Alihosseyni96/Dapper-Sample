using Dapper_Sample.ViewModels;

namespace Dapper_Sample.Services
{
    public interface IStudentServices
    {
         Task<FuncResult> AddStudent(StudentViewModel studentViewModel);
        Task<FuncResult> FindStudentById(int id);
        Task<FuncResult> DeleteStudentbyId(int id);

        Task<FuncResult> List();
        Task<FuncResult> StudentListBySp();
        Task<FuncResult> GetStudentsByAddressSearchSp(string searchKey);
    }
}
