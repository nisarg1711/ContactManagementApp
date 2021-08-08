using ContactManagement.Data;
using ContactManagement.Data.Providers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContactManagement.Controllers
{
    public class CompanyController : Controller
    {
        CompanyProvider companyProvider = new CompanyProvider(new ContactDBEntities());

        [Route("Company/GetCompanyList")]
        [HttpGet]
        public List<Company> GetCompanyList()
        {
            return companyProvider.GetCompanyList();
        }
    }
}
