using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Models.ViewModels
{
    public class EventDetailsViewModel
    {
        public Eventt Event { get; set; }
        public List<ServiceProposal>? Services { get; set; }
        public List<EventDisplayViewModel>? SimilarEvents { get; set; }
    }
}