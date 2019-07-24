using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Monument_Scann.Data;
using Monument_Scann.Areas.Admin.Models.Users;

namespace Monument_Scann.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Admin")]
    public class UsersController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _db;
        public UsersController(ApplicationDbContext _context, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _db = _context;
        }

        public async Task<IActionResult> Index()
        {


            return View(_userManager.Users.ToList());
        }

        public IActionResult Filtro(string Email)
        {
            var allUsers = _userManager.Users.ToList(); // Lista e krejt perdoruesve, para filtrimit

            var users = new List<IdentityUser>(); // Krijo liste te re te zbrazet

            if (Email != null)
            {
                // Ka filter, vendos vetem perdoruesit e filtruar ne listen e re...

                foreach (var u in allUsers)
                {
                    if (u.Email.ToLower().Contains(Email.ToLower())) // Pop quiz: pse e therrasim ToLower() per te dyjat?
                    {
                        users.Add(u);
                    }
                }
            }
            else
            {
                // Ska filter, kthe te gjithe perdoruesit
                users = allUsers;
            }

            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserModel user)
        {
            if (ModelState.IsValid)
            {
                if (_userManager.FindByNameAsync(user.Email).Result == null)
                {
                    var u = new IdentityUser();
                    u.UserName = user.UserName;
                    u.Email = user.Email;

                    IdentityResult result = _userManager.CreateAsync(u, user.Password).Result;

                    if (result.Succeeded)
                    {

                      
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, item.Description);
                        }

                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Email already exists. Please try another one.");
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var vm = new EditUserModel
            {
                Id = user.Id,
                Email = user.Email
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserModel user)
        {
            if (ModelState.IsValid)
            {
                var originalUser = await _userManager.FindByIdAsync(user.Id);

                if (originalUser == null)
                {
                    return NotFound();
                }

                if (originalUser.Email != user.Email) // Have we changed the email?
                {
                    // Yes, check if unique...
                    if (_userManager.FindByNameAsync(user.Email).Result == null)
                    {
                        originalUser.Email = user.Email;
                        originalUser.UserName = user.UserName;

                        await _userManager.UpdateAsync(originalUser);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Email already exists. Please try another one.");

                        return View();
                    }
                }

                if (!string.IsNullOrEmpty(user.Password)) // Are we trying to set a new password?
                {
                    // Yes, update it

                    string code = await _userManager.GeneratePasswordResetTokenAsync(originalUser);
                    var result = await _userManager.ResetPasswordAsync(originalUser, code, user.Password);

                    if (!result.Succeeded)
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, item.Description);
                        }

                        return View();
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            

            var user = await _userManager.FindByIdAsync(id);

           
                var q = await _userManager.DeleteAsync(user);

                return RedirectToAction(nameof(Index));


        }


    }
}