using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Event.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace Event.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions options)
        : base(options)
        {

        }

        public DbSet<Eventt>? Events { get; set; }
        public DbSet<RSVP>? RSVPs { get; set; }
        public DbSet<Organizer>? Organizers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RSVP>()
                .HasKey(r => new { r.Id });

            modelBuilder.Entity<RSVP>()
                .HasOne(r => r.Event)
                .WithMany(e => e.RSVPs)
                .HasForeignKey(r => r.EventId);

            modelBuilder.Entity<RSVP>()
                .HasOne(r => r.Attendee)
                .WithMany(u => u.RSVPs)
                .HasForeignKey(r => r.AttendeeId)
                .IsRequired();

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name ="Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            List<Eventt> events = new List<Eventt>
            {
                new Eventt
                {
                    Id = 1,
                    Category = "Concert",
                    Description = "A kindom invasion, bringing the presence of God the the lost sheep",
                    IsTicketed = false
                },
                 new Eventt
                {
                    Id = 2,
                    Category = "Art",
                    Description = "Lux amiga putting everyone on the dancing floor",
                    IsTicketed = true
                },
            };
            modelBuilder.Entity<Eventt>().HasData(events);
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }


    }
}