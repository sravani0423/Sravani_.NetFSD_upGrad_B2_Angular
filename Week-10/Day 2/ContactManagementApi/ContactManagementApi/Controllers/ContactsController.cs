using Microsoft.AspNetCore.Mvc;
using ContactManagementApi.Models;
using ContactManagementApi.Services;

namespace ContactManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService service;

        public ContactsController(IContactService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var contacts = service.GetAll();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = service.GetById(id);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            service.Add(contact);
            return CreatedAtAction(nameof(GetById),
                new { id = contact.Id }, contact);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Contact contact)
        {
            bool updated = service.Update(id, contact);

            if (!updated)
                return NotFound();

            return Ok("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool deleted = service.Delete(id);

            if (!deleted)
                return NotFound();

            return Ok("Deleted Successfully");
        }
    }
}