using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNet.Data;
using SocialNet.Models;

namespace SocialNet.Controllers
{
    public class ProfileController : BaseController
    {
        public ProfileController(IHostingEnvironment env, ApplicationDbContext context, UserManager<AppUser> userManager) : base(env, context, userManager) { }

        public IActionResult Profile(string accountName)
        {
            AppUser user = Context.Users.ToList().Find(el => accountName == el.Email);
            return View(user);
        }

        public IActionResult Search(string pattern)
        {
            var data = Context.Users.Where(u => u.Name.StartsWith(pattern) || u.Email.StartsWith(pattern)).ToList();
            return Json(data);
        }

    }
}