using Microsoft.AspNetCore.Mvc;
using Event.Models;
using Event.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Event.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Event.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    public HomeController(ApplicationDbContext context, UserManager<AppUser> userManager, IConfiguration configuration)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToPage("/Login");
        }
        var events = await _context.Events.ToListAsync();
        var organizers = await _context.Organizers.ToListAsync();
        var userRSVPedEventIds = await _context.RSVPs
                                        .Where(r => r.AttendeeId == user.Id)
                                        .Select(r => r.EventId)
                                        .ToListAsync();
        var generalServices = _context.ServiceProposals
                   .Where(sp => sp.EventId == null)
                   .ToList();

        var trendingEvents = events.Where(e => e.LikesCount > 1).ToList();

        // Categorize events
        var techEvents = events.Where(e => e.Category == "Tech").ToList();
        var musicEvents = events.Where(e => e.Category == "Music").ToList();
        var onlineEvents = events.Where(e => e.Category == "Online").ToList();


        var viewModel = new MainPageViewModel
        {
            AllEvents = events.Select(e => new EventDisplayViewModel { Event = e, IsRsvped = userRSVPedEventIds.Contains(e.Id) }).ToList(),
            TrendingEvents = trendingEvents.Select(e => new EventDisplayViewModel { Event = e, IsRsvped = userRSVPedEventIds.Contains(e.Id) }).ToList(),
            TechEvents = techEvents.Select(e => new EventDisplayViewModel { Event = e, IsRsvped = userRSVPedEventIds.Contains(e.Id) }).ToList(),
            MusicEvents = musicEvents.Select(e => new EventDisplayViewModel { Event = e, IsRsvped = userRSVPedEventIds.Contains(e.Id) }).ToList(),
            OnlineEvents = onlineEvents.Select(e => new EventDisplayViewModel { Event = e, IsRsvped = userRSVPedEventIds.Contains(e.Id) }).ToList(),
            Organizers = organizers
        };

        return View(viewModel);


    }

    [HttpPost]
    public async Task<IActionResult> Rsvp(int id)
    {
        var user = await _userManager.GetUserAsync(User);
        var _event = await _context.Events.FindAsync(id);
        var existingRsvp = await _context.RSVPs
                                      .FirstOrDefaultAsync(r => r.EventId == id && r.AttendeeId == user.Id);
        bool isRsvped;
        if (existingRsvp == null)
        {
            RSVP rsvp = new RSVP
            {
                Event = _event,
                EventId = _event.Id,
                Attendee = user,
                AttendeeId = user.Id,
            };
            user.RSVPs.Add(rsvp);
            _context.Add(rsvp);
            _context.SaveChanges();
            isRsvped = true;
        }
        else
        {

            isRsvped = true;
        }

        return Json(new { success = true, isRsvped });
    }


    [Authorize]
    public async Task<IActionResult> GetEvent(int id)
    {
        var _event = await _context.Events.FindAsync(id);
        var eventSpecificServices = _context.ServiceProposals
                         .Where(sp => sp.EventId == _event.Id)
                         .ToList();
        var suggestedServices = await _context.ServiceProposals
                                    .Include(sp => sp.Event) // Join with Event data
                                    .Where(sp => sp.Event == null || sp.Event.Category == _event.Category)
                                    .ToListAsync();
        var similarEvents = await _context.Events
            .Where(e => e.Category == _event.Category && e.Id != _event.Id) // Exclude the main event
            .Select(e => new EventDisplayViewModel { Event = e })
            .ToListAsync();

        var generalServices = _context.ServiceProposals.ToList();
        var viewModel = new EventDetailsViewModel
        {
            Event = _event,
            Services = suggestedServices,
            SimilarEvents = similarEvents

        };
        return View("EventDetails", viewModel);
    }

    public async Task<IActionResult> GetEvents()
    {
        var _events = await _context.Events.ToListAsync();
        var viewmodel = new EventsPageViewModel
        {
            Events = _events.Select(e => new EventDisplayViewModel { Event = e }).ToList()
        };
        return View("EventsPage", viewmodel);
    }

    [HttpPost]
    public async Task<IActionResult> LikeEvent(int eventId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return Json(new { success = false });
        }

        var eventLike = await _context.EventLikes
                          .FirstOrDefaultAsync(el => el.EventId == eventId && el.UserId == user.Id);

        if (eventLike == null) // User hasn't liked the event yet
        {
            // Create a new like record
            var newLike = new EventLike
            {
                EventId = eventId,
                UserId = user.Id,
                LikedOn = DateTime.Now
            };
            _context.EventLikes.Add(newLike);

            // Increment the event's likes count
            var eventToUpdate = await _context.Events.FindAsync(eventId);
            eventToUpdate.LikesCount++;
            await _context.SaveChangesAsync();

            return Json(new { success = true, likesCount = eventToUpdate.LikesCount });
        }

        return Json(new { success = false });
    }

    [HttpGet]
    public async Task<IActionResult> Search(string keyword)
    {
        Console.WriteLine($"Searching for events with keyword: {keyword}");
        try
        {
            var searchedEvents = _context.Events
                .Where(e => e.Description.Contains(keyword))
                .Select(e => new EventDisplayViewModel { Event = e })
                .AsNoTracking()
                .ToList();
            return View("SearchedEvents", searchedEvents);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in Search: {ex.Message}");
            return StatusCode(500, "An error occurred while processing your request.");
        }

    }

    public async Task<IActionResult> FilterEvents(string category)
    {
        var filteredEvents = await _context.Events
            .Where(e => e.Category == category)
            .ToListAsync();

        return PartialView("_EventListPartial", filteredEvents);
    }


}
