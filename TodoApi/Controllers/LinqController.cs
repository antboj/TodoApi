using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/Linq")]
    public class LinqController : Controller
    {
        public string[] Names = new string[]
        {
            "Peter", "Sally", "John"
        };

        public bool Status = false;


        private static TodoContext _context;

        public LinqController(TodoContext context)
        {
            context.Database.EnsureCreated();

            _context = context;
        }

        // GET: api/<controller>
        // Return name from array
        [HttpGet("GetName")]
        public string GetName(string searchName)
        {
            string result = "";

            var nameQuery =
                from name in Names
                where name == searchName
                select name;

            foreach (string foundName in nameQuery)
            {
                result = foundName;
            }

            return result;
        }

        // GET: api/<controller>
        // Return count of names
        [HttpGet("GetNameCount")]
        public int GetNameCount()
        {
            var nameQueryCount =
                (from name in Names
                 select name).Count();

            return nameQueryCount;
        }







        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
    }
}
