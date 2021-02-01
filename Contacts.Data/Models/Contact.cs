using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Data
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  ContactId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }

        public  ICollection<ContactPhone> Phones { get; set; }
    }
}
