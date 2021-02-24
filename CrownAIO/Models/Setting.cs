using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrownAIO.Models
{
    public class Setting
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int DiscordSettingId { get; set; }
        public int AYCDSolutionId { get; set; }
        public string ActivationKey { get; set; }
        public bool PlaySoundOnSuccess { get; set; }

    }
}