using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNet.Models.Form
{
    public class UserSettings
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public bool HasPicture { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }
    }
}
