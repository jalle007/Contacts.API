using Contacts.Data;
using Contacts.Data.Models;
using Contacts.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactPhonesController : ControllerBase
    {
        private readonly ContactsContext _context;
        private readonly ILogger<ContactPhonesController> _logger;
        private readonly IContactPhonesRepository _contactPhonesRepo;

        public ContactPhonesController(ILogger<ContactPhonesController> logger, ContactsContext context)
        {
            _logger = logger;
            _context = context;
            _contactPhonesRepo = new ContactPhonesRepository(_context);
        }


        // Get all phones for specific contactId
        [HttpGet] 
        public IQueryable<ContactPhone> GetPhones(int contactId)
        {
            return _contactPhonesRepo.GetAll(contactId);
        }

        [HttpPost("Create")]
        public IActionResult Create( ContactPhone contactPhone)
        {
            var result = _contactPhonesRepo.Insert(contactPhone);
            return result > 0 ? Ok() : BadRequest();
        }

        [HttpPut("Update")]
        public IActionResult Update(ContactPhone contactPhone)
        {
            
            var result = _contactPhonesRepo.Update(contactPhone);
            
            return result > 0 ? Ok() : BadRequest();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int contactPhoneID)
        {

            var result = _contactPhonesRepo.Delete(contactPhoneID);
            return result > 0 ? Ok() : BadRequest();
        }

    }
}
