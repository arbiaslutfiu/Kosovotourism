using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Monument_Scann.Areas.Admin.Models;
using Monument_Scann.Data;
using Monument_Scann.Models;

namespace Monument_Scann.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;


        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string CurrentUserId
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    return User.FindFirst(ClaimTypes.NameIdentifier).Value;
                } else {
                    return " skauser";
                }
                
            }
        }
        
        public async Task<IActionResult> LikedMOn(int Id) 
        {
            
           var mon = _dbContext.Monument.FirstOrDefault(x => x.Id == Id);
          
            if (mon.LajkiM == null)
            {
                try{
                    
                    mon.LajkiM = _dbContext.Lajkis.First(m => m.MonumentsId == mon.Id && m.UserId == CurrentUserId);
                }
                catch (Exception e)
                {
                    mon.LajkiM = new Lajki();
                    mon.LajkiM.MonumentsId = mon.Id;
                    mon.LajkiM.Monuments = mon;
                    mon.LajkiM.UserId = CurrentUserId;
                    mon.LajkiM.Liked = false;
                    _dbContext.Lajkis.Add(mon.LajkiM);
                    _dbContext.Update(mon);
                    await _dbContext.SaveChangesAsync();
                }
               
            }
          
     
             if (mon.LajkiM.Liked == true)
            {
                mon.LajkiM.Liked = false;               
            }
            else
            {
                mon.LajkiM.Liked = true;
               
            }
        //    _dbContext.Update(mon);
            await _dbContext.SaveChangesAsync();
            mon.NrLike =_dbContext.Lajkis.Where(m=>m.MonumentsId==mon.Id).Where(m=>m.Liked==true).Count();
         
            _dbContext.Update(mon);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Monumentet), new { id = mon.Id });
        }

        public async Task<IActionResult> LikedTSOn(int Id)
        {
            var turS = _dbContext.touristspot.First(x => x.Id == Id);
            if (turS.LajkiTS == null)
            {
                try
                {

                    turS.LajkiTS = _dbContext.LajkiTurSs.First(m => m.touristspotsId == turS.Id && m.UserId == CurrentUserId);
                }
                catch (Exception e)
                {
                    turS.LajkiTS = new LajkiTurS();
                    turS.LajkiTS.touristspotsId = turS.Id;
                    turS.LajkiTS.touristspots = turS;
                    turS.LajkiTS.UserId = CurrentUserId;
                    turS.LajkiTS.Liked = false;
                    _dbContext.LajkiTurSs.Add(turS.LajkiTS);
                    _dbContext.Update(turS);
                    await _dbContext.SaveChangesAsync();
                }
            }


            if (turS.LajkiTS.Liked == true)
            {
                turS.LajkiTS.Liked = false;
            }
            else
            {
                turS.LajkiTS.Liked = true;

            }
            //    _dbContext.Update(mon);
            await _dbContext.SaveChangesAsync();
            turS.NrLike = _dbContext.LajkiTurSs.Where(m => m.touristspotsId == turS.Id).Where(m => m.Liked == true).Count();

            _dbContext.Update(turS);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(TouristSpotet), new { id = turS.Id });
        }
        public async Task<IActionResult> AllMonument(int? page)
        {
            var monuments = _dbContext.Monument
                                    .AsNoTracking();

            int pageSize = 3;

            var vm = new IndexViewModel
            {
                Monumentet = await PaginatedList<Monument_Scann.Areas.Admin.Models.Monument>.CreateAsync(monuments, page ?? 1, pageSize)
            };

            return View(vm);
        }

        public async Task<IActionResult> Alltouristspot()
        {
          

            return View(await _dbContext.touristspot.ToListAsync());
        }


        public async Task<IActionResult> Monumentet(int? id)
        {
            try
            {
                ViewBag.KaBaLike = _dbContext.Lajkis.First(l => l.MonumentsId == id && l.UserId == CurrentUserId).Liked;
            }
            catch (Exception e) {
                ViewBag.KaBaLike = false;
            }
            
            if (id == null)
            {
                return NotFound();
            }
           
            var monument = await _dbContext.Monument
                .FirstOrDefaultAsync(m => m.Id == id);

            var vm = new ComentAdnMonument
            {
                Monumente = monument,
              
                MonumentComments = _dbContext.MonumentComments.Where(x => x.MonumentId == monument.Id).ToList(),
        
                MonumentId = monument.Id
            };


            if (monument == null)
            {
                return NotFound();
            }

            return View(vm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComent([Bind("Id,UserName,Comented,kohadergimit,MonumentId,Monumenti")]MonumentComments commented)
        {
            if (ModelState.IsValid)
            {
                commented.kohadergimit = DateTime.Now;
                commented.UserName = User.Identity.Name;
                commented.Monumenti = _dbContext.Monument.FirstOrDefault(m => m.Id == commented.MonumentId);
                _dbContext.Update(commented);

                await _dbContext.SaveChangesAsync();
                // return RedirectToAction(nameof(Monumentet));
                return RedirectToAction(nameof(Monumentet), new{id=commented.MonumentId});
            }
            return View(commented);
        }

        public async Task<IActionResult> TouristSpotet(int? id)
        {
            try
            {
                ViewBag.KaBaLike = _dbContext.LajkiTurSs.First(l => l.touristspotsId == id && l.UserId == CurrentUserId).Liked;
            }
            catch (Exception e)
            {
                ViewBag.KaBaLike = false;
            }
            if (id == null)
            {
                return NotFound();
            }

            var touristspot = await _dbContext.touristspot
                .FirstOrDefaultAsync(m => m.Id == id);

            var vm = new ComentAndTouristSpots
            {
                TouristSpot = touristspot,
                TouristSpotComment = null,
                TouristSpotComments = _dbContext.TouristSpotComents.Where(x => x.touristspotId == touristspot.Id).ToList(),
                Comented = null,
                touristspotId = touristspot.Id
            };
            if (touristspot == null)
            {
                return NotFound();
            }

            return View(vm);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComent2([Bind("Id,UserName,Comented,kohadergimit,touristspotId,Touristspoti")]TouristSpotComents commented)
        {
            if (ModelState.IsValid)
            {
                commented.kohadergimit = DateTime.Now;
                commented.UserName = User.Identity.Name;
                commented.Touristspoti = _dbContext.touristspot.FirstOrDefault(m => m.Id == commented.touristspotId);
                _dbContext.Update(commented);

                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(TouristSpotet), new { id = commented.touristspotId });
            }
            return View(commented);
        }


        public IActionResult Index()
        {
            var vm = new IndexViewModel {
                
             Monumente = _dbContext.Monument.OrderByDescending(x => x.Id).Take(3).ToList(),
             ToursitSpot = _dbContext.touristspot.OrderByDescending(x => x.Id).Take(3).ToList()
        };
            return View(vm);
        }
        public IActionResult Search(string Citys)
        {
            var mono = _dbContext.Monument.Where(x => x.Citys.ToString() == Citys).ToList();
            var tono = _dbContext.touristspot.Where(x => x.Citys.ToString() == Citys).ToList();
            var vm = new IndexViewModel
            {
                Monumente = mono,
                ToursitSpot = tono
            };

            return View(vm);
        }






        public async Task<IActionResult> mapcitys(string qytet)
        {
            ViewData["Citys"] = qytet;
            var mono = _dbContext.Monument.Where(x => x.Citys.ToString() == qytet).ToList();
            var tono = _dbContext.touristspot.Where(x => x.Citys.ToString() == qytet).ToList();
            var vm = new IndexViewModel
            {
                Monumente=mono,
                ToursitSpot=tono
            };

            return View(vm);
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
