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
    [RoutePrefix("api/mediaType")]
    public class MediaTypeController : ApiController
    {
        [HttpGet, Route("")]
        public HttpResponseMessage GetMediaTypes()
        {
            var mediaTypeRepository = new MediaTypeRepository();
            var allMediaTypes = mediaTypeRepository.GetAllMediaTypes();

            return Request.CreateResponse(HttpStatusCode.OK, allMediaTypes);
        }
    }
}