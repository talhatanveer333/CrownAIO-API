using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrownAIO.Models
{
    public class ShippingAddress
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public string ProfileName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public bool BillingSameAsShipping { get; set; }

    }
}