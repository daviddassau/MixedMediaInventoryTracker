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

        [HttpGet, Route("lentMediaItemDetails/{id}")]
        public HttpResponseMessage GetSingleItemDetails(int id)
        {
            var lentMediaRepository = new LentMediaRepository();
            var itemDetails = lentMediaRepository.ItemDetails(id);

            return Request.CreateResponse(HttpStatusCode.OK, itemDetails);
        }

        [HttpPost, Route("")]
        public HttpResponseMessage LendMediaItem(LentMediaDto lentMedia)
        {
            var mediaRepository = new MediaRepository();
            var getSingleItem = mediaRepository.GetSingleItem(lentMedia.MediaId);
            lentMedia.MediaConditionId = getSingleItem.MediaConditionId;
            var lentMediaRepository = new LentMediaRepository();
            var lendMedia = lentMediaRepository.LendMedia(lentMedia);

            if (lendMedia)
            {
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not lend Media item at this time, try again later");
        }

        [HttpDelete, Route("{id}")]
        public HttpResponseMessage ReturnMediaItem(int id)
        {
            var lentMediaRepository = new LentMediaRepository();
            var returnMedia = lentMediaRepository.ReturnItem(id);

            return Request.CreateResponse(HttpStatusCode.OK, returnMedia);
        }
    }
}