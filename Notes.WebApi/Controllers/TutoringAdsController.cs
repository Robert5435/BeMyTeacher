using BeMyTeacher.Core;
using BeMyTeacher.DB;
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

        public TutoringAdsController(ILogger<TutoringAdsController> logger, ITutoringAdsServices tutoringAdsServices)
        {
            _logger = logger;
            _tutoringAdsServices = tutoringAdsServices;
        }

        [HttpGet("{id}", Name = "GetTutoringAd")]
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
            var newTutoringAd = _tutoringAdsServices.CreateTutoringAd(tutoringAd);

            return CreatedAtRoute("GetTutoringAd", new { newTutoringAd.Id }, newTutoringAd);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteTutoringAd(int id)
        {
            _tutoringAdsServices.DeleteTutoringAd(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditTutoringAd([FromBody] TutoringAd tutoringAd)
        {
            _tutoringAdsServices.EditTutoringAd(tutoringAd);
            return Ok();
        }
    }
}
