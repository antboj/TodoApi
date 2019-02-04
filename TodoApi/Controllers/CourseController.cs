using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/Course")]
    public class CourseController : Controller
    {
        private static TodoContext _context;

        public CourseController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet("GetByCourse")]
        public IActionResult GetByCourse()
        {
            var all = _context.StudentCourses.Include(x => x.Student).Include(y => y.Course);

            var query = all.GroupBy(x => x.Course.CName)
                .Select(y => new {Course = y.Key, Students = y.Select(g => g.Student.SName)});

            return Ok(query);
        }

        // GET: api/<controller>
        [HttpGet("GetByprofessor")]
        public IActionResult GetByprofessor()
        {
            var all = _context.Professorses.Include(x => x.Student);

            var query = all.GroupBy(x => x.PName).Select(y => new {Professor = y.Key, Students = y.Select(o => o.Student.SName)});

            return Ok(query);
        }

        // GET: api/<controller>
        [HttpGet("GetCourseByStudent/{studentName}")]
        public IActionResult GetCourseByStudent(string studentName)
        {
            var all = _context.StudentCourses.Include(x => x.Student).Include(y => y.Course);

            var query = all.Where(x => x.Student.SName == studentName)
                .Select(y => new {Name = y.Student.SName, Courses = y.Course.CName});



            return Ok(query);
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
