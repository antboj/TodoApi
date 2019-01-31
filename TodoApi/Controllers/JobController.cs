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
        [HttpGet("GetBySector")]
        public IActionResult GetBySector(string sector)
        {
            var allJobs = _context.Job;

            var sectorQuery =
                from job in allJobs
                where job.Sector == sector
                select job;

            return Ok(sectorQuery.ToList());

        }
        
    }
}
