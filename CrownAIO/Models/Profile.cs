using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrownAIO.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public int CardInformationId { get; set; }
        public int ShippingAddressId { get; set; }
        public int SettingId { get; set; }
        public string Name { get; set; }
        public string ProfilePicUrl { get; set; }
        public double TotalRevenue { get; set; }
        public int TotalDeclines { get; set; }
        public double Changes { get; set; }
        

    }
}