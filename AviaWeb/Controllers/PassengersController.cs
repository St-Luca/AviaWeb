using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AviaWeb.Models;

namespace AviaWeb.Controllers
{
    public class PassengersController : Controller
    {
        private readonly AviaContext _context;

        public PassengersController(AviaContext context)
        {
            _context = context;
        }

        // GET: Passengers
        public async Task<IActionResult> Index()
        {
            var aviaContext = _context.Passengers.Include(p => p.AirTickets);
            return View(await aviaContext.ToListAsync());
        }

        [Route("Passengers/DetailsForTicket/{passengerId:long}")]
        public async Task<IActionResult> DetailsForTicket(long passengerId)
        {
            if (_context.Passengers != null)
            {

                return View(await _context.Passengers.Where(d => d.Id == passengerId).ToListAsync());
            }
            else
            {
                return Problem("There are no passengers in the DB");
            }
        }

        // GET: Passengers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Passengers == null)
            {
                return NotFound();
            }

            var passenger = await _context.Passengers
                .Include(p => p.AirTickets)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passenger == null)
            {
                return NotFound();
            }

            return View(passenger);
        }

        // GET: Passengers/Create
        public IActionResult Create()
        {
            ViewData["AirTicketId"] = new SelectList(_context.AirTickets, "Id", "Id");
            return View();
        }

        // POST: Passengers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LastName,FirstName,Patronical,AirTicketId")] Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passenger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AirTicketId"] = new SelectList(_context.AirTickets, "Id", "Id", passenger.AirTickets); ///////////
            return View(passenger);
        }

        // GET: Passengers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Passengers == null)
            {
                return NotFound();
            }

            var passenger = await _context.Passengers.FindAsync(id);
            if (passenger == null)
            {
                return NotFound();
            }
            ViewData["AirTicketId"] = new SelectList(_context.AirTickets, "Id", "Id", passenger.AirTickets);///////////
            return View(passenger);
        }

        // POST: Passengers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,LastName,FirstName,Patronical")] Passenger passenger)
        {
            if (id != passenger.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passenger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassengerExists(passenger.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AirTicketId"] = new SelectList(_context.AirTickets, "Id", "Id", passenger.AirTickets);/////////
            return View(passenger);
        }

        // GET: Passengers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Passengers == null)
            {
                return NotFound();
            }

            var passenger = await _context.Passengers
                .Include(p => p.AirTickets) //////////
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passenger == null)
            {
                return NotFound();
            }

            return View(passenger);
        }

        // POST: Passengers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Passengers == null)
            {
                return Problem("Entity set 'AviaContext.Passengers'  is null.");
            }
            var passenger = await _context.Passengers.FindAsync(id);
            if (passenger != null)
            {
                _context.Passengers.Remove(passenger);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassengerExists(long id)
        {
          return (_context.Passengers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
