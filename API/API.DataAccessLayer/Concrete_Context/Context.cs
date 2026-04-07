using API.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.DataAccessLayer.Concrete_Context
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=YOUR ADRESS;database=HotelsProject;integrated security=true;" +
                    "TrustServerCertificate=True;");
            }
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reff> Reffs { get; set; }
        public DbSet<Duty> Dutys { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<SendedMessages> SendedMessagesdb { get; set; }
        public DbSet<ContactCategory> ContactCategories { get; set; }
    }
}
