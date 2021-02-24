using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrownAIO.Models;

namespace CrownAIO.Controllers.api
{
    public class DiscordSettingsController : ApiController
    {
        private ApplicationDbContext _context { get; set; }
        public DiscordSettingsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/DiscordSettings/
        public IEnumerable<DiscordSetting> GetDiscordSettings()
        {
            var discordSettings = _context.DiscordSettings.ToList();
            if (discordSettings == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return discordSettings;
        }

        // POST /api/DiscordSettings/
        [HttpPost]
        public DiscordSetting CreateDiscordSettings(DiscordSetting discordSetting)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.DiscordSettings.Add(discordSetting);
            _context.SaveChanges();

            return discordSetting;
        }

        // PUT /api/DiscordSettings/settingId
        [HttpPut]
        public DiscordSetting EditDiscordSetting(int settingId,[FromBody] DiscordSetting discordSetting)
        {
            var discordSettingInDb = _context.DiscordSettings.SingleOrDefault(d => d.SettingId == settingId);
            if (discordSettingInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            discordSettingInDb.SendOnFailure = discordSetting.SendOnFailure;
            discordSettingInDb.SuccessNotificationsOnly = discordSetting.SuccessNotificationsOnly;
            discordSettingInDb.WebHook = discordSetting.WebHook;

            _context.SaveChanges();

            return discordSetting;
        }

        // DELETE /api/DiscordSettings/SettingId
        [HttpDelete]
        public HttpResponseMessage DeleteDiscordSetting(int SettingId)
        {
            var discordSettingInDb = _context.DiscordSettings.SingleOrDefault(d => d.SettingId == SettingId);
            if (discordSettingInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.DiscordSettings.Remove(discordSettingInDb);
            _context.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
