using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Monument_Scann.Areas.Admin.Models;
using Monument_Scann.Data;

namespace Monument_Scann.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class touristspotsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public touristspotsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/touristspots
        public async Task<IActionResult> Index()
        {
            return View(await _context.touristspot.ToListAsync());
        }

        // GET: Admin/touristspots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var touristspot = await _context.touristspot
                .FirstOrDefaultAsync(m => m.Id == id);
            if (touristspot == null)
            {
                return NotFound();
            }

            return View(touristspot);
        }

        // GET: Admin/touristspots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/touristspots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,History,NrLike,Citys,Image")] touristspot touristspot, IFormFile imageFile)
        {
            if (ModelState.IsValid && imageFile != null)
            {

                var fileName = Path.GetRandomFileName() + Path.GetExtension(imageFile.FileName);
                var fileDirectory = "wwwroot/images";

                if (!Directory.Exists(fileDirectory))
                {
                    Directory.CreateDirectory(fileDirectory);
                }
                var filePath = fileDirectory + "/" + fileName;

                // Copy file to path...
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                touristspot.Image = fileName;

                // Add object to db

                _context.Add(touristspot);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(touristspot);
        }

        // GET: Admin/touristspots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var touristspot = await _context.touristspot.FindAsync(id);
            if (touristspot == null)
            {
                return NotFound();
            }
            return View(touristspot);
        }

        // POST: Admin/touristspots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,History,NrLike,Citys,Image")] touristspot touristspot, IFormFile imageFile)
        {
            if (id != touristspot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (imageFile != null)
                    {
                        var fileName = Path.GetRandomFileName() + Path.GetExtension(imageFile.FileName);
                        var fileDirectory = "wwwroot/images";

                        if (!Directory.Exists(fileDirectory))
                        {
                            Directory.CreateDirectory(fileDirectory);
                        }

                        var filePath = fileDirectory + "/" + fileName;

                        // Copy file to path...
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await imageFile.CopyToAsync(stream);
                        }

                        touristspot.Image = fileName;
                    }
                    else
                    {

                    }
                    _context.Update(touristspot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!touristspotExists(touristspot.Id))
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
            return View(touristspot);
        }

        // GET: Admin/touristspots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var touristspot = await _context.touristspot
                .FirstOrDefaultAsync(m => m.Id == id);
            if (touristspot == null)
            {
                return NotFound();
            }

            return View(touristspot);
        }

        // POST: Admin/touristspots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var touristspot = await _context.touristspot.FindAsync(id);
            _context.touristspot.Remove(touristspot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool touristspotExists(int id)
        {
            return _context.touristspot.Any(e => e.Id == id);
        }
    }
}
