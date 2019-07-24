using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Monument_Scann.Areas.Admin.Models;
using Monument_Scann.Data;

namespace Monument_Scann.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TouristSpotComentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TouristSpotComentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/TouristSpotComents
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TouristSpotComents.Include(t => t.Touristspoti);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/TouristSpotComents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var touristSpotComents = await _context.TouristSpotComents
                .Include(t => t.Touristspoti)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (touristSpotComents == null)
            {
                return NotFound();
            }

            return View(touristSpotComents);
        }

        // GET: Admin/TouristSpotComents/Create
        public IActionResult Create()
        {
            ViewData["touristspotId"] = new SelectList(_context.touristspot, "Id", "Id");
            return View();
        }

        // POST: Admin/TouristSpotComents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Comented,touristspotId")] TouristSpotComents touristSpotComents)
        {
            if (ModelState.IsValid)
            {
                touristSpotComents.kohadergimit = DateTime.Now;
                _context.Add(touristSpotComents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["touristspotId"] = new SelectList(_context.touristspot, "Id", "Id", touristSpotComents.touristspotId);
            return View(touristSpotComents);
        }

        // GET: Admin/TouristSpotComents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var touristSpotComents = await _context.TouristSpotComents.FindAsync(id);
            if (touristSpotComents == null)
            {
                return NotFound();
            }
            ViewData["touristspotId"] = new SelectList(_context.touristspot, "Id", "Id", touristSpotComents.touristspotId);
            return View(touristSpotComents);
        }

        // POST: Admin/TouristSpotComents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Comented,touristspotId")] TouristSpotComents touristSpotComents)
        {
            if (id != touristSpotComents.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(touristSpotComents);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TouristSpotComentsExists(touristSpotComents.Id))
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
            ViewData["touristspotId"] = new SelectList(_context.touristspot, "Id", "Id", touristSpotComents.touristspotId);
            return View(touristSpotComents);
        }

        // GET: Admin/TouristSpotComents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var touristSpotComents = await _context.TouristSpotComents
                .Include(t => t.Touristspoti)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (touristSpotComents == null)
            {
                return NotFound();
            }

            return View(touristSpotComents);
        }

        // POST: Admin/TouristSpotComents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var touristSpotComents = await _context.TouristSpotComents.FindAsync(id);
            _context.TouristSpotComents.Remove(touristSpotComents);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TouristSpotComentsExists(int id)
        {
            return _context.TouristSpotComents.Any(e => e.Id == id);
        }
    }
}
