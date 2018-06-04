using MixedMediaInventoryTracker.Models;
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

        [HttpGet, Route("{id}")]
        public HttpResponseMessage GetMediaItemToLend(int id)
        {
            var lentMediaRepository = new LentMediaRepository();
            var mediaItemToLend = lentMediaRepository.MediaItemToLend(id);
        }

        [HttpPost, Route("")]
        public HttpResponseMessage LendMediaItem(LentMediaDto lentMedia)
        {
            var lentMediaRepository = new LentMediaRepository();
            var lendMedia = lentMediaRepository.LendMedia(lentMedia);

            if (lendMedia)
            {
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not lend Media item at this time, try again later");
        }
    }
}