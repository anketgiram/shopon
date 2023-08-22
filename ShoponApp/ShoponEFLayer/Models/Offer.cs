using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponEFLayer.Models
{
   
    public class Offer
    {
       
        public int OfferId { get; set; }
        public string OfferType { get; set; }
        public DateTime OfferTime { get; set; }
        public int Discount { get; set; }
        public string  Remark { get; set; }
        public int BankId { get; set; }
        public Bank Bank { get; set; }
    }
}
