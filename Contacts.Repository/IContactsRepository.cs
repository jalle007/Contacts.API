using Contacts.Data;
using Contacts.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Repository
{
    public interface IContactsRepository : IDisposable
    {
        PagedList<Contact> GetAll(int? page = 1, int? pageSize = 10);
        Contact GetById(int contactId);
        int Insert(Contact contact);
        int Delete(int contactID);
        int Update(Contact contact);

    }
}
