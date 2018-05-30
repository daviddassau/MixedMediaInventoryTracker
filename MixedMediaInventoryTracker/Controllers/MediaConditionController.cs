using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MixedMediaInventoryTracker.Services;

namespace MixedMediaInventoryTracker.Controllers
{
    [RoutePrefix("api/mediaCondition")]
    public class MediaConditionController : ApiController
    {
        [HttpGet, Route("")]
        public HttpResponseMessage GetMediaConditions()
        {
            var mediaConditionRepository = new MediaConditionRepository();
            var allMediaConditions = mediaConditionRepository.GetAllMediaConditions();

            return Request.CreateResponse(HttpStatusCode.OK, allMediaConditions);
        }
    }
}