using Microsoft.EntityFrameworkCore;
using ShoponCommonLayer.Models;
using ShoponDataLayer.Contracts;
using ShoponEFLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponEFLayer.Implementation
{
    public class BankRepositoryEFImpl : IBankRepository
    {
        private readonly db_shoponContext context;
        public BankRepositoryEFImpl()
        {
            this.context = new db_shoponContext();
        }

        public bool AddBank(ShoponCommonLayer.Models.Bank bank)
        {
            //1.check whether the bank exist using ifsc code
            //2.if the bank exist add only offers
            //3.else add bank and offers
            bool isAdded = false;
            
            try
            {
                //this.context.Entry(bank).State = EntityState.Detached;
                var bankExist = this.context.Entry(bank);
                if (bankExist.State== EntityState.Added)
                {
                    this.context.Entry(bank).State = EntityState.Detached;
                }
                isAdded = Savebank(bank);
               // var bankExists = this.context.Banks.FirstOrDefault(x => x.IFSC == bank.IFSC);
               // if (bankExists==null)
               // {
               //     isAdded = Savebank(bank);
               // }
               //else
               // {
               //     isAdded = SaveOffers(bank);
               // }
              
            }
            catch (Exception)
            {

                throw;
            }
         
            return isAdded;
        }

        private bool SaveOffers(ShoponCommonLayer.Models.Bank bank)
        {
            bool isSaved = false;
            var offersDb = ExtractOffers(bank.GetOffers());
            foreach (var offer in offersDb)
            {
                offer.BankId = bank.BankId;
                this.context.Add(offer);
            }
            this.context.SaveChanges();
            isSaved = true;
            return isSaved;
        }

        private ICollection<Models.Offer> ExtractOffers(IEnumerable<ShoponCommonLayer.Models.Offer> offers)
        {
            //List<Models.Offer> offersDb = new List<Models.Offer>();
            //foreach (var offer in offers)
            //{
            //    Models.Offer offerDb = new Models.Offer()
            //    {
            //        BankId=offer.BankId,
            //        OfferTime=offer.OfferTime,
            //        OfferType=offer.OfferType,
            //        Discount=offer.Discount,
            //        Remark=offer.Remark

            //    };
            //    offersDb.Add(offerDb);
            //}
                var offersDb = from offer in offers
                           select new Models.Offer
                           {
                               BankId = offer.BankId,
                               OfferTime = offer.OfferTime,
                               OfferType = offer.OfferType,
                               Discount = offer.Discount,
                               Remark = offer.Remark
                               //OfferId=offer.OfferId
                               
                           };
            return offersDb.ToList();
        }
        private bool Savebank(ShoponCommonLayer.Models.Bank bank)
        {
            bool isAdded = false;
            try
            {
                var bankDb = new Models.Bank()
                {
                    Bankname = bank.Bankname,
                    City = bank.City,
                    IFSC = bank.IFSC,
                    Offers = ExtractOffers(bank.GetOffers())
                };
                this.context.Add(bankDb);
                this.context.SaveChanges();
                isAdded = true;
            }
            catch (Exception)
            {

                throw;
            }
            return isAdded;

        }

        public IEnumerable<ShoponCommonLayer.Models.Bank> GetBanks()
        {
            throw new NotImplementedException();
        }
    }
}
