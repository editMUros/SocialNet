using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNet.Data;
using SocialNet.Models;

namespace SocialNet.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        public readonly ApplicationDbContext _context;
        UserManager<AppUser> _userManager;
        
        public AdministrationController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DeleteAsync(string email)
        {
            await _userManager.DeleteAsync(_userManager.Users.ToList().Find(a => a.Email == email));
            return View("~/Views/Home/Administration.cshtml", _userManager.Users.ToList());
        }
    }
}