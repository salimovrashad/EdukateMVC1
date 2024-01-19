using EdukateMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace EdukateMVC.Context
{
    public class EdukateDbContext : IdentityDbContext
    {
        public EdukateDbContext(DbContextOptions opt) : base(opt) { }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Settings> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Settings>().HasData(
                new Settings
                {
                    Id = 1,
                    Adress = "123 Street, New York, USA",
                    Phone = "099012 345 67890",
                    Email = "info@example.com"
                });
            base.OnModelCreating(builder);
        }

    }
}
