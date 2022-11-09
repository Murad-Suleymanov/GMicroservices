﻿namespace Shoping.Aggregator.Models
{
    public class OrderResponseModel
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }

        // BillingAddress
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        // Payment
        public int? CurierId { get; set; }
        public bool? IsDelivered { get; set; }
    }
}
