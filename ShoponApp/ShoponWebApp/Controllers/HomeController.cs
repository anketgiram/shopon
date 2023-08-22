using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoponBusinessLayer.Contracts;
using ShoponWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShoponWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IProductManager productManager;

        public HomeController(ILogger<HomeController> logger,IProductManager productManager)
        {
            _logger = logger;
            this.productManager = productManager;
        }

        public IActionResult Index(int pg=1)
        {
            var products = this.productManager.GetProducts();
            const int pageSize = 20;
            if(pg<1)
            {
                pg = 1;
            }
            int recordCount = products.Count();
            var pager = new Pager(recordCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = products.Skip(recSkip).Take(pageSize).ToList();
            this.ViewBag.Pager = pager;  //allows you to share values dynamically to the view from the controller.

            //return View(products);
            return View(data);
        }

        [HttpPost]
        public IActionResult Search(string key)
        {
            if(key==null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var products = this.productManager.SearchByKey(key);
                return View("Index",products);
            }
            
        }
        public IActionResult Details(int pid)
        {
            var product = this.productManager.GetProductById(pid);
            return View(product);
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
