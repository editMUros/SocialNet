using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNet.Data;
using SocialNet.Models;
using SocialNet.Models.Form;
using System;
using System.Threading.Tasks;

namespace SocialNet.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(IHostingEnvironment env, ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            Context = context;
            UserManager = userManager;
            Env = env;
        }

        protected ApplicationDbContext Context { get; private set; }
        protected UserManager<AppUser> UserManager { get; private set; }
        protected IHostingEnvironment Env { get; private set; }

        protected async Task<UserSettings> GetSettings()
        {
            var user = await UserManager.FindByEmailAsync(User.Identity.Name);
            UserSettings settings = new UserSettings
            {
                Name = user.Name,
                Birthdate = user.BirthDate.HasValue ? user.BirthDate.Value : DateTime.MinValue,
                Surname = user.Surname,
                ImageUrl = $"/images/{User.Identity.Name}.png",
                HasPicture = System.IO.File.Exists(GetImageUrl())
            };
            return settings;
        }

        protected string GetImageUrl() => Env.ContentRootPath + "\\wwwroot\\images\\" + User.Identity.Name + ".png";
    }
}