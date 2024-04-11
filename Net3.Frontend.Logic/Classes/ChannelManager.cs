using Net3.Frontend.DataAccess.Classes;
using Net3.Frontend.DataAccess.Interfaces;
using Net3.Frontend.Logic.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net3.Frontend.Logic.Classes
{
    public class ChannelManager : IChannelManager
    {
        IChannelAccess _access = null;
        public ChannelManager() 
        {
            _access = new ChannelAccess(new RestClient());
        }
        public ChannelManager(IChannelAccess access) 
        {
            _access = access;
        }
    }
}
