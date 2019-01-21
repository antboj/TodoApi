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
    public class UserController : Controller
    {
        private static TodoContext _context;

        public UserController(TodoContext context)
        {
            context.Database.EnsureCreated();

            _context = context;
        }

        /*
        // GET api/<controller>/5
        /// <summary>
        /// Return user by ID
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("api/User/{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user != null)
            {
                return user;
            }

            return NotFound();
        }
        */

        // GET api/<controller>/5
        /// <summary>
        /// Return user by ID
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("api/User/{id}")]
        public async Task<ActionResult<IEnumerable<User>>> Get(long id)
        {
            var allUsers = await _context.User.ToArrayAsync();

            User[] res = new User[1];

            var userQuery =
                from user in allUsers
                where id == user.id
                select user;

            foreach(var user in userQuery)
            {
                res[0] = user;
            }

            return res;
        }

        /*
        // GET api/<controller>/Name/Andrej/Bojic
        /// <summary>
        /// Return user by Firstname and Lastname
        /// </summary>
        /// <param name="first_name"></param>
        /// <param name="last_name"></param>
        /// <response code="200">If user is found</response>
        /// <response code="204">No Content</response>
        [HttpGet("api/User/Name{first_name}/{last_name}")]
        public async Task<ActionResult<List<User>>> Name(string first_name, string last_name)
        {
            var user = await _context.User.Where(o => (o.first_name == first_name && o.last_name == last_name)).ToListAsync();

            if (user != null)
            {
                return user;
            }

            return NotFound();
        }
        */

        // GET api/<controller>/Name/Andrej/Bojic
        /// <summary>
        /// Return user by Firstname and Lastname
        /// </summary>
        /// <param name="first_name"></param>
        /// <param name="last_name"></param>
        /// <response code="200">If user is found</response>
        /// <response code="204">No Content</response>
        [HttpGet("api/User/Name{first_name}/{last_name}")]
        public async Task<ActionResult<List<User>>> Name(string first_name, string last_name)
        {
            var allUsers = await _context.User.ToArrayAsync();

            List<User> matchUser = new List<User>();

            var userQuery =
                from user in allUsers
                where first_name == user.first_name && last_name == user.last_name
                select user;

            foreach(var user in userQuery)
            {
                matchUser.Add(user);
            }

            return matchUser;
        }

        /*
        // GET api/<controller>/Email/example@mail.com
        /// <summary>
        /// Return user by Email
        /// </summary>
        /// <param name="email"></param>
        /// <response code="200">If user is found</response>
        /// <response code="204">No Content</response>
        [HttpGet("api/User/Email{email}")]
        public async Task<ActionResult<User>> Email(string email)
        {
            var user = await _context.User.Where(o => o.email == email).FirstOrDefaultAsync();

            if (user != null)
            {
                return user;
            }

            return NotFound();
        }
        */

        // GET api/<controller>/Email/example@mail.com
        /// <summary>
        /// Return user by Email
        /// </summary>
        /// <param name="email"></param>
        /// <response code="200">If user is found</response>
        /// <response code="204">No Content</response>
        [HttpGet("api/User/Email{email}")]
        public async Task<ActionResult<List<User>>> Email(string email)
        {
            var allUsers = await _context.User.ToArrayAsync();

            List<User> matchUser = new List<User>();

            var userQuery =
                from user in allUsers
                where email == user.email
                select user;

            foreach (var user in userQuery)
            {
                matchUser.Add(user);
            }

            return matchUser;
        }

        // GET api/<controller>/Date/1993-04-27
        /// <summary>
        /// Return user by Birthdate
        /// </summary>
        /// <param name="birth_date"></param>
        /// <response code="200">If user is found</response>
        /// <response code="204">No Content</response>
        [HttpGet("api/User/Date/{birth_date}")]
        public async Task<ActionResult<List<User>>> Date(DateTime birth_date)
        {
            var user = await _context.User.Where(o => DateTime.Compare(o.birth_date, birth_date) == 0).ToListAsync();

            if (user != null)
            {
                return user;
            }

            return NotFound();
        }

        // GET api/<controller>/DatePlace/1993-04-27/Bar
        /// <summary>
        /// Return user by Birthdate and Birthplace
        /// </summary>
        /// <param name="birth_date"></param>
        /// <param name="birth_place"></param>
        /// <response code="200">If user is found</response>
        /// <response code="204">No Content</response>
        [HttpGet("api/User/DatePlace/{birth_date}/{birth_place}")]
        public async Task<ActionResult<List<User>>> DatePlace(DateTime birth_date, string birth_place)
        {
            var user = await _context.User.Where(o => (DateTime.Compare(o.birth_date, birth_date) == 0) && o.birth_place == birth_place).ToListAsync();

            if (user != null)
            {
                return user;
            }

            return NotFound();
        }


        // PUT api/<controller>/5
        /// <summary>
        /// Update user by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <response code="200">If user is updated</response>
        /// <response code="204">No Content</response>
        [HttpPut("api/User/{id}")]
        public async Task<IActionResult> Put(long id, User user)
         {
             if (id != user.id)
             {
                 return BadRequest();
             }

             _context.Entry(user).State = EntityState.Modified;
             await _context.SaveChangesAsync();

             return Ok();
         }

        // DELETE api/<controller>/5
        /// <summary>
        /// Delete user by ID
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">If user is deleted</response>
        /// <response code="204">No Content</response>
        [HttpDelete("api/User/{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
    }

