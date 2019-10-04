using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNet.Data;
using SocialNet.Models;
using SocialNet.Models.Form;

namespace SocialNet.Controllers
{
    public class SettingsController : BaseController
    {

        public SettingsController(IHostingEnvironment env,  ApplicationDbContext context, UserManager<AppUser> userManager) : base(env, context, userManager) { }

        public async Task<IActionResult> Settings() => View("Settings", await GetSettings());

        public async Task<IActionResult> UpdateInfo(UserSettings model)
        {
            if (!ValidSubmitSettings(model))
                return View("Settings", await GetSettings());

            AppUser user = Context.Users.ToList().Find(el => el.UserName == User.Identity.Name);
            if (model.Image != null)
            {
                using (var fileStream = new FileStream(GetImageUrl(), FileMode.Create, FileAccess.Write))
                {
                    model.Image.CopyTo(fileStream);
                }
                user.HasPicture = true;
            }

            user.Name = model.Name;
            user.Surname = model.Surname;
            user.BirthDate = model.Birthdate;

            await Context.SaveChangesAsync();

            return View("Settings", await GetSettings());
        }

        public async Task<IActionResult> ChangePassword(UserSettings model)
        {
            UserSettings currentSettings = await GetSettings();
            AppUser user = Context.Users.ToList().Find(el => el.UserName == User.Identity.Name);
            var result = await UserManager.ChangePasswordAsync(user, model.OldPassword ?? "", model.NewPassword ?? "");

            if (!result.Succeeded)
            {
                ModelState.AddModelError("OldPassword", result.Errors.ToList()[0].Description);
                return View("Settings", currentSettings);
            }
            return View("Settings", currentSettings);
        }

        private bool ValidSubmitSettings(UserSettings model)
        {
            if (string.IsNullOrEmpty(model.Name?.Trim()) || string.IsNullOrEmpty(model.Name?.Trim()) || string.IsNullOrEmpty(model.Name?.Trim()))
            {
                ModelState.AddModelError("Name", "Please fill out everything!");
                return false;
            }
            return true;
        }


    }
}