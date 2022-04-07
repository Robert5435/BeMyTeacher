using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using BeMyTeacher.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeMyTeacher.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EducationLevelsController : ControllerBase
    {

        private readonly ILogger<SubjectsController> logger;
        private IEducationLevels _educationLevelsServices;

        public EducationLevelsController(ILogger<SubjectsController> logger, IEducationLevels educationLevelsServices)
        {
            this.logger = logger;
            _educationLevelsServices = educationLevelsServices;
        }


        // GET: api/<EducationLevelsController>/list
        [Route("list")]
        [HttpGet]
        public IActionResult GetEducationLevels()
        {
            return Ok(_educationLevelsServices.GetEducations());
        }

        // GET api/<EducationLevelsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_educationLevelsServices.GetEducationLevel(id));
        }

        // POST api/<EducationLevelsController>/
        [HttpPost]
        public IActionResult Create()
        {
            string name = HttpContext.Request.Form["name"];
            _educationLevelsServices.CreateEducationLevel(name);
            return Ok();
        }

        // DELETE api/<EducationLevelsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _educationLevelsServices.DeleteEducationLevel(id);  
            return Ok();
        }
    }
}
