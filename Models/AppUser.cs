using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Event.Models
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? Town { get; set; }
        public List<RSVP> RSVPs { get; set; } = new List<RSVP>();
    }
}