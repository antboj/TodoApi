using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;
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
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("api/User/GetById{id}")]
        public IActionResult GetById(int id)
        {
            var AllUsers = _context.User;

            var userQuery =
                from User in AllUsers
                where id == User.Id
                select User;

            //var uQ = AllUsers.Where(x => x.Id == id);

            if (userQuery.Any())
            {
                return Ok(userQuery.ToList());
            }

            return NotFound();
        }

        // GET api/<controller>/1993
        /// <summary>
        /// Return all users born at the same year
        /// </summary>
        /// <param name="year"></param>
        [HttpGet("api/User/GetByYear{year}")]
        public IActionResult GetByYear(int year)
        {
            var allUsers = _context.User;

            var userQuery =
                from user in allUsers
                where user.BirthDate.Year == year
                      orderby user.FirstName
                select new { FirstName = user.FirstName, BirthYear = user.BirthDate};

            //var uQ = allUsers.Where(x => x.BirthDate.Year == year).OrderBy(y => y.FirstName)
            //    .Select(z => new {Firstname = z.FirstName, Birthdate = z.BirthDate});

            if (userQuery.Any())
            {
                return Ok(userQuery.ToList());
            }

            return NotFound();
        }

        // GET api/<controller>/Bar
        /// <summary>
        /// Return number of users from same place
        /// </summary>
        /// <param name="birthPlace"></param>
        [HttpGet("api/User/CountUsers/{birthPlace}")]
        public IActionResult CountUsers(string birthPlace)
        {
            var allUsers = _context.User;

            var userQuery =
                (from user in allUsers
                    where user.BirthPlace == birthPlace
                    select user).Count();

            //var uQ = allUsers.Where(x => x.BirthPlace == birthPlace).Count();

            var birthPlaceCount = userQuery;

            if (birthPlaceCount > 0)
            {
                return Ok(birthPlaceCount);
            }

            return NotFound();
        }

        // GET api/<controller>/Bar
        /// <summary>
        /// Return all users of age from same place
        /// </summary>
        /// <param name="birthPlace"></param>
        [HttpGet("api/User/OfAgeFromPlace/{birthPlace}")]
        public IActionResult OfAgeFromPlace(string birthPlace)
        {
            var allUsers = _context.User;
            
            var userQuery =
                from user in allUsers
                    where user.BirthPlace == birthPlace && (user.BirthDate.Year < (DateTime.Now.Year - 18))
                    select user;

            //var uQ = allUsers.Where(x => x.BirthPlace == birthPlace && (x.BirthDate.Year < (DateTime.Now.Year - 18)));

            if (userQuery.Any())
            {
                return Ok(userQuery.ToList());
            }

            return NotFound();

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
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        [HttpGet("api/User/Name{firstName}/{lastName}")]
        public IActionResult Name(string firstName, string lastName)
        {
            var AllUsers = _context.User;

            var UserQuery =
                from User in AllUsers
                where firstName == User.FirstName && lastName == User.LastName
                select User;

            //var uQ = AllUsers.Where(x => x.FirstName == firstName && x.LastName == lastName);

            if (UserQuery.Any())
            {
                return Ok(UserQuery.ToList());
            }

            return NotFound();
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
        public IActionResult Email(string email)
        {
            var AllUsers = _context.User;

            var userQuery =
                from user in AllUsers
                where email == user.Email
                select user;

            if (userQuery.Any())
            {
                return Ok(userQuery.ToList());
            }

            return NotFound();
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
        public IActionResult Date(DateTime birthDate)
        {
            var AllUsers = _context.User;

            var UserQuery =
                from user in AllUsers
                where birthDate == user.BirthDate
                select user;
            
            //var uQ = AllUsers.Where(x => x.BirthDate == birthDate);

            if (UserQuery.Any())
            {
                return Ok(UserQuery);
            }

            return NotFound();

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
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        [HttpGet("api/User/DatePlace/{birthDate}/{birthPlace}")]
        public IActionResult DatePlace(DateTime birthDate, string birthPlace)
        {
            var AllUsers = _context.User;

            var userQuery =
                from user in AllUsers
                where birthDate == user.BirthDate && birthPlace == user.BirthPlace
                select user;

            //var uQ = AllUsers.Where(x => x.BirthDate == birthDate && x.BirthPlace == birthPlace);

            if (userQuery.Any())
            {
                return Ok(userQuery.ToList());
            }

            return NotFound();
        }

        // GET api/<controller>/5
        /// <summary>
        /// Return user and his job
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        [HttpGet("api/User/UserJob/{id}")]
        public IActionResult UserJob(int id)
        {
            var allUsers = _context.User;
            var allJobs = _context.Job;

            var userJobQuery =
                from user in allUsers
                join job in allJobs on user.Id equals job.Id
                where user.Id == id
                select new {Name = user.FirstName, Job = job.Name, Sector = job.Sector};

            //var uQ = allUsers.Where(x => x.Id == id).Join(allJobs, y => y.Id, y => y.Id,
            //    (user, job) => new {Name = user.FirstName, Job = job.Name, Sector = job.Sector});

            if (userJobQuery.Any())
            {
                return Ok(userJobQuery.ToList());
            }

            return NotFound();
        }

        // GET api/<controller>/Finance/Menager
        /// <summary>
        /// Return all users thst work the sam job
        /// </summary>
        /// <param name="sector"></param>
        /// <param name="position"></param>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        [HttpGet("api/User/UserSector/{sector}/{position}")]
        public IActionResult UserSector(string sector, string position)
        {
            var allUsers = _context.User;
            var allJobs = _context.Job;

            var query =
                from user in allUsers
                join job in allJobs on user.Id equals job.Id
                where job.Sector == sector && job.Name == position
                select new {Name = user.FirstName, Position = job.Name, Sector = job.Sector};

            //var uQ = allUsers.Join(allJobs, x => x.Id, x => x.Id,
            //        (user, job) => new {Name = user.FirstName, Position = job.Name, Sector = job.Sector})
            //    .Where(x => x.Sector == sector && x.Position == position);

            if (query.Any())
            {
                return Ok(query.ToList());
            }

            return NotFound();
        }

        // GET api/<controller>/Bar
        /// <summary>
        /// Return all users group by same job
        /// </summary>
        /// <param name="birthPlace"></param>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        [HttpGet("api/User/JobByCountry/{birthPlace}")]
        public IActionResult JobByCountry(string birthPlace)
        {
            var allUsers = _context.User;
            var allJobs = _context.Job;
            
            var query =
                from user in allUsers
                where user.BirthPlace == birthPlace
                join job in allJobs on user.Id equals job.Id
                group job by job.Sector
                into jobS
                orderby jobS.Key
                select jobS;

            //select new {Id = user.Id, Name = user.FirstName,Country = user.BirthPlace, Job = job.Sector};

            var uQ = allUsers.Where(x => x.BirthPlace == birthPlace)
                .Join(allJobs, y => y.Id, y => y.Id, (job, person) => new {Job = job, User = person})
                .GroupBy(z => z.User.Sector).Select(o => new {Sector = o.Key, Name = o.Select(p => p.Job.FirstName)});
            
            if (uQ.Any())
            {
                return Ok(uQ.ToList());
            }

            return NotFound();
        }

        // GET api/<controller>/Bar
        /// <summary>
        /// Return all users group by same sector
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        [HttpGet("api/User/GetAllUsersByJob")]
        public IActionResult GetAllUsersByJob()
        {
            var allUsers = _context.User;
            var allJobs = _context.Job;

            var query =
                from job in allJobs
                join user in allUsers on job.Id equals user.Id
                let joined = new {Job = job, User = user}
                group joined by joined.Job.Sector
                into groupedBySector
                select new
                {
                    Job = groupedBySector.Key,
                    Users = (
                        from user in groupedBySector
                        select user.User.FirstName + " " + user.User.LastName)
                };

            if (query.Any())
            {
                return Ok(query.ToList());
            }

            return NotFound();
        }




        // PUT api/<controller>/5
        /// <summary>
        /// Update user by ID
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
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
        /// <response code="200">Success</response>
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

