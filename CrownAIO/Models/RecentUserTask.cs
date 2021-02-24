using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrownAIO.Models
{
    public class RecentUserTask
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public string ProxyId { get; set; }
        public string Store { get; set; }
        public string Product { get; set; }
        public string Size { get; set; }
        public string Status { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime EditDateTime { get; set; }

    }
}