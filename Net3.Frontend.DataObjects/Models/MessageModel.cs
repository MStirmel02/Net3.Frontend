using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net3.Frontend.DataObjects.Models
{
    public class MessageModel
    {
        public string ChannelID { get; set; }
        public string UserID { get; set; }
        public string Content { get; set; }
        public DateTime TimeSent { get; set; }
    }
}
