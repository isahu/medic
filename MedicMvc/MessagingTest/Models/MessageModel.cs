using System.Security.Claims;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using MessagingTest.Hubs;

namespace MessagingTest.Models
{
    public class Message
    {
        [Key]
        public long MessageId { get; set; }

        public string SenderId { get; set; }

        public long ConversationId { get; set; }

        public virtual ApplicationUser Sender { get; set; }

        public virtual Conversation Conversation { get; set; }

        public DateTime Timestamp { get; set; }

        public string Text { get; set; }

        public MessageBodyStruct ToStruct()
        {
            return new MessageBodyStruct() { Sender = this.Sender.UserName, Text = this.Text, Timestamp = this.Timestamp };
        }
    }
}