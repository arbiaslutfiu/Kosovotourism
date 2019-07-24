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
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Reports
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["emailSortParm"] = String.IsNullOrEmpty(sortOrder) ? "email_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            var reports = from s in _context.Reports
                           select s;
            switch (sortOrder)
            {
                case "email_desc":
                    reports = reports.OrderByDescending(s => s.email);
                    break;
                case "Date":
                    reports = reports.OrderBy(s => s.kohadergimit);
                    break;
                case "date_desc":
                    reports = reports.OrderByDescending(s => s.kohadergimit);
                    break;
                default:
                    reports = reports.OrderBy(s => s.email);
                    break;
            }
            return View(await reports.AsNoTracking().ToListAsync());
           // return View(await _context.Reports.ToListAsync());
        }

        // GET: Admin/Reports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reports = await _context.Reports
                .FirstOrDefaultAsync(m => m.id == id);
            if (reports == null)
            {
                return NotFound();
            }

            return View(reports);
        }

        // GET: Admin/Reports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Reports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,email,description,kohadergimit")] Reports reports)
        {
            if (ModelState.IsValid)
            {
                reports.kohadergimit = DateTime.Now;
                _context.Add(reports);
                await _context.SaveChangesAsync();
                if (User.IsInRole("Administrator"))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //return View("~/Views/Home/Index.cshtml");
                    //return RedirectToAction("WellDone", "WellDone");
                    return RedirectToAction(nameof(WellDone));
                }
            }
        
            if (User.IsInRole("Administrator"))
            {
                return View(reports);
            }
            else
            {
                return RedirectToAction("Index", "Home", "");
            }
        }


        public IActionResult WellDone()
        {
            return View();
        }

        // GET: Admin/Reports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reports = await _context.Reports.FindAsync(id);
            if (reports == null)
            {
                return NotFound();
            }
            return View(reports);
        }

        // POST: Admin/Reports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,email,description,kohadergimit")] Reports reports)
        {
            if (id != reports.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reports);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportsExists(reports.id))
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
            return View(reports);
        }

        // GET: Admin/Reports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reports = await _context.Reports
                .FirstOrDefaultAsync(m => m.id == id);
            if (reports == null)
            {
                return NotFound();
            }

            return View(reports);
        }

        // POST: Admin/Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reports = await _context.Reports.FindAsync(id);
            _context.Reports.Remove(reports);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportsExists(int id)
        {
            return _context.Reports.Any(e => e.id == id);
        }
    }
}
