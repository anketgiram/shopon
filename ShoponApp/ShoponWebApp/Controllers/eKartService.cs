using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShoponWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ShoponWebApp.Controllers
{
    public class eKartServiceController : Controller
    {
        private readonly IConfiguration configuration;

        public eKartServiceController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IActionResult SendOrder()
        {
            var orderVM = GetOrderData();
            //HttPClient for passing data from one application to another application
            using (HttpClient client = new HttpClient())
            {
                //this is address of ekart to pass the data 
                client.BaseAddress = new Uri("http://localhost:47467/api/");
                //in ekart web api we want jason data. So data passing from here that should be in jason that why we use "PostAsJsonAsync
                var postTask = client.PostAsJsonAsync<OrderVM>("Order", orderVM);
                //it will wait until post data
                postTask.Wait();
                var result = postTask.Result;
                //
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (result.IsSuccessStatusCode)
                {

                }
            }
            return View();
        }
        public async Task<IActionResult> GetOrder()
        {
            string order = string.Empty;
            //HttPClient for passing data from one application to another application
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:47467/api/Order/");
                var responseTask = client.GetAsync("http://localhost:47467/api/Order/1");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    order = await result.Content.ReadAsStringAsync();
                    var JsonResult = JsonConvert.DeserializeObject<OrderVM>(order);
                   
                }

            }
            return View(order);
        }


        private OrderVM GetOrderData()
        {
            var orderVM = new OrderVM()
            {
                ClientOrderId = 1,
                OrderAmount = 20000,
                OrderDate = DateTime.Parse("2022-9-1"),
                Customer = new Customer()
                {
                    AppCustomerId = "1009-pppc-9999-cccc",
                    EmailID = "Ravi@gmail.com",
                    CustomerName = "Ravi",
                    CustomerMobileNo = "7889001234",
                    CustomerAddress = new CustomerAddress()
                    {
                        State = "Telangana",
                        StName = "Ameerpet",
                        City = "Hyderabad"
                    },

                },
                orderItems = GetOrderItems()
            };
            return orderVM;
        }

        private ICollection<OrderItem> GetOrderItems()
        {
            return new List<OrderItem>()
            { new OrderItem()
            {
                Price=2000,
                ProductName="Nokia 1100",
                Qty=1
            },new OrderItem()
                {Price=2100,ProductName="Nokia Lumia 5500",Qty=1 }
            };
        }
    }
}
