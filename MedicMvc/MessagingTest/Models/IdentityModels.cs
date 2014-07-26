using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessagingTest.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        // New Properties

        [InverseProperty("Initiator")]
        public virtual ICollection<Contact> Contacts { get; set; }

        [InverseProperty("Initiator")]
        public virtual ICollection<Ignore> IgnoreList { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("MessageConnection", throwIfV1Schema: false)
        {

        }

        public DbSet<Message> Messages { get; set; }

        //public DbSet<Recipient> Recipients { get; set; }

        public DbSet<Conversation> Conversations { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Ignore> Ignores { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>()
                .HasRequired(c => c.Reciever)
                .WithMany()
                .HasForeignKey(c => c.RecieverId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ignore>()
                .HasRequired(c => c.Reciever)
                .WithMany()
                .HasForeignKey(c => c.RecieverId)
                .WillCascadeOnDelete(false);
        }
    }
}