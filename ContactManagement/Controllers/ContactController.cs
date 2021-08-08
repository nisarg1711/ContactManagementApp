using ContactManagement.Data;
using ContactManagement.Data.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

namespace ContactManagement.Controllers
{
    public class ContactController : Controller
    {
        ContactProvider contactProvider = new ContactProvider(new ContactDBEntities());
        CompanyProvider companyProvider = new CompanyProvider(new ContactDBEntities());

        // GET: ContactController
        public ActionResult Index()
        {
            return View(contactProvider.GetAllContactList());
        }

        // GET: ContactController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContactController/Create       
        public ActionResult Create()
        {
            ContactDetail contactDetailModel = new ContactDetail();

            TempData["CompanyList"] = contactDetailModel.Companies = new SelectList(companyProvider.GetCompanyList(), "CompanyId", "CompanyName");

            return View(contactDetailModel);
        }

        // POST: ContactController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactDetail contactModel)
        {
            if (string.IsNullOrEmpty(contactModel.ContactName))
            {
                ModelState.AddModelError("ContactName", "Contact Name is required");
            }

            if (string.IsNullOrEmpty(contactModel.JobTitle))
            {
                ModelState.AddModelError("JobTitle", "Job Title is required");
            }
                   
            if (!string.IsNullOrEmpty(contactModel.Email))
            {
                string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

                Regex re = new Regex(emailRegex);

                if (!re.IsMatch(contactModel.Email))
                {
                    ModelState.AddModelError("Email", "Email Address is not valid");
                }
            }
            else
            {
                ModelState.AddModelError("Email", "Email Address is required");
            }

            if (!string.IsNullOrEmpty(contactModel.Phone))
            {
                string emailRegex = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";

                Regex re = new Regex(emailRegex);

                if (!re.IsMatch(contactModel.Phone))
                {
                    ModelState.AddModelError("Phone", "Phone Number is not valid");
                }
            }
            else
            {
                ModelState.AddModelError("Phone", "Phone Number is required");
            }

            if (ModelState.IsValid)
            {
                contactProvider.SaveContact(contactModel);
                return RedirectToAction("Index");
            }
            TempData["CompanyList"] = new SelectList(companyProvider.GetCompanyList(), "CompanyId", "CompanyName");

            return View(contactModel);
        }

        // GET: ContactController/Edit/5
        public ActionResult Edit(int id)
        {
            ContactDetail contact = contactProvider.FindContact(id);
            TempData["CompanyList"] = new SelectList(companyProvider.GetCompanyList(), "CompanyId", "CompanyName");

            //if (zone == null)
            //{
            //    return HttpNotFound();
            //}

            return View(contact);
        }

        // POST: ContactController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ContactDetail contactDetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contactProvider.UpdateContactDetails(contactDetail);
                    //db.Entry(zone).State = EntityState.Modified;
                    //db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                
            }

            return View();
        }

        // GET: ContactController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContactController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
