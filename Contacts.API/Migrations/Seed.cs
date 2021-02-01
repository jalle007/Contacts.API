using Contacts.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contacts.API.Migrations
{
    public class Seed
    {
        public static void SeedData(ContactsContext context)
        {

            if (!context.Contacts.Any())
            {
                var contacts = new List<Contact>
                {
                    new Contact { FullName = "John Doe I", Address="Copacabana", DOB=new DateTime(1970,1,1) },
                    new Contact { FullName = "John Doe II", Address="Copacabana", DOB=new DateTime(1970,1,1) },
                    new Contact { FullName = "John Doe III", Address="Copacabana", DOB=new DateTime(1970,1,1) },
                };
                context.AddRange(contacts);
                context.SaveChanges();

                var contactPhones = new List<ContactPhone>
                {
                    new ContactPhone{ContactId = 1, Phone = "+385 11 22 33"},
                    new ContactPhone{ContactId = 1, Phone = "+385 11 22 44"},
                    new ContactPhone{ContactId = 2, Phone = "+385 11 11 11"},
                    new ContactPhone{ContactId = 3, Phone = ""}
                };
                context.AddRange(contactPhones);
                context.SaveChanges();
            }

        }
    }
}
