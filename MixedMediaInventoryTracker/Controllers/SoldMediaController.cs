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
    [RoutePrefix("api/soldmedia")]
    public class SoldMediaController : ApiController
    {
        [HttpGet, Route("")]
        public HttpResponseMessage GetSoldMedia()
        {
            var soldMediaRepository = new SoldMediaRepository();
            var allSoldMedia = soldMediaRepository.GetAllSoldMedia();

            return Request.CreateResponse(HttpStatusCode.OK, allSoldMedia);
        }

        [HttpPost, Route("")]
        public HttpResponseMessage SellMediaItem(SoldMediaDto soldMedia)
        {
            var mediaRepository = new MediaRepository();
            var getSingleItem = mediaRepository.GetSingleItem(soldMedia.MediaId);
            soldMedia.MediaConditionId = getSingleItem.MediaConditionId;
            var soldMediaRepository = new SoldMediaRepository();
            var sellMedia = soldMediaRepository.SellMedia(soldMedia);

            if (sellMedia)
            {
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not sell Media item at this time, try again later");
        }
    }
}