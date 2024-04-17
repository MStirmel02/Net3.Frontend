using Net3.Frontend.DataAccess.Interfaces;
using Net3.Frontend.DataObjects.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Net3.Frontend.DataAccess.Classes
{
    public class UserAccess : IUserAccess
    {

        private readonly string call = "https://localhost:44391/";

        RestClient _client = null;
        public UserAccess(IRestClient restClient) 
        {
            _client = (RestClient)restClient;
        }

        public bool UserLogin(UserModel user)
        {
            RestRequest request = new RestRequest(call + "login");
            request.AddHeader("userId", user.UserId);
            request.AddHeader("passwordHash", user.PasswordHash);

            try
            {
                var response = _client.Get(request).Content;
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

        public bool UserSignup(UserModel user)
        {
            RestRequest request = new RestRequest(call + "signup");
            request.AddJsonBody(user);

            try
            {
                var response = _client.Get(request).Content;
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
