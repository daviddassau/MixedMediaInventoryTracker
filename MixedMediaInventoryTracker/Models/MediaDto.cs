using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MixedMediaInventoryTracker.Models
{
    public class MediaDto
    {
        public int Id { get; set; }
        public int MediaTypeId { get; set; }
        public int MediaConditionId { get; set; }
        public string Title { get; set; }
        public DateTime? DatePurchased { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsLentOut { get; set; }
        public bool? IsSold { get; set; }
        public string Notes { get; set; }
    }
}