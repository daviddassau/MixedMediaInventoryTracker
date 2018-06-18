using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MixedMediaInventoryTracker.Models
{
    public class SoldMediaItemDetailsModel
    {
        public int Id { get; set; }
        public string Buyer { get; set; }
        public int? Amount { get; set; }
        public DateTime SoldDate { get; set; }
        public string Notes { get; set; }
        public string Title { get; set; }
        public string MediaCondition { get; set; }
        public string artworkUrl100 { get; set; }
    }
}