﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AviaWeb.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis;
using Document = AviaWeb.Models.Document;

namespace AviaWeb.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly AviaContext _context;
        private long passengerId;

        public DocumentsController(AviaContext context)
        {
            _context = context;
        }

        // GET: Documents
        public async Task<IActionResult> Index()
        {
            if(_context.Documents != null)
            {

                return View(await _context.Documents.ToListAsync());
            }
            else
            {
                return Problem("Entity set 'AviaContext.Documents'  is null.");
            }        
        }

        [Route("Documents/{id:long}")]
        public async Task<IActionResult> Index(long id)
        {
            if (_context.Documents != null)
            {
                return View(await _context.Documents.Where(d => d.PassengerId == id).ToListAsync());
            }
            else
            {
                return Problem("Entity set 'AviaContext.Documents'  is null.");
            }
        }

        // GET: Documents/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Documents == null)
            {
                return NotFound();
            }

            var document = await _context.Documents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // GET: Documents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type")] Document document)
        {
            if (ModelState.IsValid)
            {
                _context.Add(document);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(document);
        }

        // GET: Documents/Edit/5
        public async Task<IActionResult> Edit(long? id) //[FromQuery] long passId)
        {
            if (id == null || _context.Documents == null)
            {
                return NotFound();
            }

            var document = await _context.Documents.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }
            passengerId = document.PassengerId;
            ViewBag.PassengerId = _context.Passengers.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.Id.ToString(),
                                      Text = a.Id.ToString()
                                  }).ToList();
            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Type,PassengerId")] Document document)
        {
            if (id != document.Id)
            {
                return NotFound();
            }
            document.Passenger = await _context.Passengers.FirstOrDefaultAsync(p => p.Id == document.PassengerId);
            //document.Passenger = await _context.Passengers.FirstOrDefaultAsync(p => p.Id == document.PassengerId);
            // document.Passenger = await _context.Passengers.FirstOrDefaultAsync(p => p.Id == passengerId);
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(document);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentExists(document.Id))
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
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            ViewBag.PassengerId = _context.Passengers.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.Id.ToString(),
                                      Text = a.Id.ToString()
                                  }).ToList();
            return View(document);
            
        }

        // GET: Documents/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Documents == null)
            {
                return NotFound();
            }

            var document = await _context.Documents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (document == null)
            {
                return NotFound();
            }

            return View();
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Documents == null)
            {
                return Problem("Entity set 'AviaContext.Documents'  is null.");
            }
            var document = await _context.Documents.FindAsync(id);
            if (document != null)
            {
                _context.Documents.Remove(document);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Passengers/Index");
        }

        private bool DocumentExists(long id)
        {
          return (_context.Documents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
