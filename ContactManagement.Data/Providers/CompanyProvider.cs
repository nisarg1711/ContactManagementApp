using System.Collections.Generic;
using System.Linq;

namespace ContactManagement.Data.Providers
{
    public class CompanyProvider : ProviderBase
    {
        public CompanyProvider(ContactDBEntities contactEntities) : base(contactEntities)
        {

        }

        /// <summary>
        /// Get All contact list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Company> GetCompanyList()
        {
            return contactEntities.Companies.ToList();
        }
    }
}
