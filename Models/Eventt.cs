using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Models
{
    public class Eventt
    {
        [Key]
        public int Id { get; set; }
        public Organizer? Organizer { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        public bool IsTicketed { get; set; }
        public string? Location { get; set; }
        public DateTime Date { get; set; }
        public List<RSVP> RSVPs { get; set; } = new List<RSVP>();

        public string ImageUrl { get; set; } = string.Empty;
        public List<string> SecondaryImageUrls { get; set; } = new List<string>();
    }
}