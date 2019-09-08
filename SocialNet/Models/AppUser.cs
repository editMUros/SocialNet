using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNet.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Messages = new HashSet<Message>();
        }

        public String Name { get; set; }
        public String Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PicturePath { get; set; }

        public virtual ICollection<Message> Messages {get; set;}

    }
}
