using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoponBusinessLayer.Contracts;
using ShoponCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnWebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductAsyncManager productManager;

        public ProductsController(IProductAsyncManager productManager)
        {
            this.productManager = productManager;
        }

        //GET: /api/Products
        /// <summary>
        /// Return all products
        /// </summary>
        /// <returns>A List of Products</returns>
        /// <remarks>
        ///     Sample request:
        ///     
        ///         GET:/api/Products
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var products = await this.productManager.GetProducts();
                return Ok(products);
            }
            catch (Exception e)
            {
                //Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving products from sever");
            }
        }

        //GET: /api/Products/1
        /// <summary>
        /// Return a product
        /// </summary>
        /// <returns>A Products</returns>
        /// <remarks>
        ///     Sample request:
        ///     
        ///         GET:/api/Products/1
        /// </remarks>
        [HttpGet("{pid:int}")]
        public async Task<ActionResult> Get(int pid)
        {
            try
            {
                var product = await this.productManager.GetProductById(pid);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception e)
            {
                //Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving product from sever");
            }
        }

        //POST: /api/Products
        /// <summary>
        /// Create a product and return
        /// </summary>
        /// <returns>create a Product</returns>
        /// <remarks>
        ///     Sample request:
        ///     
        ///         POST:/api/Products
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product newProduct)
        {
            try
            {
                if(newProduct==null)
                {
                    return BadRequest();
                }
                var result = await this.productManager.AddProduct(newProduct);
                return CreatedAtAction(nameof(Get), new { id = result.PId }, result);
            }
            catch(Exception e)
            {
                //Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Error inserting product to sever");
            }
        }
        //PUT: /api/Products/1
        /// <summary>
        /// Update a product and return
        /// </summary>
        /// <returns>Update a Product</returns>
        /// <remarks>
        ///     Sample request:
        ///     
        ///         PUT:/api/Products/1
        /// </remarks>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product>> Update(int id,Product productToModify)
        {
            //1.check if the productToModify is null->BadRequest
            //2check if the id and productToModify.id are different->BadRequest
            //3.Ok(product)
            try
            {
                if(productToModify==null)
                {
                    return BadRequest();
                }
                if(productToModify.PId==0 || productToModify.Price==0 || string.IsNullOrEmpty(productToModify.ProductName))
                {
                    return BadRequest();
                }
                if(productToModify.PId!=id)
                {
                    return BadRequest();
                }
                var result = await this.productManager.UpdateProduct(productToModify);
                if(result==null)
                {
                    return NotFound($"Product with Id:{id} not found");
                }
                return Ok(result);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating product to sever");
            }
        }

        //DELETE: /api/Products/1
        /// <summary>
        /// Delete a product
        /// </summary>
        /// <returns>Delete a Product</returns>
        /// <remarks>
        ///     Sample request:
        ///     
        ///         DELETE:/api/Products/1
        /// </remarks>
        [HttpDelete("{id:int}")]
         public async Task<ActionResult> Delete(int id)
         {
            try
            {
                var product = await this.productManager.GetProductById(id);
                if (product == null)
                {
                    return NotFound($"Product with ID:{id} Not found");
                }
                await this.productManager.DeleteProduct(id);
                return Ok($"Product with ID:{id} Deleted");
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Deleting product from sever");
            }
        }

        //GET: /api/Products/apple
        /// <summary>
        /// Return a product
        /// </summary>
        /// <returns>return a Product</returns>
        /// <remarks>
        ///     Sample request:
        ///     
        ///         GET:/api/Products/apple
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult> Get(string key)
        {
            try
            {
                var products = await this.productManager.Search(key);
                return Ok(products);
               
            }
            catch (Exception e)
            {
                //Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving product from sever");
            }
        }
    }
}
