using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrownAIO.Models
{
    public class DiscordSetting
    {
        public int Id { get; set; }
        public int SettingId { get; set; }
        public string WebHook { get; set; }
        public bool SuccessNotificationsOnly { get; set; }
        public bool SendOnFailure { get; set; }
    }
}