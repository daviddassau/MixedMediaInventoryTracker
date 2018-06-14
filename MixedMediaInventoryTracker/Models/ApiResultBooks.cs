using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MixedMediaInventoryTracker.Models
{
    public class ApiResultBooks
    {
        public int resultCount { get; set; }
        public List<SearchResultBooks> results { get; set; }
    }
}