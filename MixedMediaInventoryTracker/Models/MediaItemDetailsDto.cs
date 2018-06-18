using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MixedMediaInventoryTracker.Models
{
    public class MediaItemDetailsDto
    {
        public int Id { get; set; }
        public int MediaTypeId { get; set; }
        public string Title { get; set; }
        public DateTime? DatePurchased { get; set; }
        public DateTime? DateAdded { get; set; }
        public string IsLentOut { get; set; }
        public string IsSold { get; set; }
        public string Notes { get; set; }
        public string MediaCondition { get; set; }
        public string MediaType { get; set; }
        public string artworkUrl100 { get; set; }
        public string Artist { get; set; }
        public string Image { get; set; }
        public string Author { get; set; }
    }
}