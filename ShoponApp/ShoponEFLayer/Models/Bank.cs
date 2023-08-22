using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponEFLayer.Models
{
    public class Bank
    {
        public Bank()
        {
            this.Offers = new List<Offer>();
        }
        public int BankId { get; set; }
        public string Bankname { get; set; }
        public string  City { get; set; }
        public string IFSC { get; set; }
        public ICollection<Offer> Offers { get; set; }
        
        ///// <summary>
        ///// Method to add Offers
        ///// </summary>
        ///// <param name="offer"></param>
        //public void AddOffer(Offer offer)
        //{
        //    this.Offers.Add(offer);
        //}
        ///// <summary>
        ///// Method to get offers
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable<Offer> GetOffers()
        //{
        //    return this.Offers;
        //}
    }
}
