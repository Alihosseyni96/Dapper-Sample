using Dapper_Sample.Services;
using Dapper_Sample.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dapper_Sample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentServices;
        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentViewModel Student)
        {
            var res = await _studentServices.AddStudent(Student);
            return Ok(res);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var res = await _studentServices.FindStudentById(Id);
            return Ok(res);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteById([FromRoute] int Id)
        {
            var res = await _studentServices.DeleteStudentbyId(Id);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var res = await _studentServices.List();
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> StudentListBySp()
        {
            var res = await _studentServices.StudentListBySp();
            return Ok(res);
        }


        [HttpGet]
        public async Task<IActionResult> GetUserBySearchAddress([FromQuery] string searchKey)
        {
            var res = await _studentServices.GetStudentsByAddressSearchSp(searchKey);
            return Ok(res);
        }
    }
}
