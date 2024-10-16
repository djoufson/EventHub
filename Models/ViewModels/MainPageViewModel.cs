using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Models.ViewModels
{
    public class MainPageViewModel
    {
        public List<EventDisplayViewModel> AllEvents { get; set; }  
        public List<EventDisplayViewModel> TrendingEvents { get; set; } 
        public List<EventDisplayViewModel> TechEvents { get; set; }
        public List<EventDisplayViewModel> MusicEvents { get; set; }
        public List<EventDisplayViewModel> OnlineEvents { get; set; }
        public List<Organizer> Organizers { get; set; }

        // Add other categories as needed
    }

}