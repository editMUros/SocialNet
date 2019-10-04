using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNet.Data;
using SocialNet.Models;

namespace SocialNet.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public HomeController(IHostingEnvironment env, ApplicationDbContext context, UserManager<AppUser> userManager) : base(env, context, userManager) { }

        public async Task<IActionResult> Index()
        {
            AppUser currentUser = await UserManager.GetUserAsync(User);

            if (User.IsInRole("Admin"))
                return View("Administration", UserManager.Users.ToList());
            else if (currentUser.HasData())
                return View("Messaging", Context.Messages.Include(x => x.Sender).ToList());
            else return View("~/Views/Settings/Settings.cshtml", await GetSettings());
        }

        public async Task<IActionResult> Create(Message message)
        {
            if (ModelState.IsValid)
            {
                var sender = await UserManager.GetUserAsync(User);
                message.SenderId = sender.Id;
                await Context.Messages.AddAsync(message);
                await Context.SaveChangesAsync();
                return Ok();
            }
            return Error();
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
