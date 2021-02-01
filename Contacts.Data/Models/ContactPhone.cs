using System.ComponentModel.DataAnnotations;

namespace Contacts.Data
{
    public class ContactPhone
    {
        [Key]
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string Phone { get; set; }

        public virtual Contact Contact { get; set; }

    }
}
