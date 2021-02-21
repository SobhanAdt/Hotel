using System;
using System.Collections.Generic;
using System.Text;
using App.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastucture.EF.Database
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext()
        {

        }

        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {

        }

        public DbSet<City> Cities { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserLogin> UserLogins { get; set; }

        public DbSet<Core.Entities.Hotel> Hotels { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<ReviewAnswer> ReviewAnswers { get; set; }

        public DbSet<Star> Stars { get; set; }

        public DbSet<UserRate> UserRates { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<City>(x => x.ToTable("City"));
            builder.Entity<User>(x => x.ToTable("User"));
            builder.Entity<UserLogin>(x => x.ToTable("UserLogin"));
            builder.Entity<Core.Entities.Hotel>(x => x.ToTable("Hotel"));
            builder.Entity<Room>(x => x.ToTable("Room"));
            builder.Entity<Review>(x => x.ToTable("Review"));
            builder.Entity<ReviewAnswer>(x => x.ToTable("ReviewAnswer"));
            builder.Entity<Star>(x => x.ToTable("Star"));
            builder.Entity<UserRate>(x => x.ToTable("UserRate"));
        }

    }
}
