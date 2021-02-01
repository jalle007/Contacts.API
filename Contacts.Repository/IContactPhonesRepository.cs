using Contacts.Data;
using Contacts.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Repository
{
    public interface IContactPhonesRepository : IDisposable
    {
        IQueryable<ContactPhone> GetAll(int contactId);
        int Insert(ContactPhone contactPhone);
        int Update(ContactPhone contactPhone);
        int Delete(int contactPhoneID);

    }
}
