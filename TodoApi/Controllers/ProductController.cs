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
        // GET api/<controller>
        /// <summary>
        /// Return all products
        /// </summary>
        [HttpGet("api/Product")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new[] { "product1", "product2" };
        }

        // GET api/<controller>/5
        /// <summary>
        /// Return product by ID
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("api/Product/{id}")]
        public string Get(long id)
        {
            return "product" + id;
        }

        // POST api/<controller>
        /// <summary>
        /// Upload new product
        /// </summary>
        /// <remarks>
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
        
        /// <param name="value"></param>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPost("api/Product")]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        /// <summary>
        /// Update product by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <response code="200">If product is updated</response>
        /// <response code="204">No Content</response>
        [HttpPut("api/Product/{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        /// <summary>
        /// Delete product by ID
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">If product is deleted</response>
        /// <response code="204">No Content</response>
        [HttpDelete("api/Product/{id}")]
        public void Delete(int id)
        {
        }
    }
}
