using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrownAIO.Models;

namespace CrownAIO.Controllers.api
{
    public class ProxiesController : ApiController
    {
        private ApplicationDbContext _context { get; set; }
        public ProxiesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/Proxies
        public IEnumerable<Proxy> GetProxies()
        {
            var proxies = _context.Proxies.ToList();
            if (proxies == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return proxies;
        }

        // POST /api/Proxies
        [HttpPost]
        public Proxy CreateProxy(Proxy proxy)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Proxies.Add(proxy);
            _context.SaveChanges();

            return proxy;
        }


        [HttpPut]
        // PUT /api/Proxies/ProfileId
        public Proxy EditProxy(int profileId, [FromBody] Proxy proxy)
        {
            var proxyInDb = _context.Proxies.SingleOrDefault(p => p.ProfileId == profileId);
            if (proxyInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            proxyInDb.LoginId = proxy.LoginId;
            proxyInDb.Password = proxy.Password;
            proxyInDb.Port = proxy.Port;
            proxyInDb.Server = proxy.Server;

            _context.SaveChanges();

            return proxy;
        }

        // DELETE /api/Proxies/ProfileId
        [HttpDelete]
        public HttpResponseMessage DeleteProxy(int profileId)
        {
            var proxyInDb = _context.Proxies.SingleOrDefault(p => p.ProfileId == profileId);
            if (proxyInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Proxies.Remove(proxyInDb);
            _context.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}
