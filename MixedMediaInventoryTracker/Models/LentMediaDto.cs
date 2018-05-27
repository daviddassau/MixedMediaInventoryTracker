using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MixedMediaInventoryTracker.Models
{
    public class LentMediaDto
    {
        public int Id { get; set; }
        public int MediaId { get; set; }
        public string LendeeName { get; set; }
        public int MediaConditionId { get; set; }
        public DateTime DateLent { get; set; }
        public string Notes { get; set; }
    }
}