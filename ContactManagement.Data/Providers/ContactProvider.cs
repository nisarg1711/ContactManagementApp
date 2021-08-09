using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ContactManagement.Data.Providers
{
    public class ContactProvider : ProviderBase
    {
        public ContactProvider(ContactDBEntities contactEntities) : base(contactEntities)
        {

        }

        /// <summary>
        /// Save Contact details
        /// </summary>
        /// <param name="contactDetail"></param>
        /// <returns></returns>
        public int SaveContact(ContactDetail contactDetail)
        {
            ContactDetail existingContactDetail = FindContact(contactDetail?.Id);

            if (existingContactDetail == null)
            {
                contactEntities.ContactDetails.Add(contactDetail);
            }
         
            int rowsCommitted = contactEntities.SaveChanges();

            return rowsCommitted;
        }

        public ContactDetail UpdateContactDetails(ContactDetail contactDetail)
        {
            contactEntities.Entry(contactDetail).State = EntityState.Modified;
            contactEntities.SaveChanges();

            return contactDetail;
        }

        /// <summary>
        /// Find Contact By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ContactDetail FindContact(int? id)
        {
            return contactEntities.ContactDetails.Where(c => c.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Get All contact list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ContactDetail> GetAllContactList()
        {
            return contactEntities.ContactDetails.ToList();
        }
    }
}
