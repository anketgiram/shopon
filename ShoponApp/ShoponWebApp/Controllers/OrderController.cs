using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoponBusinessLayer.Contracts;
using ShoponCommonLayer.Models;
using ShoponWebApp.Models;
using ShoponWebApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShoponWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderManager orderManager;

        public OrderController(IOrderManager orderManager)
        {
            this.orderManager = orderManager;
        }

        [Authorize]
        public IActionResult PlaceOrder()
        {
            //Caputure DeliveryAddress Details-Assignment
            //Capture PayementbDetails-Assignment
            //create order
            //insert order with orderitem
            var cartData = HttpContext.Session.GetSession<List<CartVM>>("CartData");
            if(cartData==null || cartData.Count==0)
            {
                RedirectToAction("DisplaycartData", "Cart");
            }
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customerID =string.Empty;
            double totalAmount = 0;
            var newOrder = new Order()
            {
                AspCustomerId = userId,
                OrderDate = DateTime.UtcNow,
                OrderTotal = totalAmount,     
            };
            foreach (var cartItem in cartData)
            {
                newOrder.AddOrderItem(new ShoponCommonLayer.Models.OrderItem()
                {
                    Qty=cartItem.Qty,
                    Product=new Product()
                    {
                        PId=cartItem.PId,
                        ProductName=cartItem.ProductName,
                        Price=cartItem.Price,
                        ImageUrl=cartItem.ImageUrl,
                    }
                });
                totalAmount += cartItem.TotalAmount;
            }
            newOrder.OrderTotal = totalAmount;
            this.orderManager.AddOrder(newOrder);
            ClearSession();
            return View(newOrder);
        }

        private void ClearSession()
        {
            HttpContext.Session.Clear();
        }
    }
}
