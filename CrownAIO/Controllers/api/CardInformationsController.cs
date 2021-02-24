using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrownAIO.Models;

namespace CrownAIO.Controllers.api
{
    public class CardInformationsController : ApiController
    {
        private ApplicationDbContext _context { get; set; }
        public CardInformationsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/CardInformations/
        public IEnumerable<CardInformation> GetCardInformations()
        {
            var cardInfos = _context.CardInformations.ToList();
            if (cardInfos == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return cardInfos;
        }


        [HttpPost]
        // POST /api/CardInformations/
        public CardInformation CreateCardInformation(CardInformation CardInformation)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.CardInformations.Add(CardInformation);
            _context.SaveChanges();

            return CardInformation;
        }

        // PUT /api/cardInformations/profileId
        [HttpPut]
        public CardInformation EditCardInformation(int profileId,[FromBody] CardInformation cardInformation)
        {
            var cardInformationInDb = _context.CardInformations.SingleOrDefault(c => c.ProfileId == profileId);
            if (cardInformationInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            cardInformationInDb.CardHolderName = cardInformation.CardHolderName;
            cardInformationInDb.CardNumber = cardInformation.CardNumber;
            cardInformationInDb.CVV = cardInformation.CVV;
            cardInformationInDb.Expiration = cardInformation.Expiration;

            _context.SaveChanges();

            return cardInformation;
        }


        // DELETE /api/CardInformations/profileId
        [HttpDelete]
        public HttpResponseMessage DeleteCardInformation(int profileId)
        {
            var CardInformationInDb = _context.CardInformations.SingleOrDefault(p => p.ProfileId == profileId);
            if (CardInformationInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.CardInformations.Remove(CardInformationInDb);
            _context.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
