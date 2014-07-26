using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MessagingTest.Models
{
    public class Recipient
    {
        [Key]
        [Column(Order=1)]
        public long MessageId { get; set; }

        public virtual Message Message { get; set; }

        [Key]
        [Column(Order=2)]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public bool Recieved { get; set; }

        [Required]
        public bool Read { get; set; }

        public DateTime TimeRecieved { get; set; }

    }
}