﻿using Net3.Frontend.DataObjects.Models;
using Net3.Services.User.UserServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net3.Frontend.Logic.Interfaces
{
    public interface IUserManager
    {
        bool UserSignup(UserModel user);
        bool UserLogin(UserModel user);
        List<AdminUserModel> GetAll();
    }
}
