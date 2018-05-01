﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterCons.Library.Models;

namespace WaterCons.Library.Interfaces
{
    public interface IUserDataService : IDataService, IDisposable
    {
        void AddUser(user objuser);
        user GetUser(int ID);
        user GetUserByUserName(string userName);
        user Login(string userName, string password);
        void UpdateLastLogin(user user);
        void UpdateUser(user objuser);
    }
}
