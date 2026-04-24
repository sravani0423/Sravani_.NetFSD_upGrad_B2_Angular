using ContactService.Models;
using ContactService.Repositories;

namespace ContactService.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repo;

        public ContactService(IContactRepository repo)
        {
            _repo = repo;
        }

        public List<Contact> GetAll() => _repo.GetAll();

        public Contact GetById(int id) => _repo.GetById(id);

        public void Add(Contact contact)
        {
            _repo.Add(contact);
            _repo.Save();
        }

        public void Update(int id, Contact contact)
        {
            var existing = _repo.GetById(id);
            if (existing == null) return;

            existing.Name = contact.Name;
            existing.Email = contact.Email;
            existing.Phone = contact.Phone;
            existing.CategoryId = contact.CategoryId;

            _repo.Update(existing);
            _repo.Save();
        }

        public void Delete(int id)
        {
            var contact = _repo.GetById(id);
            if (contact == null) return;

            _repo.Delete(contact);
            _repo.Save();
        }
    }
}