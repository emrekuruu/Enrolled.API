using Enrolled.API.Entities;
using Enrolled.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Enrolled.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EnrolledController : ControllerBase
    {
        private readonly IEnrolledRepository _repository;
        public EnrolledController(IEnrolledRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{ClassName}",Name = "GetAllStudents")]
        [ProducesResponseType(typeof(List<Student>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<List<Student>>> GetAllStudentsAsync(string ClassName)
        {
            var students = await _repository.GetAllStudentsAsync(ClassName);
            return Ok(students);
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> EnrollStudent(int id, string className)
        {
            var affect = await _repository.EnrollStudent(id, className);
            return Ok(affect);
        }
    }
}
