using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Models
{
    public class ServiceProposal
    {
        [Key]
        public int Id { get; set; }
        public AppUser? Author { get; set; }
        public string? AuthorId {get; set;}
        public string Description{ get; set; }
        public List<string>? EventTypes { get; set; }
        public Eventt? Event { get; set; }
        public int? EventId { get; set; }
        public DateTime DateProposed { get; set; }
        public string? Status { get; set; }
    }
}