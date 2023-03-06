using Dapper_Sample.GenericRepositoryPattern;
using Dapper_Sample.Models;
using Dapper_Sample.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dapper_Sample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentWithGenericRepositoryController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentWithGenericRepositoryController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult AddStudent([FromQuery] StudentViewModel studentView)
        {
            _studentRepository.Insert(new Models.Student()
            {
                Address = studentView.Address,
                Name = studentView.Name,
            });
            return Ok(new FuncResult()
            {
                Status = Status.Ok,
                Entity = studentView
            });
        }


        [HttpPut]
        public IActionResult EditStudent([FromBody] Student student)
        {
            _studentRepository.Update(student);
            return Ok(new FuncResult()
            {
                Status = Status.Ok,
                Entity = student
            });
        }

        [HttpGet]
        public IActionResult GetStudentByCondition([FromQuery] StudentViewModel studentView)
        {
            /////// Its Possible to use EF core methode at the end of dappers result
            var res = _studentRepository.Query($"Where Name = '{studentView.Name}' And Address='{studentView.Address}'");

            return Ok(new FuncResult()
            {
                Entity = res,
                Status = Status.Ok
            });
        }
    }
}
