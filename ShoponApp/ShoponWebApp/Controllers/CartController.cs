using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoponBusinessLayer.Contracts;
using ShoponWebApp.Models;
using ShoponWebApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoponWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductManager productManager;

        public CartController(IProductManager productManager)
        {
            this.productManager = productManager;
        }
        public IActionResult AddToCart(int pid)
        {
            var product = this.productManager.GetProductById(pid);
            if(product!=null)
            {
                var cartVM = new CartVM()   //the product we obtained is commonlayer.model.product,we need to convert it into CartVm product
                {
                    PId=product.PId,
                    ImageUrl=product.ImageUrl,
                    Price=product.Price,
                    ProductName=product.ProductName,
                    Qty=1,
                    TotalAmount=product.Price*1
                };
                //In 2 ways the cart info can be displayed
                //1.From add to cart
                //2.From the cart icon from the navbar
                //so we dont directly pass it to the view here,for using 2 method we redirecting the action
                //To pass some data between 2 Action methods we need to store it in TempData(because http is a stateless protocol)

                //TempData["Cart"] = JsonConvert.SerializeObject(cartVM);       //store the data only after serialize(only for one data at a time)






                /**WHEN MORE THAN ONE DATA USE SESSION*/

                //first check if the session had cart data,fetch the session data to a list
                var cartVMs = HttpContext.Session.GetSession<List<CartVM>>("CartData");
                if (cartVMs == null)
                {
                    cartVMs = new List<CartVM>();
                }
                var cartVMProduct = cartVMs.FirstOrDefault(x => x.PId == cartVM.PId);
                if(cartVMProduct==null)
                {
                    //add new data to a temporary list
                    cartVMs.Add(cartVM);
                }
                else
                {
                    if(cartVMProduct.Qty==5)
                    {
                        //Console.WriteLine("You have reached the maximum quantity");
                    }
                    else
                    {
                        cartVMProduct.Qty += 1;
                        cartVMProduct.TotalAmount = cartVMProduct.Qty * cartVMProduct.Price;
                    }                    
                }
                var cartCnt = cartVMs.Count();                
                HttpContext.Session.SetInt32("CartCnt", cartCnt);
                //push the new list to session
                HttpContext.Session.SetSession<List<CartVM>>("CartData", cartVMs);
            }
            return RedirectToAction("DisplayCartData");
        }
        //public IActionResult BuyNow(int pid)
        //{
        //    var product = this.productManager.GetProductById(pid);
        //    if (product != null)
        //    {
        //        var cartVM = new CartVM()
        //        {
        //            PId = product.PId,
        //            ImageUrl = product.ImageUrl,
        //            Price = product.Price,
        //            ProductName = product.ProductName,
        //            Qty = 1,
        //            TotalAmount = product.Price * 1
        //        };
        //        var cartVMs = HttpContext.Session.GetSession<List<CartVM>>("CartData");
        //    }
        //    return RedirectToAction("PlaceOrder","Order");
        //}
        public IActionResult DisplayCartData()
        {
            //var cartVM = JsonConvert.DeserializeObject<CartVM>(TempData["Cart"].ToString()); //fetch the data from the Tempdata
            var cartVMs = HttpContext.Session.GetSession<List<CartVM>>("CartData");
            var cartCnt = 0;
            if(cartVMs!=null)
            {
                cartCnt = cartVMs.Count();
            }
           
            HttpContext.Session.SetInt32("CartCnt", cartCnt);

            ViewBag.CartCnt = cartCnt;
            return View(cartVMs);                                                    //if the view name is changed then need to mention the name return View("cart",cartVM)
        }

        public IActionResult DeleteCart(int id)
        {
            //get the list of cart from the session
            var cartVMs = HttpContext.Session.GetSession<List<CartVM>>("CartData");
            var cartVM = cartVMs.FirstOrDefault(x => x.PId == id);
            cartVMs.Remove(cartVM);
            //set the list to session(if not empty)
            var cartCnt = cartVMs.Count();
            HttpContext.Session.SetInt32("CartCnt", cartCnt);

            //ViewBag.CartCnt = cartCnt;

            HttpContext.Session.SetSession<List<CartVM>>("CartData", cartVMs);
            //redirect to displaycartdata page
            return RedirectToAction("DisplayCartData");
        }

        public IActionResult UpdateCart(int id,int qty,double amount)
        {
            var cartVMs = HttpContext.Session.GetSession<List<CartVM>>("CartData");
            var cartVM = cartVMs.FirstOrDefault(x => x.PId == id);
            cartVM.Qty = qty;
            cartVM.TotalAmount = amount;
            HttpContext.Session.SetSession<List<CartVM>>("CartData", cartVMs);
            return RedirectToAction("DisplayCartData");
        }
        
    }
}
