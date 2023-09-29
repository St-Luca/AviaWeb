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
    public class AirTicketsController : Controller
    {
        private readonly AviaContext _context;

        public AirTicketsController(AviaContext context)
        {
            _context = context;
        }

        // GET: AirTickets
        public async Task<IActionResult> Index()
        {
              return _context.AirTickets != null ? 
                          View(await _context.AirTickets.ToListAsync()) :
                          Problem("Entity set 'AviaContext.AirTickets'  is null.");
        }

        [Route("AirTickets/DetailsFull/{ticketId:long}")]
        public async Task<IActionResult> DetailsFull(long ticketId)
        {
            if (_context.AirTickets != null)
            {
                var ticket = await _context.AirTickets.FirstOrDefaultAsync(d => d.Id == ticketId);
                var passenger = await _context.Passengers.FirstOrDefaultAsync(d => d.Id == ticket.PassengerId);
                var documents = await _context.Documents.Where(d => d.PassengerId == passenger.Id).ToListAsync();
                passenger.Documents = documents;
                ticket.Passenger = passenger;

                return View(ticket);
            }
            else
            {
                return Problem("There are no passengers in the DB");
            }
        }

        // GET: AirTickets/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.AirTickets == null)
            {
                return NotFound();
            }

            var airTicket = await _context.AirTickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (airTicket == null)
            {
                return NotFound();
            }

            return View(airTicket);
        }

        // GET: AirTickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AirTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Departure,Arrival,DateOfConclusion,DepartureDate,ArrivalDate,Company")] AirTicket airTicket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(airTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(airTicket);
        }

        // GET: AirTickets/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.AirTickets == null)
            {
                return NotFound();
            }

            var airTicket = await _context.AirTickets.FindAsync(id);
            if (airTicket == null)
            {
                return NotFound();
            }
            ViewBag.PassengerId = new SelectList(_context.Passengers, "Id", "Id", airTicket.PassengerId);
            ViewBag.Passenger = airTicket.Passenger;
            return View(airTicket);
        }

        // POST: AirTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Departure,Arrival,DateOfConclusion,DepartureDate,ArrivalDate,Company,PassengerId")] AirTicket airTicket)
        {
            if (id != airTicket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(airTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirTicketExists(airTicket.Id))
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
            ViewBag.PassengerId = new SelectList(_context.Passengers, "Id", "Id", airTicket.PassengerId);
            return View(airTicket);
        }

        // GET: AirTickets/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.AirTickets == null)
            {
                return NotFound();
            }

            var airTicket = await _context.AirTickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (airTicket == null)
            {
                return NotFound();
            }

            return View(airTicket);
        }

        // POST: AirTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.AirTickets == null)
            {
                return Problem("Entity set 'AviaContext.AirTickets'  is null.");
            }
            var airTicket = await _context.AirTickets.FindAsync(id);
            if (airTicket != null)
            {
                _context.AirTickets.Remove(airTicket);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AirTicketExists(long id)
        {
          return (_context.AirTickets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
