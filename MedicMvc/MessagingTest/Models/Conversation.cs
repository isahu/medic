using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MessagingTest.Models
{
    public class Conversation
    {
        [Key]
        public long ConversationId { get; set; }

        public DateTime StartTime { get; set; }

        public virtual List<ApplicationUser> Participants { get; set; }
    }

    public class Participant
    {
        [Key, Column(Order=1)]
        public long ConversationId { get; set; }

        [Key, Column(Order=2)]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public bool Active { get; set; }
    }
}