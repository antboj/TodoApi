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
        [HttpGet("api/Product")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("api/Product/{id}")]
        public string Get(int id)
        {
            return "product";
        }

        // POST api/<controller>
        [HttpPost("api/Product")]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("api/Product/{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("api/Product/{id}")]
        public void Delete(int id)
        {
        }
    }
}
