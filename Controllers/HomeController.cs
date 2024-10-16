using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Event.Models;
using Event.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Event.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Event.Services.EmailService;
using Event.Interfaces;
using Newtonsoft.Json.Linq;

namespace Event.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    private readonly IEmailSender _emailSender;
    private readonly IHttpClientFactory _clientFactory;
    private readonly string googleApiKey;
    public HomeController(ApplicationDbContext context, UserManager<AppUser> userManager, IEmailSender emailSender, IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _context = context;
        _userManager = userManager;
        _emailSender = emailSender;
        _clientFactory = clientFactory;
        googleApiKey = configuration["GoogleApiKey"];
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

        // Example logic to get trending events (based on number of likes)
        var trendingEvents = events.Where(e => e.LikesCount > 1).ToList();

        // Categorize events
        var techEvents = events.Where(e => e.Category == "Tech").ToList();
        var musicEvents = events.Where(e => e.Category == "Music").ToList();
        var onlineEvents = events.Where(e => e.Category == "Online").ToList();


        var viewModel = new MainPageViewModel
        {
            AllEvents = events.Select(e => new EventDisplayViewModel { Event = e }).ToList(),
            TrendingEvents = trendingEvents.Select(e => new EventDisplayViewModel { Event = e }).ToList(),
            TechEvents = techEvents.Select(e => new EventDisplayViewModel { Event = e }).ToList(),
            MusicEvents = musicEvents.Select(e => new EventDisplayViewModel { Event = e }).ToList(),
            OnlineEvents = onlineEvents.Select(e => new EventDisplayViewModel { Event = e }).ToList(),
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
            await _context.SaveChangesAsync();
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
        return View("EventDetails", _event);
    }

    [HttpGet]
    public async Task<IActionResult> Search(string keyword)
    {
        var query = _context.Events.AsQueryable();
        var events = await query.Where(e => e.Category.Contains(keyword)).ToListAsync();
        var user = await _userManager.GetUserAsync(User);
        var userRSVPedEventIds = await _context.RSVPs
                                        .Where(r => r.AttendeeId == user.Id)
                                        .Select(r => r.EventId)
                                        .ToListAsync();
        var eventViewModels = events.Select(e => new EventDisplayViewModel
        {
            Event = e,
            IsRsvped = userRSVPedEventIds.Contains(e.Id)
        }).ToList();
        return View("Index", eventViewModels);
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

}
