using AviaWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AviaWeb.Controllers
{
    public class ReportController : Controller
    {
        private readonly AviaContext _context;

        public ReportController(AviaContext context)
        {
            _context = context;
        }
        // GET: ReportController
        public async Task<IActionResult> Information()
        {
            var aviaContext = _context.AirTickets;
            return View(await aviaContext.ToListAsync());
        }

        //[Route("Report/Information/{id:int}")]
        //public async Task<IActionResult> Information(long id)
        //{
        //    if (_context.Passengers != null && _context.AirTickets != null)
        //    {
        //        Passenger pass = _context.Passengers.FirstOrDefault(x => x.Id == id);
        //        return View(await _context.AirTickets.Where(d => d.PassengerId == pass.Id).ToListAsync());
        //    }
        //    else
        //    {
        //        return Problem("Not enough data");
        //    }
        //}

        [Route("Report/Information")]
        public async Task<IActionResult> Information([FromQuery] long id, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            if (_context.Passengers != null && _context.AirTickets != null)
            {
                Passenger pass = _context.Passengers.Find(id);
                if(pass == null)
                {
                    return Problem("Такого пассажира нет");
                }
                else
                {
                    var tickets = await _context.AirTickets.Where(d => d.PassengerId == pass.Id).ToListAsync();
                    var filteredTickets = tickets.Where(t => (t.ArrivalDate >= startDate && t.ArrivalDate <= endDate) ||
                                                       (t.DateOfConclusion >= startDate && t.DateOfConclusion <= endDate));
                    return View(filteredTickets);
                }
            }
            else
            {
                return Problem("Not enough data");
            }
        }

        // GET: ReportController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReportController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReportController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReportController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReportController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReportController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReportController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
