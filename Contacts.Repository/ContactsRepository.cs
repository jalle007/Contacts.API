using Contacts.Data;
using Contacts.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Contacts.Repository
{
    public class ContactsRepository : IContactsRepository
    {  
        private readonly ContactsContext _context;
        public ContactsRepository(ContactsContext context)
        {
            _context = context;
        }


        // providing access to single and multiple contacts (with pagination)
        public PagedList<Contact> GetAll(int? page = 1, int? pageSize = 10)
        {
            var contacts = _context.Contacts.Include(c => c.Phones);
            var c = contacts.ToList();

            PagedList<Contact> pagedList = new PagedList<Contact>(contacts, page, pageSize);
            return pagedList;
        }


        public Contact GetById(int contactId)
        {
            var contact = _context.Contacts.SingleOrDefault(c=>c.ContactId==contactId);
            return contact;
        }

         
        public int Insert(Contact contact)
        {
            // contacts need to be unique by name and address
            var existing = _context.Contacts.Any(c => c.FullName == contact.FullName || c.Address == contact.Address);
            if (existing)
                return 0;

            _context.Add(contact);
            var result = _context.SaveChanges();
            return result;

            //Broadcast message via SignalR
        }
 

        public int Update(Contact contact)
        {
            var existing = _context.Contacts.SingleOrDefault(c => c.ContactId == contact.ContactId);
            if (existing != null)
            {
                existing = contact;
                var result =  _context.SaveChanges();
                return result;
            }
            else
            {
                return 0;
            }

        }


        public int Delete(int contactID)
        {
            var existing = _context.Contacts.SingleOrDefault(c => c.ContactId == contactID);
            if (existing != null)
            {
                _context.Remove(existing);
                var result = _context.SaveChanges();
                return result;
            }
            else
            {
                return 0;
            }

        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

    }
}
