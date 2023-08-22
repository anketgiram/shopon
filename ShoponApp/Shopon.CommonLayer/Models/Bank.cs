using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponCommonLayer.Models
{
    public class Bank
    {
        public Bank()
        {
            this.offers = new List<Offer>();
        }
        public int BankId { get; set; }
        public string Bankname { get; set; }
        public string City { get; set; }
        public string IFSC { get; set; }
        private List<Offer> offers = null;

        /// <summary>
        /// Method to add Offers
        /// </summary>
        /// <param name="offer"></param>
        public void AddOffer(Offer offer)
        {
            this.offers.Add(offer);
        }
        /// <summary>
        /// Method to get offers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Offer> GetOffers()
        {
            return this.offers;
        }
    }
}

