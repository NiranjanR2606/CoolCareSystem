using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoolCareSystem.Models
{
    public class ServiceModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string WorkerName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public decimal MobileNumber { get; set; }
        public Nullable<int> UserId { get; set; }
        [Required]
        public Nullable<int> WorkerId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        [AllowHtml]
        public string Service_Issue { get; set; }
        [Required]
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> RequestedAt { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public string Status { get; set; }
        public int Rating { get; set; }
        public virtual User User { get; set; }
        public virtual Worker Worker { get; set; }
        public IEnumerable<SelectListItem> Workers { get; set; }
    }
}