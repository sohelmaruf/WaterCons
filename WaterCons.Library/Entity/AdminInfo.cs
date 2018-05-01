using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterCons.Library.Models;
using WaterCons.Library.Common;

namespace WaterCons.Library.Entity
{
    public class AdminInfo : TransactionalInformation
    {
        public List<applicationmenu> MenuItems;
        public user User;

        public AdminInfo()
        {
            User = new user();
            MenuItems = new List<applicationmenu>();
        }
    }
}
