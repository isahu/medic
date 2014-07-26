using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingTest.Hubs
{
    public interface IMessageHubClient
    {
        void sendUnreadCount(int count);

        Task sendRequestResponse(MessageRequestResponse response);

        Task sendMessages(MessageBodyStruct[] msgArray);
    }
}
