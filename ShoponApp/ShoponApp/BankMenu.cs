using ShoponBusinessLayer.Contracts;
using ShoponBusinessLayer.Implementation;
using ShoponCommonLayer.Models;
using ShoponDataLayer.Contracts;
using ShoponEFLayer.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponConsoleApp
{
    public class BankMenu
    {
        public void BankMainMenu()
        {
            IBankRepository bankRepository = new BankRepositoryEFImpl();
            IBankManager bankManager = new BankManager(bankRepository);
            AddBank(bankManager);
        }

        private void AddBank(IBankManager bankManager)
        {
            Bank bank1 = new Bank()
            {
                Bankname="HDFC",
                City="Thrissur",
                IFSC="HDFC00234",
                BankId=1
            };
            Offer offer1 = new Offer()
            {
                Discount = 10,
                OfferType="Vishu Offer",
                Remark="Get 10% Discount on credit card payment",
                OfferTime=new DateTime(2022,6,13),
                //BankId=1
                //Bank=bank1
            };
            Offer offer2 = new Offer()
            {
                Discount = 9,
                OfferType= "Vishu Offer",
                Remark = "Get 9% Discount on UPI payment",
                OfferTime = new DateTime(2022,6,13),
                BankId=1
                //Bank = bank1
            };
            bank1.AddOffer(offer1);
            bank1.AddOffer(offer2);
            try
            {
                if (bankManager.AddBank(bank1))
                {
                    Console.WriteLine("Bank Added");
                }
                else
                {
                    Console.WriteLine("Bank not added");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
