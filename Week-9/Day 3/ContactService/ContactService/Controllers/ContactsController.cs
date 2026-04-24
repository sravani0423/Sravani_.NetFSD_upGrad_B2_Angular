using Microsoft.AspNetCore.Mvc;
using ContactService.Models;
using ContactService.Services;

namespace ContactService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _service.GetById(id);
            if (contact == null) return NotFound();
            return Ok(contact);
        }

        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            _service.Add(contact);
            return Ok(contact);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Contact contact)
        {
            _service.Update(id, contact);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}