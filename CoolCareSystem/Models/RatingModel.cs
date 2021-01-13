using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolCareSystem.Models
{
    public class RatingModel
    {
        public int WorkerId { get; set; }
        public string WorkerName { get; set; }
        public int Rating { get; set; }
    }
}