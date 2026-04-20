using ContactManagement.API.Models;

namespace ContactManagement.API.DataAccess
{
    public class ContactRepository : IContactRepository
    {
        public static List<ContactInfo> contacts = new List<ContactInfo>();
        private static int _nextId = 1;

        public async Task<List<ContactInfo>> GetAllAsync()
        {
            return await Task.FromResult(contacts);
        }

        public async Task<ContactInfo?> GetByIdAsync(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            return await Task.FromResult(contact);
        }

        public async Task<ContactInfo> AddAsync(ContactInfo contact)
        {
            contact.ContactId = _nextId++;
            contacts.Add(contact);
            return await Task.FromResult(contact);
        }

        public async Task<bool> UpdateAsync(int id, ContactInfo updatedContact)
        {
            var existing = contacts.FirstOrDefault(c => c.ContactId == id);

            if (existing == null)
                return false;

            existing.FirstName = updatedContact.FirstName;
            existing.LastName = updatedContact.LastName;
            existing.EmailId = updatedContact.EmailId;
            existing.MobileNo = updatedContact.MobileNo;
            existing.Designation = updatedContact.Designation;
            existing.CompanyId = updatedContact.CompanyId;
            existing.DepartmentId = updatedContact.DepartmentId;

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);

            if (contact == null)
                return false;

            contacts.Remove(contact);
            return await Task.FromResult(true);
        }
    }
}
