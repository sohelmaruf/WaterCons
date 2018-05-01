using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterCons.Library.Interfaces;
using WaterCons.Library.Models;

namespace WaterCons.Library.Interfaces
{
    public interface IAdminDataService : IDataService, IDisposable
    {

        void RegisterUser(user user);
        user GetUserByUserName(string userName);
        user Login(string userName, string password);
        void UpdateLastLogin(user user);
        user GetUser(int userID);
        void UpdateUser(user user);
    }
}
