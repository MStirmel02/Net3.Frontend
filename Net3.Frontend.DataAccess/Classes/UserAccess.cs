using Net3.Frontend.DataAccess.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net3.Frontend.DataAccess.Classes
{
    public class UserAccess : IUserAccess
    {
        RestClient _client = null;
        public UserAccess(IRestClient restClient) 
        {
            _client = (RestClient)restClient;
        }


    }
}
