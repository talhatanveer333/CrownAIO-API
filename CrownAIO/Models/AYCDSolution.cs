using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrownAIO.Models
{
    public class AYCDSolution
    {
        public int Id { get; set; }
        public int SettingId { get; set; }
        public string AccessToken { get; set; }
        public string APIKey { get; set; }
        public string V3Capcha { get; set; }
        public string V2Capcha { get; set; }
        public string GeoTestCapcha { get; set; }
    }
}