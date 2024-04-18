using Net3.Frontend.DataAccess.Classes;
using Net3.Frontend.DataAccess.Interfaces;
using Net3.Frontend.DataObjects.Models;
using Net3.Frontend.Logic.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net3.Frontend.Logic.Classes
{
    public class MessageManager : IMessageManager
    {
        IMessageAccess _access = null;
        public MessageManager()
        {
            _access = new MessageAccess(new RestClient());
        }
        public MessageManager(IMessageAccess access)
        {
            _access = access;
        }

        public List<MessageModel> GetChannelMessages(string channelId)
        {
            try
            {
                return _access.GetChannelMessages(channelId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SendChannelMessage(MessageModel message)
        {
            try
            {
                return _access.SendChannelMessage(message);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
