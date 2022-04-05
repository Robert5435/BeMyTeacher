using BeMyTeacher.Core;
using BeMyTeacher.DB;
using BeMyTeacher.WebApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace BeMyTeacher.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtService;
        public IHostingEnvironment _hostingEnvironment;

        public UsersController(IUserRepository repository, JwtService jwtService, IHostingEnvironment hostEnv)
        {
            _repository = repository;
            _jwtService = jwtService;
            _hostingEnvironment = hostEnv;
        }
        [HttpPost(template: "register")]
        public IActionResult Register(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            var newUser = _repository.Create(user);

            return CreatedAtRoute(new { newUser.Id }, newUser);
        }
        [HttpPost(template: "login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _repository.GetByEmail(dto.Email);

            if (user == null) return BadRequest(new { message = "Invalid Credentials" });

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return BadRequest(new { message = "Invalid Credentials" });
            }
            var jwt = _jwtService.Generate(user.Id);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true
            });

            return Ok(new { message = "success" });
        }

        [HttpGet(template: "user")]
        public IActionResult User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = _repository.GetById(userId);
                return Ok(user);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
        [HttpGet(template: "logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt", new CookieOptions {
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true
            });
            return Ok(new { message = "success" });
        }
        [HttpPost]
        [Route("Upload")]
        public IActionResult Upload()
        {
            var path = "";
            var newfilename = "";
            var phoneNumber = HttpContext.Request.Form["phNumber"];
            var file = HttpContext.Request.Form.Files[0];
            if(file != null)
            {
                FileInfo fi = new FileInfo(file.FileName);
                newfilename = "Image_" + DateTime.Now.TimeOfDay.Milliseconds + fi.Extension;
                path = Path.Combine("",_hostingEnvironment.ContentRootPath+ "/Images/" + newfilename);
                using(var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            int userId;
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);
                userId = int.Parse(token.Issuer);
                _repository.EditUser(userId, phoneNumber, newfilename);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
            return Ok();

        }
    }
}
//C: \Users\robyb\source\repos\BeMyTeacher\Notes.Core\Images\