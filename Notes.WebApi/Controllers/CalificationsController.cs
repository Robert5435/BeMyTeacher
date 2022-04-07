using BeMyTeacher.Core;
using BeMyTeacher.DB;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeMyTeacher.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalificationsController : ControllerBase
    {
        private ICalificationsServices _calificationsServices;

        public CalificationsController(ICalificationsServices calificationsServices)
        {
            _calificationsServices = calificationsServices;
        }

        // GET: <CalificationsController>/list
        [Route("list")]
        [HttpGet]
        public IActionResult GetAllCalifications()
        {
            
            return Ok(_calificationsServices.GetAllCalifications());
        }

        // GET api/<CalificationsController>/5
        [HttpGet("{id}")]
        public IActionResult GetCalification(int id)
        {
            return Ok(_calificationsServices.GetCalification(id));
        }

        // POST api/<CalificationsController>
        [HttpPost]
        public IActionResult Create()
        {
            var name = HttpContext.Request.Form["name"];
            _calificationsServices.CreateCalification(name);
            return Ok();
        }


        // DELETE api/<CalificationsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _calificationsServices.DeleteCalification(id);
            return Ok();
        }
    }
}
