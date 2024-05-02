using Net3.Frontend.DataObjects.Models;
using Net3.Services.Channel.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net3.Frontend.DataAccess.Interfaces
{
    public interface IChannelAccess
    {
        bool CreateChannel(ChannelRequestModel requestModel);
        bool JoinChannel(ChannelRequestModel requestModel);
        bool LeaveChannel(ChannelRequestModel requestModel);
        bool DeleteChannel(ChannelModel requestModel);
        List<ChannelModel> GetUserChannels(string userId);
        List<AdminChannelModel> GetAll();

    }
}
