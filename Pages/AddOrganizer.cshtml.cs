using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Event.Contracts;
using Microsoft.Extensions.Logging;
using Event.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Event.Pages
{
    public class AddOrganizer : PageModel
    {
        private readonly ApplicationDbContext _context;
        public AddOrganizer(ApplicationDbContext context)
        {
            _context = context;

        }

        [BindProperty(SupportsGet = true)]
        public Organizer Input { get; set; } = new Organizer();

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(500);
            }
            var organizer = _context.Organizers.Add(Input);
            Console.WriteLine(Input.Name);
            if (organizer == null)
            {
                return StatusCode(500, "There was an error while creating the organizer");
            }
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");

        }
    }
}