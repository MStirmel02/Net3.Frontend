using Microsoft.SqlServer.Server;
using Net3.Frontend.DataAccess.Interfaces;
using Net3.Frontend.DataObjects.Models;
using Net3.Services.Channel.Services.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net3.Frontend.DataAccess.Classes
{
    public class ChannelAccess : IChannelAccess
    {

        private readonly string call = "https://localhost:44341/";

        RestClient _client = null;
        public ChannelAccess(IRestClient restClient)
        {
            _client = (RestClient)restClient;
        }

        public bool CreateChannel(ChannelRequestModel requestModel)
        {
            RestRequest request = new RestRequest(call + "channels/create");
            request.AddJsonBody(requestModel);

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

        public bool DeleteChannel(ChannelModel requestModel)
        {
            RestRequest request = new RestRequest(call + "channels/delete");
            request.AddJsonBody(requestModel);

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

        public List<AdminChannelModel> GetAll()
        {
            RestRequest request = new RestRequest(call + "channels");

            try
            {
                var response = _client.Get(request).Content;
                ResponseModel<List<AdminChannelModel>> result = JsonConvert.DeserializeObject<ResponseModel<List<AdminChannelModel>>>(response);
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

        public List<ChannelModel> GetUserChannels(string userId)
        {
            RestRequest request = new RestRequest(call + "channels/" + userId);

            try
            {
                var response = _client.Get(request).Content;
                ResponseModel<List<ChannelModel>> result = JsonConvert.DeserializeObject<ResponseModel<List<ChannelModel>>>(response);
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

        public bool JoinChannel(ChannelRequestModel requestModel)
        {
            RestRequest request = new RestRequest(call + "channels/join");
            request.AddJsonBody(requestModel);

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

        public bool LeaveChannel(ChannelRequestModel requestModel)
        {
            RestRequest request = new RestRequest(call + "channels/leave");
            request.AddJsonBody(requestModel);

            try
            {
                var response = _client.Delete(request).Content;
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
