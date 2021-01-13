using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoolCareSystem.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public decimal MobileNumber { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        [AllowHtml]
        public string Description { get; set; }
        [Required]
        public Nullable<decimal> Price { get; set; }
        [Required]
        public int BilledYear { get; set; }
        public DateTime RequestedAt { get; set; }
        public bool IsApproved { get; set; }
        public bool IsAvailable { get; set; }
        public string ImageName { get; set; }
    }
}