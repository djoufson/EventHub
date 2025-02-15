using Event.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Event.Models;

namespace Event.Pages
{
    public class AddOrganizer : PageModel
    {
        private readonly ApplicationDbContext _context;
        public readonly IWebHostEnvironment _environment;
        public AddOrganizer(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;

        }
        [BindProperty(SupportsGet = true)]
        public IFormFile ProfileImage { get; set; }
        [BindProperty(SupportsGet = true)]
        public Organizer Input { get; set; } = new Organizer();

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return StatusCode(500, "There was an error while creating the organizer");
            }

            if (ProfileImage != null)
            {

                var filePath = Path.Combine(_environment.WebRootPath, "assets", ProfileImage.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ProfileImage.CopyToAsync(stream);
                }
                Input.ProfileImageUrl = $"assets/{ProfileImage.FileName}";

            }
            await _context.Organizers.AddAsync(Input);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");

        }
    }
}