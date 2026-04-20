using ContactManagement.API.DataAccess;
using ContactManagement.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _repo;

        public ContactsController(IContactRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _repo.GetByIdAsync(id);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactInfo contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _repo.AddAsync(contact);

            return CreatedAtAction(nameof(GetById), new { id = created.ContactId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ContactInfo contact)
        {
            var result = await _repo.UpdateAsync(id, contact);

            if (!result)
                return NotFound();

            return Ok("Updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repo.DeleteAsync(id);

            if (!result)
                return NotFound();

            return Ok("Deleted successfully");
        }
    }
}
