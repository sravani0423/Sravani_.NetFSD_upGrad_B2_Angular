using ContactService.Data;
using ContactService.Models;

namespace ContactService.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext _context;

        public ContactRepository(ContactDbContext context)
        {
            _context = context;
        }

        public List<Contact> GetAll() => _context.Contacts.ToList();

        public Contact GetById(int id) => _context.Contacts.Find(id);

        public void Add(Contact contact) => _context.Contacts.Add(contact);

        public void Update(Contact contact) => _context.Contacts.Update(contact);

        public void Delete(Contact contact) => _context.Contacts.Remove(contact);

        public void Save() => _context.SaveChanges();
    }
}