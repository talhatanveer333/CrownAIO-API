using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrownAIO.Models;

namespace CrownAIO.Controllers.api
{
    public class ProfilesController : ApiController
    {
        private ApplicationDbContext _context { get; set; }
        public ProfilesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/Profiles/
        public IEnumerable<Profile> GetProfiles()
        {
            var proflies = _context.Profiles.ToList();
            if (proflies == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return proflies;
        }

        // GET /api/Profiles/id
        public Profile GetProfiles(int id)
        {
            var proflieInDb = _context.Profiles.SingleOrDefault(p => p.Id == id);
            if (proflieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return proflieInDb;
        }

        [HttpPost]
        // POST /api/Profiles/
        public Profile CreateProfile(Profile profile)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Profiles.Add(profile);
            _context.SaveChanges();

            return profile;
        }


        // PUT /api/Profiles/Id
        [HttpPut]
        public Profile EditProfile(int id,[FromBody] Profile profile)
        {
            var profileInDb = _context.Profiles.SingleOrDefault(p => p.Id == id);
            if (profileInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            profileInDb.Changes = profile.Changes;
            profileInDb.Name = profile.Name;
            profileInDb.ProfilePicUrl = profile.ProfilePicUrl;
            profileInDb.TotalDeclines = profile.TotalDeclines;
            profileInDb.TotalRevenue = profile.TotalRevenue;

            _context.SaveChanges();

            return profile;
        }

        // DELETE /api/Profiles/id
        [HttpDelete]
        public HttpResponseMessage DeleteProfile(int id)
        {
            var profileInDb = _context.Profiles.SingleOrDefault(p => p.Id == id);
            if (profileInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Profiles.Remove(profileInDb);
            _context.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
