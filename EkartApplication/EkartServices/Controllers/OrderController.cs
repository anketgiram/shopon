using EkartBussiness.Contract;
using EkartCommon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EkartServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //in api controller you get annotated by [ApiController] like this. this is comes from "Microsoft.AspNetCore.Mvc.ApiControllerAttribute"
    //if you not menstion or not use this [ApiController] this controller is still works but this ApiController==> has loat of advantages like model binding, annotating, variations all this is part of api contriller

    //[Route("api/[controller]")] == any request comes as "protocal/domain name/api/order(any method name) this how your request is hiys. so for that this  [Route("api/[controller]")] is worls
    public class OrderController : ControllerBase
    {
        private readonly IOrderManagerAsync orderManagerAsync;

        public OrderController(IOrderManagerAsync orderManagerAsync)
        {
            this.orderManagerAsync = orderManagerAsync;
        }

        //GET: /api/Orders/
        [HttpGet("{id:int}")]  //=> this how you pass get method  id which is int type
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var order = await orderManagerAsync.Get(id);
                if(order == null)
                {
                    return NotFound($"Order with {id} does not exists");
                }
                return Ok(order);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error retriving Order from Server.");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            //remebere the things while create method
            //1 return http status code 201
            //2 include location header in the response

            try
            {
                if(order == null)
                {
                    return BadRequest($"Invalid order");
                }
                else if(order.Customer == null)
                {
                    return BadRequest($"Customer information is missing.");

                }
                else if(order.Customer.CustomerAddress == null)
                {
                    return BadRequest($"Customer address information is missing.");
                }
                var result = await this.orderManagerAsync.Add(order);
                return CreatedAtAction(nameof(Get), new { Id = result.OrderId }, result);


                //where we creating we have to retrun status code 201 and newly cretaed objet and location(location means Url)
                //1) "nameof(Get)"  ==  to get the rescoure we we use Get method with   
                //2) "new { orderId = result.OrderId }" == order id as parameter and this is present in above
                //3) "result"  == this is for sending result

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                           "Error adding new Order.");
                
            }
        }
    }
}
