using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WaterCons.Library.Models;
using WaterCons.Library.Interfaces;

namespace WaterCons.Library.DataServices
{
    public class ContactDataService : EntityFrameworkDataService, IContactDataService
    {
        /// <summary>
        /// Create Contact
        /// </summary>
        public void AddContact(contact contact)
        {
            dbConnection.contacts.Add(contact);
        }

        public contact GetContact(int ID)
        {
            contact contact = dbConnection.contacts.SingleOrDefault(u => u.ID == ID);
            return contact;
        }

        public void UpdateContact(contact contact)
        {
            dbConnection.contacts.Add(contact);
        }
    }
}
