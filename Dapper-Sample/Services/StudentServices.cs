using Dapper_Sample.Models;
using Dapper_Sample.ViewModels;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace Dapper_Sample.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IDbConnection _db;
        public StudentServices()
        {
            _db = new SqlConnection("server=.; database=TestDb; Integrated Security=true");
        }

        public async Task<FuncResult> AddStudent(StudentViewModel studentViewModel)
        {
            _db.Open();
            var x = await _db.ExecuteAsync($"Insert Into TestDb.dbo.Students (Name , Address) values ('{studentViewModel.Name}' , '{studentViewModel.Address}');");
            _db.Close();
            if (!x.Equals(1))
            {
                return new FuncResult()
                {
                    Status = Status.Fail,
                    Error = new Error() { Message = "data can not be saved " }
                };
            }
            return new FuncResult()
            {
                Status = Status.Ok,
                Entity = studentViewModel,
                ID = x
            };

        }


        public async Task<FuncResult> FindStudentById(int id)
        {
            _db.Open();
            var student = await _db.QueryAsync<Student>($"Select * From TestDb.dbo.Students Where Students.Id = {id} ");
            _db.Close();
            var x = student.GetEnumerator().Current;

            if (student == null)
            {
                return new FuncResult()
                {
                    Status = Status.Fail,
                    Error = new Error() { Message = "date can not be feted" }
                };
            }
            return new FuncResult()
            {
                Status = Status.Ok,
                Entity = student,
            };
        }


        public async Task<FuncResult> DeleteStudentbyId(int id)
        {
            _db.Open();
            var res = await _db.QueryAsync($"Delete From TestDb.dbo.Students Where Students.Id = {id}");

            _db.Close();


            return new FuncResult()
            {
                Status = Status.Ok,
            };
        }

        public async Task<FuncResult> List()
        {
            _db.Open();
            var res = await _db.QueryAsync<Student>("Select * From TestDb.dbo.Students");
            _db.Close();
            return new FuncResult()
            {
                Status = Status.Ok,
                Entity = res
            };
        }

    }
}
