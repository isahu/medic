using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using MessagingTest.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MessagingTest.Hubs
{
    [Authorize]
    public class MessageHub : Hub<IMessageHubClient>
    {
        //private ApplicationDbContext db;

        public void RequestMessages(MessageRequest request)
        {
            var response = new MessageRequestResponse();
            string userName = Context.User.Identity.Name;


            SendResponse(response, userName);
        }

        public async void RequestUnreadCount()
        {
            var id = Context.User.Identity.GetUserId();

            var unread = await GetUnreadMessages(id);

            int count = unread.Length;

            Clients.Group(Context.User.Identity.Name).sendUnreadCount(count);
        }

        public async void RequestUnread()
        {
            await SendUnreadMessages(Context.User.Identity.Name);
        }

        public async void SendMessage(string message, long convId)
        {
            // Create New Message and add to DB
            using (var db = new ApplicationDbContext())
            {
                DateTime timestamp = DateTime.UtcNow;

                var sender = db.Users.Find(Context.User.Identity.GetUserId());
                if (sender != null)
                {
                    Conversation c = db.Conversations.Find(convId);

                    if (c == null)
                        return;

                    Message m = new Message();
                    m.Sender = sender;
                    m.Conversation = c;
                    m.Timestamp = timestamp;
                    m.Text = message;

                    db.Messages.Add(m);
                    await db.SaveChangesAsync();

                    await SendMessageToClients(m.ToStruct(), c.Participants.Select(u => u.UserName).ToArray());
                }
            }
        }

        public async void MessageRecieved(long messageId)
        {
            using (var db = new ApplicationDbContext())
            {
                //var userId = Context.User.Identity.GetUserId();
                //var recipient = db.Recipients.Find(messageId, userId);

                //if (recipient != null && !recipient.Recieved)
                //{
                //    recipient.Recieved = true;
                //    recipient.TimeRecieved = DateTime.UtcNow;

                //    db.Entry(recipient).State = EntityState.Modified;
                //    await db.SaveChangesAsync();
                //}
            }
        }

        public async void MessageRead(long messageId)
        {
            using (var db = new ApplicationDbContext())
            {
                //var userId = Context.User.Identity.GetUserId();
                //var recipient = db.Recipients.Find(messageId, userId);

                //if (recipient != null)
                //{
                //    recipient.Read = true;
                //    if (!recipient.Recieved)
                //    {
                //        recipient.Recieved = true;
                //        recipient.TimeRecieved = DateTime.UtcNow;
                //    }
                    
                //    db.Entry(recipient).State = EntityState.Modified;
                //    await db.SaveChangesAsync();
                //}
            }
        }

        public async void FetchContactRequests()
        {
            var id = Context.User.Identity.GetUserId();

            using (var db = new ApplicationDbContext())
            {
                var user = db.Users.Find(id);

                var query = from c in db.Contacts
                            where c.RecieverId == id && c.Status == ContactRequestStatus.Pending
                            select c;


            }
        }

        public async void ApproveContacts()
        {

        }

        #region Private Methods (to Client)

        private async void SendResponse(MessageRequestResponse response, string userName)
        {
            await Clients.Group(userName).sendRequestResponse(response);
        }

        private async Task SendMessageToClients(MessageBodyStruct message, params string[] recipients)
        {
            MessageBodyStruct[] msgArray = { message };
            await Clients.Groups(recipients).sendMessages(msgArray);
        }

        private async Task SendUnreadMessages(string name)
        {
            var messages = await GetUnreadMessages(name);
            await Clients.Group(name).sendMessages(messages);
        }

        private async Task SendContactRequests(string name, params ContactRequestStatus[] status)
        {

        }

        #endregion // Private Methods (to Client)

        #region Private Helpers

        private async Task<MessageBodyStruct[]> GetUnreadMessages(string name)
        {
            //using (var db = new ApplicationDbContext())
            //{
            //    string userId = await (from u in db.Users
            //                           where u.UserName == name
            //                           select u.Id).FirstAsync();

            //    var query = from r in db.Recipients
            //                where r.UserId == userId
            //                select r.Message.ToStruct();

            //    return query.ToArray();
            //}
            return null;
        }

        #endregion // Private Helpers

        #region Overrides

        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;
            string id = Context.User.Identity.GetUserId();

            Groups.Add(Context.ConnectionId, name);

            //var unread = GetUnreadMessages(id);

            return base.OnConnected();
        }

        #endregion // Overrides
    }
}