using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Models.ViewModels
{
    public class EventDisplayViewModel
    {
        public Eventt Event { get; set; }
        public bool IsRsvped { get; set; }
    }
}