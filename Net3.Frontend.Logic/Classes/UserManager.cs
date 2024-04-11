using Net3.Frontend.DataAccess.Classes;
using Net3.Frontend.DataAccess.Interfaces;
using Net3.Frontend.Logic.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net3.Frontend.Logic.Classes
{
    public class UserManager : IUserManager
    {
        IUserAccess _access = null;
        public UserManager()
        {
            _access = new UserAccess(new RestClient());
        }
        public UserManager(IUserAccess access)
        {
            _access = access;
        }
    }
}
