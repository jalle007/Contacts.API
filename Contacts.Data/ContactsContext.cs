using Microsoft.EntityFrameworkCore;
using System;

namespace Contacts.Data
{
    public class ContactsContext: DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options)
        { }
        
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactPhone> ContactPhones { get; set; }

    }
}
