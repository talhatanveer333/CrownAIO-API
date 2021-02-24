using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrownAIO.Models;

namespace CrownAIO.Controllers.api
{
    public class SettingsController : ApiController
    {
        private ApplicationDbContext _context { get; set; }
        public SettingsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/Settings
        public IEnumerable<Setting> GetSettings()
        {
            var settings = _context.Settings.ToList();
            if (settings == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return settings;
        }

        // POST /api/Settings
        [HttpPost]
        public Setting CreateSetting(Setting setting)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Settings.Add(setting);
            return setting;
        }

        // PUT /api/Settings/ProfileId
        public HttpResponseMessage EditSetting(int profileId, [FromBody] Setting setting)
        {
            var settingInDb = _context.Settings.SingleOrDefault(s => s.ProfileId == profileId);
            if (settingInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            settingInDb.ActivationKey = setting.ActivationKey;
            settingInDb.PlaySoundOnSuccess = setting.PlaySoundOnSuccess;

            _context.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE /api/Settings/ProfileId
        [HttpDelete]
        public HttpResponseMessage DeleteSetting(int profileId)
        {
            var settingInDb = _context.Settings.SingleOrDefault(s => s.ProfileId == profileId);
            if (settingInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Settings.Remove(settingInDb);
            _context.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
