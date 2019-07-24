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
    public class MonumentCommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MonumentCommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/MonumentComments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MonumentComments.Include(m => m.Monumenti);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/MonumentComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monumentComments = await _context.MonumentComments
                .Include(m => m.Monumenti)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monumentComments == null)
            {
                return NotFound();
            }

            return View(monumentComments);
        }

        // GET: Admin/MonumentComments/Create
        public IActionResult Create()
        {
            ViewData["MonumentId"] = new SelectList(_context.Monument, "Id", "Id");
            return View();
        }

        // POST: Admin/MonumentComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Comented,MonumentId")] MonumentComments monumentComments)
        {
            if (ModelState.IsValid)
            {
                monumentComments.kohadergimit = DateTime.Now;
                _context.Add(monumentComments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MonumentId"] = new SelectList(_context.Monument, "Id", "Id", monumentComments.MonumentId);
            return View(monumentComments);
        }

        // GET: Admin/MonumentComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monumentComments = await _context.MonumentComments.FindAsync(id);
            if (monumentComments == null)
            {
                return NotFound();
            }
            ViewData["MonumentId"] = new SelectList(_context.Monument, "Id", "Id", monumentComments.MonumentId);
            return View(monumentComments);
        }

        // POST: Admin/MonumentComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Comented,MonumentId")] MonumentComments monumentComments)
        {
            if (id != monumentComments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monumentComments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonumentCommentsExists(monumentComments.Id))
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
            ViewData["MonumentId"] = new SelectList(_context.Monument, "Id", "Id", monumentComments.MonumentId);
            return View(monumentComments);
        }

        // GET: Admin/MonumentComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monumentComments = await _context.MonumentComments
                .Include(m => m.Monumenti)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monumentComments == null)
            {
                return NotFound();
            }

            return View(monumentComments);
        }

        // POST: Admin/MonumentComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monumentComments = await _context.MonumentComments.FindAsync(id);
            _context.MonumentComments.Remove(monumentComments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonumentCommentsExists(int id)
        {
            return _context.MonumentComments.Any(e => e.Id == id);
        }
    }
}
