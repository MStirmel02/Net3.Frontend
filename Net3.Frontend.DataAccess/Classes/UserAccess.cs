using Net3.Frontend.DataAccess.Interfaces;
using Net3.Frontend.DataObjects.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Net3.Services.User.UserServices.Models;

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

        public List<AdminUserModel> GetAll()
        {
            RestRequest request = new RestRequest(call + "getall");

            try
            {
                var response = _client.Get(request).Content;
                ResponseModel<List<AdminUserModel>> result = JsonConvert.DeserializeObject<ResponseModel<List<AdminUserModel>>>(response);
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


            request.AddBody(user);
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
