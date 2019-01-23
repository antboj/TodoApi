using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/Movies")]
    public class Movies : Controller
    {
        // Declare class properties
        private int Id { set; get; }
        private string Name { set; get; }
        private double Rating { set; get; }
        private bool InStore { set; get; }
        public List<Movies> Movie;

        // GET: api/<controller>
        [HttpGet]
        public void Get()
        {
           
        }






































        /*

        // GET: api/<controller>
        [HttpGet("GetMovie")]
        public async Task<ActionResult<List<Movies>>> GetMovie()
        {
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
