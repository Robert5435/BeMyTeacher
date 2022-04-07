using BeMyTeacher.Core;
using BeMyTeacher.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BeMyTeacher.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly ILogger<SubjectsController> _logger;
        private ISubjectsServices _subjectServices;

        public SubjectsController(ILogger<SubjectsController> logger, ISubjectsServices subjectsServices)
        {
            _logger = logger;
            _subjectServices = subjectsServices;
        }

        [HttpGet("{id}", Name = "GetSubject")]
        public IActionResult GetSubject(int id)
        {
            return Ok(_subjectServices.GetSubject(id));
        }

        [HttpGet]
        public IActionResult GetSubjects()
        {
            return Ok(_subjectServices.GetSubjects());
        }

        [HttpDelete]
        public IActionResult DeleteSubject(int id)
        {
            _subjectServices.DeleteSubjects(id);
            return Ok();
        }
    }
}
