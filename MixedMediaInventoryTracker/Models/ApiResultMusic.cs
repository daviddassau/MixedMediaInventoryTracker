using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MixedMediaInventoryTracker.Models
{
    public class ApiResultMusic
    {
        public int resultCount { get; set; }
        public List<SearchResultMusic> results { get; set; }
    }
}