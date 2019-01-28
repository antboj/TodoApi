using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Job> Job { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var jsonString = File.ReadAllText("data.json");
            var list = JsonConvert.DeserializeObject<List<User>>(jsonString);
            modelBuilder.Entity<User>().HasData(list);

            var jsonJobs = File.ReadAllText("jobs.json");
            var jobsList = JsonConvert.DeserializeObject<List<Job>>(jsonJobs);
            modelBuilder.Entity<Job>().HasData(jobsList);
        }

    }
}
