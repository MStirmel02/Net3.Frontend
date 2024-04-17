using Net3.Frontend.DataAccess.Interfaces;
using Net3.Frontend.DataObjects.Models;
using Newtonsoft.Json;
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

        private readonly string call = "https://localhost:44393/";
        RestClient _client = null;

        public MessageAccess(IRestClient restClient) 
        {
            _client = (RestClient) restClient;
        }

        public List<MessageModel> GetChannelMessages(string channelId)
        {
            RestRequest request = new RestRequest(call + channelId + "/messages");
            request.AddHeader("channelId", channelId);

            try
            {
                var response = _client.Get(request).Content;
                ResponseModel<List<MessageModel>> result = JsonConvert.DeserializeObject<ResponseModel<List<MessageModel>>>(response);
                if (result.Error != null)
                {
                    throw new Exception(result.Error.Message);
                }
                return result.Response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SendChannelMessage(MessageModel message)
        {
            RestRequest request = new RestRequest(call + "message");
            request.AddJsonBody(message);

            try
            {
                var response = _client.Post(request).Content;
                ResponseModel<bool> result = JsonConvert.DeserializeObject<ResponseModel<bool>>(response);
                if (result.Error != null)
                {
                    throw new Exception(result.Error.Message);
                }
                return result.Response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
