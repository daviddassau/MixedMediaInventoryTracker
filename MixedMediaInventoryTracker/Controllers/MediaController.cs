using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MixedMediaInventoryTracker.Models;
using MixedMediaInventoryTracker.Services;

namespace MixedMediaInventoryTracker.Controllers
{
    [RoutePrefix("api/media")]
    public class MediaController : ApiController
    {
        [Route(""), HttpPost]
        public HttpResponseMessage Create(MediaModel media)
        {
            var mediaRepository = new MediaRepository();
            var result = mediaRepository.Create(media);


        }


        //[Route(""), HttpPost]
        //public HttpResponseMessage CreateProduct(Product product)
        //{
        //    var productRepository = new ProductRepository();
        //    var result = productRepository.Create(product);

        //    if (result)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.Created);
        //    }

        //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not create product, try again later");
        //}
    }
}