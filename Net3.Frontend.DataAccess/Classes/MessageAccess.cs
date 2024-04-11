using Net3.Frontend.DataAccess.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Net3.Frontend.DataAccess.Classes
{
    public class MessageAccess : IMessageAccess
    {
        RestClient _client = null;

        public MessageAccess(IRestClient restClient) 
        {
            _client = (RestClient) restClient;
        }  



    }
}
