using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessagingTest.Models
{
    public enum ContactRequestStatus
    {
        Pending,
        Approved,
        Denied
    }

    /// <summary>
    /// Holds the Contact relationships between Users
    /// </summary>
    public class Contact
    {
        [Key, Column(Order = 1)]
        public string InitiatorId { get; set; }
        [Key, Column(Order = 2)]
        public string RecieverId { get; set; }

        /// <summary>
        /// Holds the status of the contact request (Pending, Approved, Denied)
        /// </summary>
        [Required]
        public ContactRequestStatus Status { get; set;}

        // Navigation Properties
        /// <summary>
        /// The User who initiated the contact request
        /// </summary>
        public virtual ApplicationUser Initiator { get; set; }


        public virtual ApplicationUser Reciever { get; set; }

        public ContactRequest ToStruct()
        {
            return new ContactRequest() { Sender = this.Initiator.UserName, RecieverName = this.Reciever.UserName, Status = this.Status };
        }

    }

    public class Ignore
    {
        [Key, Column(Order = 1)]
        public string InitiatorId { get; set; }
        [Key, Column(Order = 2)]
        public string RecieverId { get; set; }

        // Navigation Properties
        /// <summary>
        /// The User who initiated the ignore request
        /// </summary>
        public virtual ApplicationUser Initiator { get; set; }

        /// <summary>
        /// The user whom is ignored by the Initiator
        /// </summary>
        public virtual ApplicationUser Reciever { get; set; }
    }
}