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
            // not required
            context.Database.EnsureCreated();

            _context = context;
        }

        /////////////////////////////////////////// NEW MODEL PROPERTIES QUERY METHODS /////////////////////////////////////

        // GET api/<controller>/GetSAll
        [HttpGet("api/User/GetAll")]
        public IActionResult GetAll()
        {
            var allUsers = _context.User.Include(jobs => jobs.Job).AsNoTracking();

            var query = _context.User.FromSql("SELECT * FROM dbo.User");

            if (allUsers.Any())
            {
                return Ok(allUsers.ToList());
            }

            return NotFound();
        }

        // Async method
        [HttpGet("api/User/GetAllAS")]
        public async Task<List<User>> GetAllAs()
        {
            return await _context.User.Include(jobs => jobs.Job).ToListAsync();
        }

        // GET api/<controller>/GetSById/5
        [HttpGet("api/User/GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var allUsers = _context.User.Include(x => x.Job);
            var foundUser = allUsers.Single(u => u.Id == id);

            if (foundUser != null)
            {
                return Ok(foundUser);
            }

            return NotFound();
        }

        // DELETE api/<controller>/DeleteS/5
        [HttpDelete("api/User/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.User.Find(id);

            if (user != null)
            {
                _context.User.Remove(user);
                _context.SaveChanges();
                return Ok();
            }

            return NotFound();
        }

        // POST api/<controller>/AddSUser
        [HttpPost("api/User/AddUser")]
        public IActionResult AddSUser([FromBody] User user)
        {
            if (user != null)
            {
                _context.User.Add(user);
                _context.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }

        // PUT api/<controller>/UpdateSUser/5
        [HttpPut("api/User/UpdateUser/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            var foundUser = _context.User.Find(id);

            if (foundUser != null)
            {
                foundUser.Name = user.Name;
                foundUser.BirthDate = user.BirthDate;
                foundUser.BirthPlace = user.BirthPlace;
                foundUser.Email = user.Email;

                _context.SaveChanges();
                return Ok();
            }

            return NotFound();
        }

        // GET api/<controller>/GetSByYear/1980
        [HttpGet("api/User/GetByYear{year}")]
        public IActionResult GetByYear(int year)
        {
            var allUsers = _context.User;

            var userQuery =
                from user in allUsers
                where user.BirthDate.Year == year
                orderby user.Name
                select new { Name = user.Name, BirthYear = user.BirthDate };

            //var uQ = allUsers.Where(x => x.BirthDate.Year == year).OrderBy(y => y.Name)
            //    .Select(z => new { Name = z.Name, Birthdate = z.BirthDate });

            if (userQuery.Any())
            {
                return Ok(userQuery.ToList());
            }

            return NotFound();
        }

        // GET api/<controller>/OfAgeFromPlace/Montenegro
        [HttpGet("api/User/OfAgeFromPlace/{birthPlace}")]
        public IActionResult OfAgeFromPlace(string birthPlace)
        {
            var allUsers = _context.User.Include(x => x.Job);

            var userQuery =
                from user in allUsers
                where user.BirthPlace == birthPlace && (user.BirthDate.Year < (DateTime.Now.Year - 18))
                select new {Name = user.Name, Age = (DateTime.Now.Year - user.BirthDate.Year)};

            //var uQ = allUsers.Where(x => x.BirthPlace == birthPlace && (x.BirthDate.Year < (DateTime.Now.Year - 18)));

            if (userQuery.Any())
            {
                return Ok(userQuery.ToList());
            }

            return NotFound();

        }

        // GET api/<controller>/Email/example@mail.com
        [HttpGet("api/User/Email{email}")]
        public IActionResult Email(string email)
        {
            var allUsers = _context.User.Include(x => x.Job);

            var userQuery =
                from user in allUsers
                where email == user.Email
                select user;

            //var uQ = allUsers.Where(x => x.Email == email);

            if (userQuery.Any())
            {
                return Ok(userQuery.ToList());
            }

            return NotFound();
        }

        // GET api/<controller>/2000-12-12
        [HttpGet("api/User/Date/{birthDate}")]
        public IActionResult Date(DateTime birthDate)
        {
            var allUsers = _context.User.Include(x => x.Job);

            var userQuery =
                from user in allUsers
                where birthDate == user.BirthDate
                select user;

            //var uQ = AllUsers.Where(x => x.BirthDate == birthDate);

            if (userQuery.Any())
            {
                return Ok(userQuery);
            }

            return NotFound();

        }

        // GET api/<controller>/DatePlace/1993-04-27/Bar
        [HttpGet("api/User/DatePlace/{birthDate}/{birthPlace}")]
        public IActionResult DatePlace(DateTime birthDate, string birthPlace)
        {
            var allUsers = _context.User.Include(x => x.Job);

            var userQuery =
                from user in allUsers
                where birthDate == user.BirthDate && birthPlace == user.BirthPlace
                select user;

            //var uQ = AllUsers.Where(x => x.BirthDate == birthDate && x.BirthPlace == birthPlace);

            if (userQuery.Any())
            {
                return Ok(userQuery.ToList());
            }

            return NotFound();
        }

        // GET api/<controller>/Menager
        [HttpGet("api/User/UserByJob/{position}")]
        public IActionResult UserByJob(string position)
        {
            var allUsers = _context.User.Include(x => x.Job);

            var query =
                from user in allUsers
                where user.Job.Position == position
                select new { Name = user.Name, Position = user.Job.Position};

            var uQ = allUsers.Where(x => x.Job.Position == position).Select(u => new{ Name = u.Name, Position = u.Job.Position});

            if (query.Any())
            {
                return Ok(query.ToList());
            }

            return NotFound();
        }

        // GET api/<controller>/GetAllUsersByJob
        [HttpGet("api/User/GetAllUsersByJob")]
        public IActionResult GetAllUsersByJob()
        {
            var allUsers = _context.User.Include(x => x.Job);

            var query =
                from user in allUsers
                group user by user.Job.Position
                into groupedByPosition
                select new
                {
                    Job = groupedByPosition.Key,
                    Users = (
                        from user in groupedByPosition
                        select user.Name)
                };

            //var uQ = allUsers.GroupBy(x => x.Job.Position).Select(u => new {Position = u.Key, Name = u.Select(y => y.Name)});

            if (query.Any())
            {
                return Ok(query.ToList());
            }

            return NotFound();
        }

        // GET api<controller>/Montenegro
        [HttpGet("api/User/JobByCountry/{birthPlace}")]
        public IActionResult JobByCountry(string birthPlace)
        {
            var allUsers = _context.User.Include(x => x.Job);

            var query =
                from user in allUsers
                where user.BirthPlace == birthPlace
                group user by user.Job.Position
                into sectorGruop
                select new { Sector = sectorGruop.Key, Users = (from user in sectorGruop select user.Name) };

            //var uQ = allUsers.Where(x => x.BirthPlace == birthPlace)
            //    .GroupBy(z => z.Job.Position)
            //    .Select(o => new {Position = o.Key, Name = o.Select(p => p.Name)});

            if (query.Any())
            {
                return Ok(query.ToList());
            }

            return NotFound();
        }

        // GET api/<controller>/Andrej/Bojic
        [HttpGet("api/User/Name{firstName}/{lastName}")]
        public IActionResult Name(string firstName, string lastName)
        {
            var allUsers = _context.User;

            var userQuery =
                from user in allUsers
                where firstName + " " + lastName == user.Name
                select user;

            //var uQ = allUsers.Where(x => x.Name == (firstName + " " + lastName));

            if (userQuery.Any())
            {
                return Ok(userQuery.ToList());
            }

            return NotFound();
        }

        /*
        //////////////////////////////////////////// SQL METHODS //////////////////////////////////////////////////////
        
        // GET api/<controller>/GetSAll
        [HttpGet("api/User/GetSAll")]
        public IActionResult GetSAll()
        {
            var allUsers = _context.User;

            if (allUsers.Any())
            {
                return Ok(allUsers.ToList());
            }

            return NotFound();
        }

        // GET api/<controller>/GetSById/5
        [HttpGet("api/User/GetSById/{id}")]
        public IActionResult GetSById(int id)
        {
            var allUsers = _context.User;
            var foundUser = allUsers.Find(id);

            if (foundUser != null)
            {
                return Ok(foundUser);
            }

            return NotFound();
        }

        // DELETE api/<controller>/DeleteS/5
        [HttpDelete("api/User/DeleteS/{id}")]
        public IActionResult DeleteS(int id)
        {
            var user = _context.User.Find(id);

            if (user != null)
            {
                _context.User.Remove(user);
                _context.SaveChanges();
                return Ok();
            }

            return NotFound();
        }

        // POST api/<controller>/AddSUser
        [HttpPost("api/User/AddSUser")]
        public IActionResult AddSUser([FromBody] User user)
        {
            if (user != null)
            {
                _context.User.Add(user);
                _context.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }

        // PUT api/<controller>/UpdateSUser/5
        [HttpPut("api/User/UpdateSUser/{id}")]
        public IActionResult UpdateSUser(int id, [FromBody] User user)
        {
            var foundUser = _context.User.Find(id);

            if (foundUser != null)
            {
                foundUser.FirstName = user.FirstName;
                foundUser.LastName = user.LastName;
                foundUser.BirthDate = user.BirthDate;
                foundUser.BirthPlace = user.BirthPlace;
                foundUser.Email = user.Email;
                
                _context.SaveChanges();
                return Ok();
            }

            return NotFound();
        }

        ////////////////////////////////////////////////////// LINQ ////////////////////////////////////////////////////////

        
        //// GET api/<controller>/5
        ///// <summary>
        ///// Return user by ID
        ///// </summary>
        ///// <param name="id"></param>
        //[HttpGet("api/User/{id}")]
        //public async Task<ActionResult<User>> Get(int id)
        //{
        //    var user = await _context.User.FindAsync(id);

        //    if (user != null)
        //    {
        //        return user;
        //    }

        //    return NotFound();
        //}
        
        
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
            var allUsers = _context.User;

            var userQuery =
                from user in allUsers
                where id == user.Id
                select user;

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

        
        //// GET api/<controller>/Name/Andrej/Bojic
        ///// <summary>
        ///// Return user by Firstname and Lastname
        ///// </summary>
        ///// <param name="first_name"></param>
        ///// <param name="last_name"></param>
        ///// <response code="200">If user is found</response>
        ///// <response code="204">No Content</response>
        //[HttpGet("api/User/Name{first_name}/{last_name}")]
        //public async Task<ActionResult<List<User>>> Name(string first_name, string last_name)
        //{
        //    var user = await _context.User.Where(o => (o.first_name == first_name && o.last_name == last_name)).ToListAsync();

        //    if (user != null)
        //    {
        //        return user;
        //    }

        //    return NotFound();
        //}
        

        // GET api/<controller>/Name/Andrej/Bojic
        /// <summary>
        /// Return user by Firstname and Lastname
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <response code="200">Success</response>
        /// <response code="404">No Content</response>
        [HttpGet("api/User/Name{firstName}/{lastName}")]
        public IActionResult Name(string firstName, string lastName)
        {
            var allUsers = _context.User;

            var userQuery =
                from User in allUsers
                where firstName == User.FirstName && lastName == User.LastName
                select User;

            //var uQ = AllUsers.Where(x => x.FirstName == firstName && x.LastName == lastName);

            if (userQuery.Any())
            {
                return Ok(userQuery.ToList());
            }

            return NotFound();
        }

        
        //// GET api/<controller>/Email/example@mail.com
        ///// <summary>
        ///// Return user by Email
        ///// </summary>
        ///// <param name="email"></param>
        ///// <response code="200">If user is found</response>
        ///// <response code="204">No Content</response>
        //[HttpGet("api/User/Email{email}")]
        //public async Task<ActionResult<User>> Email(string email)
        //{
        //    var user = await _context.User.Where(o => o.email == email).FirstOrDefaultAsync();

        //    if (user != null)
        //    {
        //        return user;
        //    }

        //    return NotFound();
        //}
        

        // GET api/<controller>/Email/example@mail.com
        /// <summary>
        /// Return user by Email
        /// </summary>
        /// <param name="email"></param>
        /// <response code="200">If user is found</response>
        /// <response code="404">No Content</response>
        [HttpGet("api/User/Email{email}")]
        public IActionResult Email(string email)
        {
            var allUsers = _context.User;

            var userQuery =
                from user in allUsers
                where email == user.Email
                select user;

            if (userQuery.Any())
            {
                return Ok(userQuery.ToList());
            }

            return NotFound();
        }

        
        //// GET api/<controller>/Date/1993-04-27
        ///// <summary>
        ///// Return user by Birthdate
        ///// </summary>
        ///// <param name="birthDate"></param>
        ///// <response code="200">If user is found</response>
        ///// <response code="204">No Content</response>
        //[HttpGet("api/User/Date/{BirthDate}")]
        //public async Task<ActionResult<List<User>>> Date(DateTime birthDate)
        //{
        //    var User = await _context.User.Where(o => DateTime.Compare(o.BirthDate, birthDate) == 0).ToListAsync();

        //    if (User != null)
        //    {
        //        return User;
        //    }

        //    return NotFound();
        //}
        

        // GET api/<controller>/Date/1993-04-27
        /// <summary>
        /// Return user by Birthdate
        /// </summary>
        /// <param name="birthDate"></param>
        /// <response code="200">If user is found</response>
        /// <response code="404">No Content</response>
        [HttpGet("api/User/Date/{birthDate}")]
        public IActionResult Date(DateTime birthDate)
        {
            var allUsers = _context.User;

            var userQuery =
                from user in allUsers
                where birthDate == user.BirthDate
                select user;
            
            //var uQ = AllUsers.Where(x => x.BirthDate == birthDate);

            if (userQuery.Any())
            {
                return Ok(userQuery);
            }

            return NotFound();

        }

        
        //// GET api/<controller>/DatePlace/1993-04-27/Bar
        ///// <summary>
        ///// Return user by Birthdate and Birthplace
        ///// </summary>
        ///// <param name="birthDate"></param>
        ///// <param name="birthPlace"></param>
        ///// <response code="200">If user is found</response>
        ///// <response code="204">No Content</response>
        //[HttpGet("api/User/DatePlace/{birthDate}/{birthPlace}")]
        //public async Task<ActionResult<List<User>>> DatePlace(DateTime birthDate, string birthPlace)
        //{
        //    var User = await _context.User.Where(o => (DateTime.Compare(o.BirthDate, birthDate) == 0) && o.BirthPlace == birthPlace).ToListAsync();

        //    if (User != null)
        //    {
        //        return User;
        //    }

        //    return NotFound();
        //}
        

        // GET api/<controller>/DatePlace/1993-04-27/Bar
        /// <summary>
        /// Return user by Birthdate and Birthplace
        /// </summary>
        /// <param name="birthDate"></param>
        /// <param name="birthPlace"></param>
        /// <response code="200">Success</response>
        /// <response code="404">No Content</response>
        [HttpGet("api/User/DatePlace/{birthDate}/{birthPlace}")]
        public IActionResult DatePlace(DateTime birthDate, string birthPlace)
        {
            var allUsers = _context.User;

            var userQuery =
                from user in allUsers
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
        /// <response code="404">No Content</response>
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
        /// <response code="404">No Content</response>
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
        /// <response code="404">No Content</response>
        [HttpGet("api/User/JobByCountry/{birthPlace}")]
        public IActionResult JobByCountry(string birthPlace)
        {
            var allUsers = _context.User;
            var allJobs = _context.Job;

            var query =
                from user in allUsers
                where user.BirthPlace == birthPlace
                join job in allJobs on user.Id equals job.Id
                let joined = new {Job = job, User = user}
                group joined by joined.Job.Sector
                into sectorGruop
                select new {Sector = sectorGruop.Key, Users = (from user in sectorGruop select user.User.FirstName)};

            //var uQ = allUsers.Where(x => x.BirthPlace == birthPlace)
            //    .Join(allJobs, y => y.Id, y => y.Id, (person, job) => new { Job = job, User = person })
            //    .GroupBy(z => z.Job.Sector).Select(o => new { Sector = o.Key, Name = o.Select(p => p.User.FirstName) });

            if (query.Any())
            {
                return Ok(query.ToList());
            }

            return NotFound();
        }

        // GET api/<controller>/Bar
        /// <summary>
        /// Return all users group by same sector
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="404">No Content</response>
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

            //var uQ = allJobs.Join(allUsers, u => u.Id, u => u.Id, (job, user) => new {Job = job, User = user})
            //    .GroupBy(g => g.Job.Sector).Select(x => new
            //        {Sector = x.Key, Name = x.Select(y => y.User.FirstName + " " + y.User.LastName)});


            if (query.Any())
            {
                return Ok(query.ToList());
            }

            return NotFound();
        }



        
        //// PUT api/<controller>/5
        ///// <summary>
        ///// Update user by ID
        ///// </summary>
        ///// <param name="id"></param>
        ///// <response code="200">Success</response>
        ///// <response code="204">No Content</response>
        //[HttpPut("api/User/{Id}")]
        //public async Task<IActionResult> Put(long id, User user)
        //{
        //    if (id != user.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(user).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();

        //    return Ok();
        //}
        

        
        //// DELETE api/<controller>/5
        ///// <summary>
        ///// Delete user by ID
        ///// </summary>
        ///// <param name="id"></param>
        ///// <response code="200">Success</response>
        ///// <response code="204">No Content</response>
        //[HttpDelete("api/User/{Id}")]
        //public async Task<ActionResult<User>> Delete(int id)
        //{
        //    var User = await _context.User.FindAsync(id);
        //    if (User == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.User.Remove(User);
        //    await _context.SaveChangesAsync();

        //    return User;
        //}
        */

    }
}

