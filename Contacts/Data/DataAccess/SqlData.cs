using Contacts.Models.DB;
using Contacts.Data;

namespace Contacts.Data.DataAccess
{
    public class SqlData : IContactsData
    {
        private readonly ApplicationDbContext _context;
        public SqlData(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool ContactExists(int id)
        {
            return (_context.Contacts?.Any(e => e.ContactId == id)).GetValueOrDefault();
        }

        public Contact CreateContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return contact;
        }

        public Contact DeleteContact(Contact contact)
        {
            _context.Remove(contact);
            _context.SaveChanges();
            return contact;
        }

        public Contact EditContact(Contact contact)
        {
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return contact;
        }

        public Contact? GetContact(int id)
        {
            var contact = _context.Contacts.FirstOrDefault(x => x.ContactId == id);
            return contact;
        }

        public IEnumerable<Contact> ListContacts(string searchString)
        {
            var contacts = _context.Contacts
                 .Where(x => string.IsNullOrEmpty(searchString)
                 || x.Firstname.Contains(searchString) || x.Lastname.Contains(searchString)
                 || x.Post.Contains(searchString) || x.WorkPlace.Contains(searchString)
                 || x.PersonnelId.Contains(searchString)
                 )
                 .OrderBy(x => x.PersonnelId);
            
            return contacts;
        }

    }
}
