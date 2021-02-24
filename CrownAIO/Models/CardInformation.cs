using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrownAIO.Models
{
    public class CardInformation
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public double CardNumber { get; set; }
        public DateTime Expiration { get; set; }
        public int CVV { get; set; }
        public string CardHolderName { get; set; }
    }
}