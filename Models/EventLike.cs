using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Models
{
    public class EventLike
    {
        public int Id { get; set; }
        public string UserId { get; set; } 
        public int EventId { get; set; } 
        public DateTime LikedOn { get; set; }

        public virtual AppUser User { get; set; }
        public virtual Eventt Event { get; set; }
    }
}