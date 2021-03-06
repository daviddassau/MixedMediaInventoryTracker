﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MixedMediaInventoryTracker.Models
{
    public class LentMediaModel
    {
        public int Id { get; set; }
        public string LendeeName { get; set; }
        public DateTime DateLent { get; set; }
        public string Notes { get; set; }
        public string Title { get; set; }
        public string MediaCondition { get; set; }
    }
}