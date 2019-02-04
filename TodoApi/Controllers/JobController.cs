using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/Job")]
    public class JobController : Controller
    {
        private static TodoContext _context;

        
        public JobController(TodoContext context)
        {
            context.Database.EnsureCreated();

            _context = context;
        }

        // GET: api/<controller>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var allJobs = _context.Job.ToList();

            return Ok(allJobs.ToList());

        }

        public static async Task AddJob([FromBody]Job job)
        {

        }
    }
}
