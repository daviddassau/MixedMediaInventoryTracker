using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
//using MixedMediaInventoryTracker.Services;
using MixedMediaInventoryTracker.Models;
using System.Net;

namespace MixedMediaInventoryTracker.Controllers
{
    [RoutePrefix("api/media")]
    public class MediaController : ApiController
    {
        [HttpPost, Route("")]
        public HttpResponseMessage CreateMedia(MediaModel media)
        {
            var mediaRepository = new MediaRepository();
            var result = mediaRepository.Create(media);

            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not create Media item at this time, try again later");
        }
    }
}