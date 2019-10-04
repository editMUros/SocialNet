using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNet.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime When { get; set; }

        public int SenderId { get; set; }

        public virtual AppUser Sender { get; set; }

    }
}
