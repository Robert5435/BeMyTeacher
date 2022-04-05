using BeMyTeacher.Core;
using BeMyTeacher.DB;
using BeMyTeacher.WebApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BeMyTeacher.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TutoringAdsController : ControllerBase
    {
        private readonly ILogger<TutoringAdsController> _logger;
        private ITutoringAdsServices _tutoringAdsServices;
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtService;
        public IHostingEnvironment _hostingEnvironment;

        public TutoringAdsController(
            ILogger<TutoringAdsController> logger, 
            ITutoringAdsServices tutoringAdsServices,
            IUserRepository repository, 
            JwtService jwtService,
            IHostingEnvironment hostEnv)
        {
            _logger = logger;
            _tutoringAdsServices = tutoringAdsServices;
            _repository = repository;
            _jwtService = jwtService;
            _hostingEnvironment = hostEnv;  
        }

        [HttpGet("{id}", Name = "GetTutoringAd")]
        [AllowAnonymous]
        public IActionResult GetTutoringAd(int id)
        {
            return Ok(_tutoringAdsServices.GetTutoringAd(id));
        }

        //[HttpGet]
        //public IActionResult GetTutoringAds()
        //{
        //    return Ok(_tutoringAdsServices.GetTutoringAds());
        //}

        [HttpGet]
        public IActionResult GetViewModelTutoringAds(int? selectedSubjectId = null, int? selectedLocationId = null)
        {
            return Ok(_tutoringAdsServices.GetViewModelTutoringAds(selectedSubjectId, selectedLocationId));
        }

        [HttpPost]
        public IActionResult CreateTutoringAd()
        {
            var path = "";
            var newfilename = "";
            var tutoringAdFormData = HttpContext.Request.Form["tutoringAd"];
            var file = HttpContext.Request.Form.Files[0];
            TutoringAd tutoringAd = JsonSerializer.Deserialize<TutoringAd>(tutoringAdFormData);


            if (file != null)
            {
                FileInfo fi = new FileInfo(file.FileName);
                newfilename = "Image_" + DateTime.Now.TimeOfDay.Milliseconds + fi.Extension;
                path = Path.Combine("", _hostingEnvironment.ContentRootPath + "/Images/" + newfilename);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

            }


            tutoringAd.ExpirationDate = DateTime.Now;
            tutoringAd.PhotoPath = newfilename;


            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = _repository.GetById(userId);
                tutoringAd.UserId = user.Id;
            }
            catch (Exception)
            {
                return Unauthorized();
            }
            var newTutoringAd = _tutoringAdsServices.CreateTutoringAd(tutoringAd);

            return CreatedAtRoute("GetTutoringAd", new { newTutoringAd.Id }, newTutoringAd);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteTutoringAd(int id)
        {
            int userId;
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);
                userId = int.Parse(token.Issuer);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
            _tutoringAdsServices.DeleteTutoringAd(id,userId);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditTutoringAd(TutoringAd tutoringAd)
        {
            int userId;
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);
                userId = int.Parse(token.Issuer);
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            _tutoringAdsServices.EditTutoringAd(tutoringAd, userId);
            return Ok();
        }


        [HttpGet]
        [Route("TutoringAdsOfUser")]
        public IActionResult TutoringAdsOfUser()
        {
            int userId;
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);
                userId = int.Parse(token.Issuer);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
            return Ok(_tutoringAdsServices.GetViewModelTutoringAds(userId:userId));
        }
    }
}
