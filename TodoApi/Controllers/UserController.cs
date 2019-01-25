﻿using System;
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
        [HttpGet("api/User/GetById{id}")]
        public IActionResult GetById(int id)
        {
            var AllUsers = _context.User;

            var UserQuery =
                from User in AllUsers
                where id == User.Id
                select User;

            return Ok(UserQuery.ToList());
        }

        // GET api/<controller>/5
        /// <summary>
        /// Return all users born at the same year
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("api/User/GetByYear{year}")]
        public IActionResult GetByYear(int year)
        {
            var allUsers = _context.User;

            var userQuery =
                from user in allUsers
                where user.BirthDate.Year == year
                      orderby user.FirstName
                select new { FirstName = user.FirstName, BirthYear = user.BirthDate};

            return Ok(userQuery.ToList());
        }

        // GET api/<controller>/5
        /// <summary>
        /// Return number of users from same place
        /// </summary>
        /// <param name="birthPlace"></param>
        [HttpGet("api/User/Count/{birthPlace}")]
        public int Count(string birthPlace)
        {
            var allUsers = _context.User;

            var userQuery =
                (from user in allUsers
                    where user.BirthPlace == birthPlace
                    select user).Count();

            var birthPlaceCount = userQuery;
            return birthPlaceCount;
        }

        // GET api/<controller>/5
        /// <summary>
        /// Return all users of age from same place
        /// </summary>
        /// <param name="birthPlace"></param>
        [HttpGet("api/User/FromPlace/{birthPlace}")]
        public List<User> OfAgeFromPlace(string birthPlace)
        {
            var allUsers = _context.User;
            
            var userQuery =
                from user in allUsers
                    where user.BirthPlace == birthPlace && (user.BirthDate.Year < (DateTime.Now.Year - 18))
                    select user;

            return (userQuery).ToList();
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
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <response code="200">If user is found</response>
        /// <response code="204">No Content</response>
        [HttpGet("api/User/Name{firstName}/{lastName}")]
        public async Task<ActionResult<List<User>>> Name(string firstName, string lastName)
        {
            var AllUsers = await _context.User.ToArrayAsync();

            List<User> MatchUser = new List<User>();

            var UserQuery =
                from User in AllUsers
                where firstName == User.FirstName && lastName == User.LastName
                select User;

            foreach(var user in UserQuery)
            {
                MatchUser.Add(user);
            }

            return MatchUser;
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
            var AllUsers = await _context.User.ToArrayAsync();

            List<User> MatchUser = new List<User>();

            var UserQuery =
                from user in AllUsers
                where email == user.Email
                select user;

            foreach (var user in UserQuery)
            {
                MatchUser.Add(user);
            }

            return MatchUser;
        }

        /*
        // GET api/<controller>/Date/1993-04-27
        /// <summary>
        /// Return user by Birthdate
        /// </summary>
        /// <param name="birthDate"></param>
        /// <response code="200">If user is found</response>
        /// <response code="204">No Content</response>
        [HttpGet("api/User/Date/{BirthDate}")]
        public async Task<ActionResult<List<User>>> Date(DateTime birthDate)
        {
            var User = await _context.User.Where(o => DateTime.Compare(o.BirthDate, birthDate) == 0).ToListAsync();

            if (User != null)
            {
                return User;
            }

            return NotFound();
        }
        */

        // GET api/<controller>/Date/1993-04-27
        /// <summary>
        /// Return user by Birthdate
        /// </summary>
        /// <param name="birthDate"></param>
        /// <response code="200">If user is found</response>
        /// <response code="204">No Content</response>
        [HttpGet("api/User/Date/{birthDate}")]
        public async Task<ActionResult<List<User>>> Date(DateTime birthDate)
        {
            var AllUsers = await _context.User.ToArrayAsync();

            List<User> MatchUser = new List<User>();

            var UserQuery =
                from user in AllUsers
                where birthDate == user.BirthDate
                select user;

            foreach (var user in UserQuery)
            {
                MatchUser.Add(user);
            }

            return MatchUser;

        }

        /*
        // GET api/<controller>/DatePlace/1993-04-27/Bar
        /// <summary>
        /// Return user by Birthdate and Birthplace
        /// </summary>
        /// <param name="birthDate"></param>
        /// <param name="birthPlace"></param>
        /// <response code="200">If user is found</response>
        /// <response code="204">No Content</response>
        [HttpGet("api/User/DatePlace/{birthDate}/{birthPlace}")]
        public async Task<ActionResult<List<User>>> DatePlace(DateTime birthDate, string birthPlace)
        {
            var User = await _context.User.Where(o => (DateTime.Compare(o.BirthDate, birthDate) == 0) && o.BirthPlace == birthPlace).ToListAsync();

            if (User != null)
            {
                return User;
            }

            return NotFound();
        }
        */

        // GET api/<controller>/DatePlace/1993-04-27/Bar
        /// <summary>
        /// Return user by Birthdate and Birthplace
        /// </summary>
        /// <param name="birthDate"></param>
        /// <param name="birthPlace"></param>
        /// <response code="200">If user is found</response>
        /// <response code="204">No Content</response>
        [HttpGet("api/User/DatePlace/{birthDate}/{birthPlace}")]
        public async Task<ActionResult<List<User>>> DatePlace(DateTime birthDate, string birthPlace)
        {
            var AllUsers = await _context.User.ToArrayAsync();

            List<User> MatchUser = new List<User>();

            var UserQuery =
                from user in AllUsers
                where birthDate == user.BirthDate && birthPlace == user.BirthPlace
                select user;

            foreach (var user in UserQuery)
            {
                MatchUser.Add(user);
            }

            return MatchUser;
        }


        // PUT api/<controller>/5
        /// <summary>
        /// Update user by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <response code="200">If user is updated</response>
        /// <response code="204">No Content</response>
        [HttpPut("api/User/{Id}")]
        public async Task<IActionResult> Put(long id, User user)
         {
             if (id != user.Id)
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
        [HttpDelete("api/User/{Id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var User = await _context.User.FindAsync(id);
            if (User == null)
            {
                return NotFound();
            }

            _context.User.Remove(User);
            await _context.SaveChangesAsync();

            return User;
        }
    }
}

