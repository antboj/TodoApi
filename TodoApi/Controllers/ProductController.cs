using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace TodoApi.Controllers
{
    // Routing with Http attributes
    public class ProductController : Controller
    {
        /// <summary>
        /// Return all products
        /// </summary>
        // GET api/<controller>
        [HttpGet("api/Product")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new[] { "product1", "product2" };
        }

        /// <summary>
        /// Return product by ID
        /// </summary>
        /// <param name="id"></param>
        // GET api/<controller>/5
        [HttpGet("api/Product/{id}")]
        public string Get(int id)
        {
            return "product";
        }

        /// <summary>
        /// Upload new product
        /// </summary>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     POST /Product
        ///     {
        ///        "id": 1,
        ///        "product": "Product1",
        ///        "inStock": true
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <response code="200">if product is created</response>
        /// <response code="400">Bad request</response>
        // POST api/<controller>
        [HttpPost("api/Product")]
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// Update product by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <response code="200">If product is updated</response>
        /// <response code="400">Bad request</response>
        // PUT api/<controller>/5
        [HttpPut("api/Product/{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Delete product by ID
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">If product is deleted</response>
        /// <response code="400">Bad request</response>
        // DELETE api/<controller>/5
        [HttpDelete("api/Product/{id}")]
        public void Delete(int id)
        {
        }
    }
}
