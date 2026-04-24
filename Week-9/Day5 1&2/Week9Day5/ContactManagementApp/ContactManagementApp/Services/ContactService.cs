using ContactManagementApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContactManagementApp.Services
{
    public class ContactService : IContactService
    {
        private List<Contact> contacts = new List<Contact>();

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public List<Contact> GetAllContacts()
        {
            return contacts;
        }

        public Contact GetContactById(int id)
        {
            return contacts.FirstOrDefault(c => c.Id == id);
        }

        public bool DeleteContact(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.Id == id);

            if (contact != null)
            {
                contacts.Remove(contact);
                return true;
            }

            return false;
        }
    }
}
