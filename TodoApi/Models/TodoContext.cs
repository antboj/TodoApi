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

        public DbSet<Students> Students { get; set; }
        public DbSet<Courses> Courseses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Professors> Professorses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite primary key for StudentCourse model with fluent API
            modelBuilder.Entity<StudentCourse>().HasKey(k => new {k.SId, k.CId});

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

            // Courses data
            modelBuilder.Entity<Courses>()
                .HasData(new Courses {CId = 1, CName = "PHP"}, new Courses {CId = 2, CName = "Java"}, new Courses { CId = 3, CName = "C#" });

            // Professors data
            modelBuilder.Entity<Professors>().HasData(new Professors {PId = 1, PName = "Kasimir Cannon", CId = 1},
                new Professors {PId = 2, PName = "Ria Sims", CId = 2},
                new Professors { PId = 3, PName = "Regina Hess", CId = 3 });

            // Students data
            modelBuilder.Entity<Students>().HasData(new Students{SId = 1, SName = "Zeus Randolph" },
                new Students { SId = 2, SName = "Andrej Bojic" },
                new Students { SId = 3, SName = "John Peters" },
                new Students { SId = 4, SName = "John Doe" });

            // StudentCourse data
            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse {SId = 1, CId = 2},
                new StudentCourse { SId = 2, CId = 3 },
                new StudentCourse { SId = 3, CId = 1 },
                new StudentCourse { SId = 4, CId = 3 },
                new StudentCourse { SId = 4, CId = 2 });
        }
    }
}
