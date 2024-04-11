using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net3.Frontend.DataObjects.Models
{
    public class ChannelRequestModel
    {
        public string UserId { get; set; }

        public ChannelModel Channel { get; set; }
    }
}
