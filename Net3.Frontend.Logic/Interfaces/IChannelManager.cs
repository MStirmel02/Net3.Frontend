using Net3.Frontend.DataObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net3.Frontend.Logic.Interfaces
{
    public interface IChannelManager
    {
        bool CreateChannel(ChannelRequestModel requestModel);
        bool JoinChannel(ChannelRequestModel requestModel);
        bool LeaveChannel(ChannelRequestModel requestModel);
        List<ChannelModel> GetUserChannels(string userId);
    }
}
