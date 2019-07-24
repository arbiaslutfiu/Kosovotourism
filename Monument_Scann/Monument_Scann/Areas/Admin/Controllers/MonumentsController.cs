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

namespace Monument_Scann.Areas.Admin
{
    [Area("Admin")]
    public class MonumentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MonumentsController(ApplicationDbContext context)
        {
            _context = context;
        }
       
        // GET: Admin/Monuments
        public async Task<IActionResult> Index()
        {            
            return View(await _context.Monument.ToListAsync());
        }
      
        // GET: Admin/Monuments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monument = await _context.Monument
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monument == null)
            {
                return NotFound();
            }

            return View(monument);
        }

        // GET: Admin/Monuments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Monuments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Monument monument, IFormFile imageFile)
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

                monument.Image = fileName;

                // Add object to db
                

                _context.Add(monument);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(monument);
        }

        // GET: Admin/Monuments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monument = await _context.Monument.FindAsync(id);
            if (monument == null)
            {
                return NotFound();
            }
            return View(monument);
        }

        // POST: Admin/Monuments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,History,NrLike,Citys,Image")] Monument monument, IFormFile imageFile)
        {
            if (id != monument.Id)
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

                        monument.Image = fileName;
                    }
                    else
                    {

                    }
                    _context.Update(monument);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonumentExists(monument.Id))
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
            return View(monument);
        }

        // GET: Admin/Monuments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monument = await _context.Monument
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monument == null)
            {
                return NotFound();
            }

            return View(monument);
        }

        // POST: Admin/Monuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monument = await _context.Monument.FindAsync(id);
            _context.Monument.Remove(monument);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonumentExists(int id)
        {
            return _context.Monument.Any(e => e.Id == id);
        }
    }
}
