using GymScheduleBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GymScheduleBackend.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Gym> Gyms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Server=.;Database=MyDatabase;Trusted_Connection=True;");
    }
}
