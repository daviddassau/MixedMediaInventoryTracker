using MixedMediaInventoryTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MixedMediaInventoryTracker.Controllers
{
    [RoutePrefix("api/lentmedia")]
    public class LentMediaController : ApiController
    {
        [HttpGet, Route("")]
        public HttpResponseMessage GetLentMedia()
        {
            var lentMediaRepository = new LentMediaRepository();
            var allLentMedia = lentMediaRepository.GetAllLentMedia();

            return Request.CreateResponse(HttpStatusCode.OK, allLentMedia);
        }

        [HttpPost, Route("")]
        public HttpResponseMessage LendMediaItem()
        {

        }
    }
}