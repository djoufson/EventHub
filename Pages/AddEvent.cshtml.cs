using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Data;
using Event.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Event.Pages
{
    public class AddEvent : PageModel
    {
        private readonly ApplicationDbContext _context;
        public readonly IWebHostEnvironment _environment;

        [BindProperty(SupportsGet = true)]
        public Eventt Event { get; set; }

        [BindProperty(SupportsGet = true)]
        public IFormFile CoverImage { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<IFormFile> EventImages { get; set; } = new List<IFormFile>();

        public AddEvent(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;

        }

        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (EventImages != null && EventImages.Count > 0)
            {
                foreach (var image in EventImages)
                {
                    if (image.Length > 0)
                    {
                        var filePath = Path.Combine(_environment.WebRootPath, "assets", image.FileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await image.CopyToAsync(stream);
                        }
                        // Add image URL to the Event's ImageUrls list
                        Event.SecondaryImageUrls.Add($"assets/{image.FileName}");
                    }
                }
            }
            if (CoverImage != null)
            {

                var filePath = Path.Combine(_environment.WebRootPath, "assets", CoverImage.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await CoverImage.CopyToAsync(stream);
                }
                Event.ImageUrl = $"assets/{CoverImage.FileName}";

            }
            await _context.Events.AddAsync(Event);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Index");

        }
    }
}