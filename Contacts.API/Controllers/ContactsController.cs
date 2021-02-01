using Contacts.Data;
using Contacts.Data.Models;
using Contacts.Repository;
using Contacts.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ContactsContext _context;
        private readonly ILogger<ContactsController> _logger;
        private readonly IContactsRepository _contactsRepo;
        private readonly IHubContext<BroadcastHub> _hub;

        public ContactsController(ILogger<ContactsController> logger, ContactsContext context, 
                                            IHubContext<BroadcastHub> hub)
        {
            _logger = logger;
            _context = context;
            _hub = hub;
            _contactsRepo = new ContactsRepository(_context);
        }


        /// <summary>
        ///  Get paged contacts  list
        /// </summary>
        /// <param page="1"></param>
        /// <param pageSize="10"></param>
        /// <returns>PagedList<Contact> </returns>
        [HttpGet] //("GetContacts")
        public PagedList<Contact> GetContacts(int? page = 1, int? pageSize = 10)
        {
            var response = _contactsRepo.GetAll(page, pageSize);
            return response;
        }

        [HttpGet("GetById")]
        public Contact GetById(int ContactId)
        {
            var response = _contactsRepo.GetById(ContactId);
            return response;
        }

        [HttpPost("Create")]
        public IActionResult Create(string FullName, string Address, DateTime DOB)
        {
            var contact = new Contact() { 
                FullName= FullName,
                Address=Address,
                DOB=DOB
            };

            var result = _contactsRepo.Insert(contact);
            if (result != 0)
            {
                // Bradcast message to SignalR clients
                Broadcast(_hub, $"Contact {contact.FullName} created.");
                return Ok();
            }
            else
                return BadRequest();
        }

        private async void Broadcast(IHubContext<BroadcastHub> hub, string message)
        {
            var broadcast = new BroadcastHub(hub);
            await broadcast.SendMessage(message);
        }


        [HttpPut("Update")]
        public IActionResult Update(Contact contact)
        {
            var result = _contactsRepo.Update(contact);
            return result > 0 ? Ok() : BadRequest();
        }


        [HttpDelete("Delete")]
        public IActionResult Delete(int contactID)
        {
            var result = _contactsRepo.Delete(contactID);
            return result > 0 ? Ok() : BadRequest();
        }

    }
}
