using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrownAIO.Models
{
    public class Proxy
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public string Server { get; set; }
        public string Port { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
    }
}