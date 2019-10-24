using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace SocialNet.Models
{
    public class AppUser : IdentityUser<int>
    {
        public AppUser()
        {
            Messages = new HashSet<Message>();
            Name = "-";
            Surname = "-";
            BirthDate = new DateTime(1, 1, 1);
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool HasPicture { get; set; }

        public virtual ICollection<Message> Messages {get; set;}

        public bool HasData() => (Name != "-") && (Surname != "-") && (BirthDate != new DateTime(1, 1, 1));

    }
}
