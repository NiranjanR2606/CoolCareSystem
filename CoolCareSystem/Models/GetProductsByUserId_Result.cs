//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoolCareSystem.Models
{
    using System;
    
    public partial class GetProductsByUserId_Result
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> RequestedAt { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> BilledYear { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
    }
}
