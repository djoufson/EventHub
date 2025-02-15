using Event.Data;
using Event.Models;
using Event.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Event.Pages
{
    public class ProposeService : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public ProposeService(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty(SupportsGet = true)]
        public ServiceProposalViewModel ProposalModel { get; set; } = new ServiceProposalViewModel();

        public void OnGet()
        {
            ProposalModel.AvailableEventTypes = new List<string>{
                "Concert",
                "Conference",
                "Tech",
                "Church"
            };

        }

        [FromRoute]
        public int? EventId { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var author = await _userManager.GetUserAsync(User);
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return StatusCode(500, "There was an error while submitting the service proposal.");
            }
            if (EventId.HasValue)
            {
                var serviceProposal = new ServiceProposal
                {
                    Description = ProposalModel.ServiceProposal.Description,
                    EventTypes = ProposalModel.ServiceProposal.EventTypes,
                    EventId = EventId,
                    AuthorId = author.Id,
                    DateProposed = DateTime.UtcNow,
                    Status = "Pending"
                };
                _context.ServiceProposals.Add(serviceProposal);
                await _context.SaveChangesAsync();
            }
            else
            {
                var serviceProposal = new ServiceProposal
                {
                    Description = ProposalModel.ServiceProposal.Description,
                    EventTypes = ProposalModel.ServiceProposal.EventTypes,
                    EventId = null,
                    AuthorId = author.Id,
                    DateProposed = DateTime.UtcNow,
                    Status = "Pending"
                };
                _context.ServiceProposals.Add(serviceProposal);
                await _context.SaveChangesAsync();
            }


            return RedirectToAction("Index");
        }



    }
}