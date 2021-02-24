using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrownAIO.Models
{
    public class UserActivity
    {
        public int Id { get; set; }
        public int profileId { get; set; }
        public string IPAddress { get; set; }
        public string Location { get; set; }

    }
}