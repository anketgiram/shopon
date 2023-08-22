using EkartBussiness.Contract;
using EkartCommon.Models;
using EkartWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EkartWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerManager customerManager;
        private readonly IOrderManager orderManager;
        public HomeController(ILogger<HomeController> logger, ICustomerManager customerManager, IOrderManager orderManager)
        {
            _logger = logger;
            this.customerManager = customerManager;
            this.orderManager = orderManager;
        }

        public IActionResult Index()
        {
           var orders = orderManager.GetOrders(OrderstatusType.ORDERECEVIED);
            //var customer = customerManager.GetCustomer(4);
           /*
            var customer = new Customer()
            {
                appCustomerId = "43a40778-9d09-40ce-8609-758159177fb3",
                CustomerName = "Rahul",
                CustomerMobileNo = "9876241036",
                EmailID = "rahul@gmail.com",
                isDeleted = false,
            };
            var customerAddress = new CustomerAddress()
            {
                State = "Maharashtra",
                StName = "ShivajiNagar",
                City = "Pune"
            };
            customer.CustomerAddress = customerAddress;

            List<OrderItem> orderItems = new List<OrderItem>()
            {
                new OrderItem(){ Price = 39500, Qty = 1},
                new OrderItem(){ Price = 50500, Qty = 1}
            };

            var order = new Order()
            {
                Customer = customer,
                ClientOrderId = 110,
                OrderAmount = 900000,
                DateTime = DateTime.Now,
                ExceptedDeliveryDate = DateTime.Now.AddDays(2),
                OrderItems = orderItems
            };
            var isInserted = this.orderManager.AddOrder(order);
            //var result = this.customerManager.AddCustomer(customer);
            
            return View(order);
           */
            return View(orders);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
