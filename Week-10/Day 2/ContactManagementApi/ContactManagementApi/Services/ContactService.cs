using ContactManagementApi.Models;

namespace ContactManagementApi.Services
{
    public class ContactService : IContactService
    {
        private readonly List<Contact> contacts = new();

        public List<Contact> GetAll()
        {
            return contacts;
        }

        public Contact? GetById(int id)
        {
            return contacts.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Contact contact)
        {
            contacts.Add(contact);
        }

        public bool Update(int id, Contact contact)
        {
            var existing = contacts.FirstOrDefault(x => x.Id == id);

            if (existing == null)
                return false;

            existing.Name = contact.Name;
            existing.Email = contact.Email;
            existing.Phone = contact.Phone;

            return true;
        }

        public bool Delete(int id)
        {
            var contact = contacts.FirstOrDefault(x => x.Id == id);

            if (contact == null)
                return false;

            contacts.Remove(contact);
            return true;
        }
    }
}