using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterCons.Library.Models;

namespace WaterCons.Library.Interfaces
{
    public interface IPackageDataService : IDataService, IDisposable
    {
        void AddPackage(package objPackage);
        package GetPackage(int ID);
        package GetPackageByName(string Name);
        void UpdatePackage(package objPackage);
    }
}
