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

        public bool CreateChannel(ChannelRequestModel requestModel)
        {
            try
            {
                return _access.CreateChannel(requestModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ChannelModel> GetUserChannels(string userId)
        {
            try
            {
                return _access.GetUserChannels(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool JoinChannel(ChannelRequestModel requestModel)
        {
            try
            {
                return _access.JoinChannel(requestModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool LeaveChannel(ChannelRequestModel requestModel)
        {
            try
            {
                return _access.LeaveChannel(requestModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
