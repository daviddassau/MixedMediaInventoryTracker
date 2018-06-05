using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MixedMediaInventoryTracker.Models
{
    public class SoldMediaDto
    {
        public int Id { get; set; }
        public int MediaId { get; set; }
        public string Buyer { get; set; }
        public float? Amount { get; set; }
        public DateTime SoldDate { get; set; }
        public string Notes { get; set; }
        public int MediaConditionId { get; set; }
    }
}