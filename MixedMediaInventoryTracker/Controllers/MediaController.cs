using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MixedMediaInventoryTracker.Models;
using System.Net;
using MixedMediaInventoryTracker.Services;

namespace MixedMediaInventoryTracker.Controllers
{
    [RoutePrefix("api/media")]
    public class MediaController : ApiController
    {
        [HttpPost, Route("")]
        public HttpResponseMessage CreateMedia(MediaDto media)
        {
            var mediaRepository = new MediaRepository();
            var result = mediaRepository.Create(media);

            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not create Media item at this time, try again later");
        }

        [HttpGet, Route("")]
        public HttpResponseMessage GetMedia()
        {
            var mediaRepository = new MediaRepository();
            var allMedia = mediaRepository.GetAllMedia();

            return Request.CreateResponse(HttpStatusCode.OK, allMedia);
        }

        [HttpGet, Route("{id}")]
        public HttpResponseMessage GetSingleMediaItem(int id)
        {
            var mediaRepository = new MediaRepository();
            var singleMediaItem = mediaRepository.GetSingleItem(id);

            return Request.CreateResponse(HttpStatusCode.OK, singleMediaItem);
        }

        [HttpPut, Route("{id}")]
        public HttpResponseMessage EditMedia(int id, MediaDto media)
        {
            var mediaModifier = new MediaModifier();
            var editMedia = mediaModifier.EditMediaItem(id, media);

            return Request.CreateResponse(HttpStatusCode.OK, editMedia);
        }

        [HttpDelete, Route("{id}")]
        public HttpResponseMessage DeleteMedia(int id)
        {
            var mediaModifier = new MediaModifier();
            var deleteMediaItem = mediaModifier.DeleteMediaItem(id);

            return Request.CreateResponse(HttpStatusCode.OK, deleteMediaItem);
        }

        [HttpGet, Route("mediaItemToLend")]
        public HttpResponseMessage GetMediaItemToLend()
        {
            var mediaRepository = new MediaRepository();
            var mediaItemToLend = mediaRepository.MediaItemToLend();

            return Request.CreateResponse(HttpStatusCode.OK, mediaItemToLend);
        }
    }
}