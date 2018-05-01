using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterCons.Library.Interfaces;
using WaterCons.Library.Models;

namespace WaterCons.Library.Interfaces
{
    public interface IApplicationDataService : IDataService, IDisposable
    {
        void InitializeApplication();
        List<applicationmenu> GetMenuItems(Boolean isAuthenicated);
    }
}
