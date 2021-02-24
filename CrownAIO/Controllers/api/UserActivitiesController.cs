using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrownAIO.Models;

namespace CrownAIO.Controllers.api
{
    public class UserActivitiesController : ApiController
    {
        private ApplicationDbContext _context { get; set; }
        public UserActivitiesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/UserActivities
        public IEnumerable<UserActivity> GetUserActivities()
        {
            var activities = _context.UserActivities.ToList();
            if (activities == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return activities;
        }

        // POST /api/UserActivities
        [HttpPost]
        public UserActivity CreateUserActivity(UserActivity activity)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.UserActivities.Add(activity);
            _context.SaveChanges();

            return activity;
        }

        // PUT /api/UserActivities/profileId
        [HttpPut]
        public UserActivity EditUserActivity(int profileId, [FromBody] UserActivity activity)
        {
            var activityInDb = _context.UserActivities.SingleOrDefault(u => u.profileId == profileId);
            if (activityInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            activityInDb.IPAddress = activity.IPAddress;
            activityInDb.Location = activity.Location;

            _context.SaveChanges();

            return activity;
        }

        // DELETE /api/UserActivities/profileId
        [HttpDelete]
        public HttpResponseMessage DeleteUserActivity(int profileId)
        {
            var activityInDb = _context.UserActivities.SingleOrDefault(u => u.profileId == profileId);
            if (activityInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.UserActivities.Remove(activityInDb);
            _context.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
