using Net3.Frontend.DataObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net3.Frontend.DataAccess.Interfaces
{
    public interface IMessageAccess
    {
        List<MessageModel> GetChannelMessages(string channelId);
        bool SendChannelMessage(MessageModel message);

    }
}
