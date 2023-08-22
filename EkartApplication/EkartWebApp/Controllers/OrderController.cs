using EkartBussiness.Contract;
using EkartWebApp.Models;
using EkartWebApp.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EkartWebApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly UserManager<EkartEF.Models.Staff> userManager;
        private readonly IOrderManager orderManager;

        public OrderController(UserManager<EkartEF.Models.Staff> userManager, IOrderManager orderManager)
        {

            //here we passing order view bcoz we want order related and user related data
            //that why we take parameters of Usermanager and IOrderManager 
            this.userManager = userManager;
            this.orderManager = orderManager;
        }



        [Authorize]
        //until and unless you are not login you shloud not come to order Conntroller
        //Authorize will check wether user is login or not
        public async Task<IActionResult> Index()
        {
            try
            {
                var user = await userManager.GetUserAsync(User);
                var city = user.City;
                var order = orderManager.GetOrders(EkartCommon.Models.OrderstatusType.ORDERECEVIED, city);

                //set the session with orders to be delivers by the staff ---> Orderstatustype - OutForDeliver
                SetOrderToDeliverToSession(user, EkartCommon.Models.OrderstatusType.ORDEROUTFORDELIVERY);

                return View(order);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpGet]
        
        public IActionResult GetOrderDetails(int id)
        {
            var order = this.orderManager.GetOrder(id);
            return View(order);
        }

        [Authorize]    
        public async Task<IActionResult> PlaceOrder(int id)
        {
            //1.Change the status of order to OutforDeliver
            try
            {
                List<OrderVM> orderToDeliver = null;
                var order = this.orderManager.GetOrder(id);
                var newOrderVM = new OrderVM()
                {
                    OrderId = order.OrderId,
                    TotalAmount = order.OrderAmount,
                    CustomerName = order.Customer.CustomerName,
                    MobileNo = order.Customer.CustomerMobileNo,
                    stName = order.Customer.CustomerAddress.StName,
                    City = order.Customer.CustomerAddress.City
                };
                var user = await userManager.GetUserAsync(User);
                // this user.id of  staffid which will come from Asp.net User 
                var staffId = user.Id;
                if(this.orderManager.UpdateOrder(order.OrderId, EkartCommon.Models.OrderstatusType.ORDEROUTFORDELIVERY, staffId))
                {
                    //2. We should set the Order data in the session

                    orderToDeliver = HttpContext.Session.GetSession<List<OrderVM>>("ORDEROUTFORDELIVERY");
                    if(orderToDeliver == null)
                    {
                        orderToDeliver = new List<OrderVM>();
                        
                    }
                    orderToDeliver.Add(newOrderVM);
                    HttpContext.Session.SetSession<List<OrderVM>>("ORDEROUTFORDELIVERY", orderToDeliver);

                }
            }
            catch (Exception e)
            {
                //in controller dont throw any exception using throw insted of use log or viewBag to throw exception
                //log
                //ViewBag.Error = e.Message
                throw;
            }
            return RedirectToAction("DisplayOrderToDeliver");
        }

        [Authorize]
        public IActionResult DisplayOrderToDeliver()
        {
           
            var sessionData = HttpContext.Session.GetSession<List<OrderVM>>("ORDEROUTFORDELIVERY");
            var cartcnt = 0;
            if(sessionData != null)
            {
                cartcnt = sessionData.Count;
            }
            HttpContext.Session.SetInt32("Cartcnt", cartcnt);
            return View(sessionData);
        }

        [Authorize]
        public async Task<IActionResult> DeliverOrder(int id)
        {
            try
            {
                var user = await userManager.GetUserAsync(User);
                var staffId = user.Id;
                var order = this.orderManager.GetOrder(id);
                if (this.orderManager.UpdateOrder(order.OrderId, EkartCommon.Models.OrderstatusType.ORDERDELIVERD, staffId))
                {
                    var sessionData = HttpContext.Session.GetSession<List<OrderVM>>("ORDEROUTFORDELIVERY");
                    var sessionObjRemove = sessionData.FirstOrDefault(x => x.OrderId == order.OrderId);

                    sessionData.Remove(sessionObjRemove);

                    var cartcnt = 0;
                    if (sessionData != null)
                    {
                        HttpContext.Session.SetSession<List<OrderVM>>("ORDEROUTFORDELIVERY", sessionData);
                        cartcnt = sessionData.Count;
                    }
                    HttpContext.Session.SetInt32("Cartcnt", cartcnt);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("DisplayOrderToDeliver");
        }

        #region Private Method
        private void SetOrderToDeliverToSession(EkartEF.Models.Staff user, EkartCommon.Models.OrderstatusType ORDEROUTFORDELIVERY)
        {
            var staffId = user.Id;
            var orderToDeliver = this.orderManager.GetOrdersToDeliverd(ORDEROUTFORDELIVERY, staffId);
            if(orderToDeliver != null)
            {
                var sessionOrders = ExtractOrderVM(orderToDeliver);
                HttpContext.Session.SetSession<List<OrderVM>>("orderToDeliver", sessionOrders);
                var cartCnt = sessionOrders.Count();
                HttpContext.Session.SetInt32("CartCnt", cartCnt);
            }
        }

        private IEnumerable<OrderVM>ExtractOrderVM(IEnumerable<EkartCommon.Models.Order> orderToDeliver)
        {
            var orders = from o in orderToDeliver
                         select new OrderVM
                         {
                             OrderId = o.OrderId,
                             TotalAmount = o.OrderAmount,
                             CustomerName = o.Customer.CustomerName,
                             MobileNo = o.Customer.CustomerMobileNo,
                             stName = o.Customer.CustomerAddress.StName,
                             City = o.Customer.CustomerAddress.City
                         };
            return orders;
        }
        #endregion
    }
}
