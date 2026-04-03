using Web_Application.Models;


namespace Web_Application.Repos
{
    public class ContactService : IContactService<ContactInfo>
    {
        private static List<ContactInfo> contacts = new List<ContactInfo>()
        {
            new ContactInfo
            {
                ContactId = 1,
                FirstName = "Sravani",
                LastName = "K",
                CompanyName = "Cognizant ",
                EmailId = "sravani@gmail.com",
                MobileNo = 9467543231,
                Designation = "Software Engineer"
            },
            new ContactInfo
            {
                ContactId = 2,
                FirstName = "Sonu",
                LastName = "Chalak",
                CompanyName = "Infosys",
                EmailId = "sonuchalak@gmail.com",
                MobileNo = 9123456780,
                Designation = "Trainee Analyst"
            },
            new ContactInfo
            {
                ContactId = 3,
                FirstName = "Arjun",
                LastName = "V",
                CompanyName = "Wipro",
                EmailId = "arjunv@gmail.com",
                MobileNo = 9012345678,
                Designation = "Developer"
            },
            new ContactInfo
            {
                ContactId = 4,
                FirstName = "Priya",
                LastName = "S",
                CompanyName = "HCL",
                EmailId = "priya@gmail.com",
                MobileNo = 9988776655,
                Designation = "Tester"
            },
            new ContactInfo
            {
                ContactId = 5,
                FirstName = "Teja",
                LastName = "k",
                CompanyName = "Capgemini",
                EmailId = "tejak@gmail.com",
                MobileNo = 9090909090,
                Designation = "Team Lead"
            }
        };

        public void AddContact(ContactInfo contact)
        {
            contacts.Add(contact);
        }

        public List<ContactInfo> GetAllContacts()
        {
            return contacts;
        }

        public ContactInfo GetContactById(int id)
        {
            return contacts.FirstOrDefault(c => c.ContactId == id);
        }
    }
}