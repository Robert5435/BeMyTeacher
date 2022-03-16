using BeMyTeacher.Core;
using BeMyTeacher.DB;
using BeMyTeacher.WebApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

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

        public TutoringAdsController(
            ILogger<TutoringAdsController> logger, 
            ITutoringAdsServices tutoringAdsServices,
            IUserRepository repository, 
            JwtService jwtService)
        {
            _logger = logger;
            _tutoringAdsServices = tutoringAdsServices;
            _repository = repository;
            _jwtService = jwtService;
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
        public IActionResult CreateTutoringAd(TutoringAd tutoringAd)
        {

            tutoringAd.ExpirationDate = DateTime.Now;
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
        public IActionResult EditTutoringAd([FromBody] TutoringAd tutoringAd)
        {
            _tutoringAdsServices.EditTutoringAd(tutoringAd);
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
            return Ok(_tutoringAdsServices.GetTutoringAdsOfUser(userId));
        }
    }
}
