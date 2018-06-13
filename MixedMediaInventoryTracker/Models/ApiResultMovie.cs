using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MixedMediaInventoryTracker.Models
{
    public class ApiResultMovie
    {
        public int resultCount { get; set; }
        public List<SearchResultMovie> results { get; set; }
    }
}