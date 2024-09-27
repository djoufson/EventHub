using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Event.Models;
using Event.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Event.Models.ViewModels;

namespace Event.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    public HomeController(ApplicationDbContext context, UserManager<AppUser> userManager)
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
        var userRSVPedEventIds = await _context.RSVPs
                                        .Where(r => r.AttendeeId == user.Id)
                                        .Select(r => r.EventId)
                                        .ToListAsync();

        var eventViewModels = events.Select(e => new EventDisplayViewModel
        {
            Event = e,
            IsRsvped = userRSVPedEventIds.Contains(e.Id)
        }).ToList();
        return View(eventViewModels);
    }

    public async Task<IActionResult> Rsvp(int id)
    {
        var user = await _userManager.GetUserAsync(User);
        var _event = await _context.Events.FindAsync(id);
        var existingRsvp = await _context.RSVPs
                                      .FirstOrDefaultAsync(r => r.EventId == id && r.AttendeeId == user.Id);
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
        }

        return RedirectToAction("Index");
    }


    public async Task<IActionResult> GetEvent(int id)
    {
        var _event = await _context.Events.FindAsync(id);
        return View("EventDetails", _event);
    }

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
}
