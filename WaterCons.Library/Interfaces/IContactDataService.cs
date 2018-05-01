using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterCons.Library.Models;

namespace WaterCons.Library.Interfaces
{
    public interface IContactDataService : IDataService, IDisposable

    {
        void AddContact(contact contact);
        contact GetContact(int ID);
        void UpdateContact(contact contact);
    }
}
