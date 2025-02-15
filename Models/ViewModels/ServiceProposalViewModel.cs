using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Models.ViewModels
{
    public class ServiceProposalViewModel
    {
        public ServiceProposal ServiceProposal { get; set; }
        public List<string?> ? AvailableEventTypes { get; set; }
    }
}