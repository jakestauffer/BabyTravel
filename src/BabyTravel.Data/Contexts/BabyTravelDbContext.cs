using BabyTravel.Data.Encryption;
using BabyTravel.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Data.Contexts
{
    public class BabyTravelDbContext : DbContext
    {
        public DbSet<Baby> Baby { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Trip> Trip { get; set; }

        public BabyTravelDbContext(DbContextOptions<BabyTravelDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<User>();

            entityBuilder.Property(x => x.Password).HasConversion<EncryptionConvertor>();
        }
    }
}
