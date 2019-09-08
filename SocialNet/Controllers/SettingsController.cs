using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNet.Data;
using SocialNet.Models;


namespace SocialNet.Controllers
{
    public class SettingsController : Controller
    {
        public readonly ApplicationDbContext _context;
        private IHostingEnvironment _env;

        public SettingsController(IHostingEnvironment env,  ApplicationDbContext context)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Settings()
        {
            return View(_context);
        }

        public IActionResult AddChange(IFormFile file, String username)
        {
            if (file.Length != 0)
            {
                var dir = _env.ContentRootPath;
                string path = Path.Combine(dir, "wwwroot\\images\\" + User.Identity.Name + ".png");
                using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fileStream);
                }
                AppUser x = _context.Users.ToList().Find(el => el.UserName == User.Identity.Name);
                x.PicturePath = path;
                var pat = x.PicturePath;
                var nam = x.Name;
                AppUser y = _context.Users.ToList().Find(el => el.UserName == User.Identity.Name);
                var paty = y.PicturePath;
                _context.SaveChanges();
            }
            return RedirectToAction("Settings");
        }
    }
}