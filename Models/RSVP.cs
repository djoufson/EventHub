using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Models
{
    public class RSVP
    {
        [Key]
        public int Id { get; set; }
        public Eventt Event { get; set; }
        public int EventId { get; set; }
        public AppUser Attendee {get; set;}
        public string AttendeeId { get; set; }
        
    }
}