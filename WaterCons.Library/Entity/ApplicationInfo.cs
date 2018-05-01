using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WaterCons.Library.Common;
using WaterCons.Library.Models;

namespace WaterCons.Library.Entity
{
    public class ApplicationInfo: TransactionalInformation
    {
        public List<applicationmenu> MenuItems;

        public ApplicationInfo()
        {
            MenuItems = new List<applicationmenu>();
        }
    }
}
