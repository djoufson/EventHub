using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Event.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using Microsoft.Identity.Client;

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
        public DbSet<EventLike>? EventLikes { get; set; }
        public DbSet<Organizer>? Organizers { get; set; }
        public DbSet<ServiceProposal>? ServiceProposals { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ServiceProposal>()
                .HasOne(r => r.Event)
                .WithMany(p => p.ServiceProposals)
                .HasForeignKey(r => r.EventId);
            modelBuilder.Entity<EventLike>()
                .HasKey(r => new { r.Id });
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
            var hasher = new PasswordHasher<AppUser>();
            var user = new AppUser
            {
                UserName = "Pack",
                NormalizedUserName = "PACK",
                NormalizedEmail = "PACK@GMAIL.COM",
                Email = "pack@gmail.com",
            };
            user.PasswordHash = hasher.HashPassword(user, "pack12341");

            List<Eventt> events = new List<Eventt>
            {
                
            };
            modelBuilder.Entity<Eventt>().HasData(events);
            modelBuilder.Entity<IdentityRole>().HasData(roles);
            modelBuilder.Entity<AppUser>().HasData(user);
        }


    }
}