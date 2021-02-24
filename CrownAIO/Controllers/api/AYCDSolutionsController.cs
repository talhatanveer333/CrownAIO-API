using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrownAIO.Models;

namespace CrownAIO.Controllers.api
{
    public class AYCDSolutionsController : ApiController
    {
        private ApplicationDbContext _context { get; set; }
        public AYCDSolutionsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/AYCDSolutions
        public IEnumerable<AYCDSolution> GetAYCDSolutions()
        {
            var solutions = _context.AYCDSolutions.ToList();
            if (solutions == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return solutions;
        }

        // POST /api/AYCDSolutions
        [HttpPost]
        public AYCDSolution CreateAYCDSolution(AYCDSolution solution)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.AYCDSolutions.Add(solution);
            _context.SaveChanges();

            return solution;
        }

        // PUT /api/AYCDSoltions/SettingId
        [HttpPut]
        public HttpResponseMessage EditAYCDSolution(int SettingId, [FromBody] AYCDSolution solution)
        {
            var solutionInDb = _context.AYCDSolutions.SingleOrDefault(a => a.SettingId == SettingId);
            if (solutionInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            solutionInDb.AccessToken = solution.AccessToken;
            solutionInDb.APIKey = solution.APIKey;
            solutionInDb.GeoTestCapcha = solution.GeoTestCapcha;
            solutionInDb.V2Capcha = solution.V2Capcha;
            solutionInDb.V3Capcha = solution.V3Capcha;

            _context.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE /api/AYCDSolutions/SettingId
        [HttpDelete]
        public HttpResponseMessage DeleteAYCDSolution(int SettingId)
        {
            var solutionInDb = _context.AYCDSolutions.SingleOrDefault(a => a.SettingId == SettingId);
            if (solutionInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.AYCDSolutions.Remove(solutionInDb);
            _context.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
