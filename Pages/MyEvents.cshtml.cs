using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Data;
using Event.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Event.Pages
{
    public class MyEvents : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public MyEvents(ApplicationDbContext context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            
        }
        [BindProperty(SupportsGet = true)]
        public IList<RSVP> Rsvps { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            Rsvps = await _context.RSVPs
                                      .Include(r => r.Event)
                                      .Where(r => r.AttendeeId == user.Id)
                                      .ToListAsync();
            if(Rsvps == null)
            {
                return StatusCode(500,"Something went wrong");
            }
            return Page();
        }
    }
}