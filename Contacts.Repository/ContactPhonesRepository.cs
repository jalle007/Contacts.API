using Contacts.Data;
using Contacts.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Contacts.Repository
{
    public class ContactPhonesRepository : IContactPhonesRepository
    {  
        private readonly ContactsContext _context;
        public ContactPhonesRepository(ContactsContext context)
        {
            _context = context;
        }


        // get all phone numbers for contactId
        public IQueryable<ContactPhone> GetAll(int contactId)
        {
            return  _context.ContactPhones.Where(c=>c.ContactId == contactId);
        }


        public ContactPhone GetById(int contactPhoneId)
        {
            return  _context.ContactPhones.SingleOrDefault(c => c.Id == contactPhoneId);
        }

         
        public int Insert(ContactPhone contactPhone)
        {
            _context.Add(contactPhone);
            var result = _context.SaveChanges();
            return result;
        }
 

        public int Update(ContactPhone contactPhone)
        {
            var existing = _context.ContactPhones.SingleOrDefault(c => c.Id == contactPhone.Id);
            if (existing != null)
            {
                existing = contactPhone;
                var result =  _context.SaveChanges();
                return result;
            }
            else
            {
                return 0;
            }

        }


        public int Delete(int contactPhoneID)
        {
            var existing = _context.ContactPhones.SingleOrDefault(c => c.Id== contactPhoneID);
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
