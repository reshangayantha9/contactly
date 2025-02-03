using crud.Data;
using crud.Models;
using crud.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactlyDbContext dbContext;

        public ContactsController(ContactlyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllContacts()
        {
            var contacts =dbContext.contacts.ToList();
            return Ok(contacts);
        }

        [HttpPost]
        public IActionResult AddContact(AddRequestDTO requestDTO)
        {
            var domainModelContact = new Contact
            {
                Id = Guid.NewGuid(),
                Name = requestDTO.Name,
                Phone = requestDTO.Phone,
                Email = requestDTO.Email,
                Favorite = requestDTO.Favorite,

            };
            dbContext.contacts.Add(domainModelContact);
            dbContext.SaveChanges();

            return Ok(domainModelContact);
        }
    }
}
