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

        [HttpGet, Route("mediaItemDetails/{id}")]
        public HttpResponseMessage GetSingleItemDetails(int id)
        {
            var mediaRepository = new MediaRepository();
            var itemDetails = mediaRepository.ItemDetails(id);

            return Request.CreateResponse(HttpStatusCode.OK, itemDetails);
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

        [HttpGet, Route("mediaItemToSell")]
        public HttpResponseMessage GetMediaItemToSell()
        {
            var mediaRepository = new MediaRepository();
            var mediaItemToSell = mediaRepository.MediaItemToSell();

            return Request.CreateResponse(HttpStatusCode.OK, mediaItemToSell);
        }

        [HttpGet, Route("searchMovies/{term}")]
        public HttpResponseMessage SearchForMovies(string term)
        {
            var mediaRepository = new MediaRepository();
            var result = mediaRepository.SearchMediaItemMovie(term);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet, Route("searchMusic/{term}")]
        public HttpResponseMessage SearchForMusic(string term)
        {
            var mediaRepository = new MediaRepository();
            var result = mediaRepository.SearchMediaItemMusic(term);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet, Route("searchBooks/{term}")]
        public HttpResponseMessage SearchForBooks(string term)
        {
            var mediaRepository = new MediaRepository();
            var result = mediaRepository.SearchMediaItemBooks(term);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet, Route("getRecentlyAdded")]
        public HttpResponseMessage RecentlyAddedItems()
        {
            var mediaRepository = new MediaRepository();
            var result = mediaRepository.RecentlyAddedItems();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet, Route("chartMediaLentOut")]
        public HttpResponseMessage ChartItemsLentOut()
        {
            var mediaRepository = new MediaRepository();
            var result = mediaRepository.ChartLentOutItems();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet, Route("chartMediaByType")]
        public HttpResponseMessage MediaByType()
        {
            var mediaRepository = new MediaRepository();
            var result = mediaRepository.GetMediaByType();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}