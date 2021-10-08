using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeMyTeacher.Core;
using BeMyTeacher.DB;
using Microsoft.Extensions.Logging;

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

        [HttpGet]
        public IActionResult GetTutoringAds()
        {
            return Ok(_tutoringAdsServices.GetTutoringAds());
        }
        [HttpPost]
        public IActionResult CreateTutoringAd(TutoringAd tutoringAd)
        {
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
