using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrownAIO.Models;

namespace CrownAIO.Controllers.api
{
    public class ShippingAddressesController : ApiController
    {
        private ApplicationDbContext _context { get; set; }
        public ShippingAddressesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/ShippingAddresses/
        public IEnumerable<ShippingAddress> GetShippingAddresses()
        {
            var shippingAddresses = _context.ShippingAddresses.ToList();
            if (shippingAddresses == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return shippingAddresses;
        }


        [HttpPost]
        // POST /api/ShippingAddresses/
        public ShippingAddress CreateShippingAddress(ShippingAddress ShippingAddress)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.ShippingAddresses.Add(ShippingAddress);
            _context.SaveChanges();

            return ShippingAddress;
        }

        // PUT /api/shippingAddresses/profileId
        [HttpPut]
        public ShippingAddress EditShippingAddress(int profileId, [FromBody] ShippingAddress shippingAddress)
        {
            var shippingAddressInDb = _context.ShippingAddresses.SingleOrDefault(p => p.ProfileId == profileId);
            if (shippingAddressInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            shippingAddressInDb.Address1 = shippingAddress.Address1;
            shippingAddressInDb.Address2 = shippingAddress.Address2;
            shippingAddressInDb.BillingSameAsShipping = shippingAddress.BillingSameAsShipping;
            shippingAddressInDb.City = shippingAddress.City;
            shippingAddressInDb.Country = shippingAddress.Country;
            shippingAddressInDb.Email = shippingAddress.Email;
            shippingAddressInDb.FirstName = shippingAddress.FirstName;
            shippingAddressInDb.LastName = shippingAddress.LastName;
            shippingAddressInDb.PhoneNumber = shippingAddress.PhoneNumber;
            shippingAddressInDb.ProfileName = shippingAddress.ProfileName;
            shippingAddressInDb.State = shippingAddress.State;
            shippingAddressInDb.ZipCode = shippingAddress.ZipCode;

            _context.SaveChanges();

            return shippingAddress;
        }


        // DELETE /api/ShippingAddresses/profileId
        [HttpDelete]
        public void DeleteShippingAddress(int profileId)
        {
            var ShippingAddressInDb = _context.ShippingAddresses.SingleOrDefault(p => p.ProfileId == profileId);
            if (ShippingAddressInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.ShippingAddresses.Remove(ShippingAddressInDb);
            _context.SaveChanges();
        }
    }
}
