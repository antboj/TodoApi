using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public TodoContext(DbContextOptions options, IHostingEnvironment hostingEnvironment)
            : base(options)
        {
            this._hostingEnvironment = hostingEnvironment;
        }

        public DbSet<User> User { get; set; }
        public DbSet<Job> Job { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var path = _hostingEnvironment.ContentRootPath;
            var usersFilePath = Path.Combine(path, "users.json");
            var jobsFilePath = Path.Combine(path, "jobs.json");

            var jsonString = File.ReadAllText(usersFilePath);
            var userList = JsonConvert.DeserializeObject<List<User>>(jsonString);
            modelBuilder.Entity<User>().HasData(userList);

            var jsonJobs = File.ReadAllText(jobsFilePath);
            var jobList = JsonConvert.DeserializeObject<List<Job>>(jsonJobs);
            modelBuilder.Entity<Job>().HasData(jobList);
        }
    }
}
