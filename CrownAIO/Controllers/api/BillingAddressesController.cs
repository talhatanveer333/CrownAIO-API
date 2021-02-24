using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrownAIO.Models;

namespace CrownAIO.Controllers.api
{
    public class BillingAddressesController : ApiController
    {
        private ApplicationDbContext _context { get; set; }
        public BillingAddressesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/BillingAddresses/
        public IEnumerable<BillingAddress> GetBillingAddresses()
        {
            var BillingAddresses = _context.BillingAddresses.ToList();
            if (BillingAddresses == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return BillingAddresses;
        }


        [HttpPost]
        // POST /api/BillingAddresses/
        public BillingAddress CreateBillingAddress(BillingAddress BillingAddress)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.BillingAddresses.Add(BillingAddress);
            _context.SaveChanges();

            return BillingAddress;
        }


        // PUT /api/BillingAddresses/profileId
        [HttpPut]
        public BillingAddress EditBillingAddress(int profileId, [FromBody] BillingAddress BillingAddress)
        {
            var BillingAddressInDb = _context.BillingAddresses.SingleOrDefault(s => s.ProfileId == profileId);
            if (BillingAddressInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            BillingAddressInDb.Address1 = BillingAddress.Address1;
            BillingAddressInDb.Address2 = BillingAddress.Address2;
            BillingAddressInDb.City = BillingAddress.City;
            BillingAddressInDb.Country = BillingAddress.Country;
            BillingAddressInDb.Email = BillingAddress.Email;
            BillingAddressInDb.FirstName = BillingAddress.FirstName;
            BillingAddressInDb.LastName = BillingAddress.LastName;
            BillingAddressInDb.PhoneNumber = BillingAddress.PhoneNumber;
            BillingAddressInDb.ProfileName = BillingAddress.ProfileName;
            BillingAddressInDb.State = BillingAddress.State;
            BillingAddressInDb.ZipCode = BillingAddress.ZipCode;

            _context.SaveChanges();

            return BillingAddress;
        }

        // DELETE /api/BillingAddresses/profileId
        [HttpDelete]
        public void DeleteBillingAddress(int profileId)
        {
            var BillingAddressInDb = _context.BillingAddresses.SingleOrDefault(p => p.ProfileId == profileId);
            if (BillingAddressInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.BillingAddresses.Remove(BillingAddressInDb);
            _context.SaveChanges();
        }
    }
}
