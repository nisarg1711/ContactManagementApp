using ContactManagement.Data;
using ContactManagement.Data.Providers;
using ContactManagement.ExtensionMethods;
using ContactManagement.Models.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
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
            ContactDetailsValidator contactDetailsValidator = new ContactDetailsValidator(this);

            List<Tuple<string, string>> validationErrors = new List<Tuple<string, string>>();

            ModelState.RequiredField(() => contactModel.ContactName);

            ModelState.RequiredField(() => contactModel.JobTitle);

            contactDetailsValidator.ValidateInputs(contactModel, out validationErrors);

            foreach (var error in validationErrors)
            {
                if (ModelState.ContainsKey(error.Item1))
                {
                    ModelState.Remove(error.Item1);
                }

                ModelState.AddModelError(error.Item1, error.Item2);
            }

            if (validationErrors.Count == 0)
            {
                ModelState.Clear();
            }

            if (ModelState.IsValid)
            {
                int result = contactProvider.SaveContact(contactModel);

                if (result > 0)
                {
                    ViewBag.Alert = "Contact details saved successfully";
                }
                else
                {
                    ViewBag.Alert = "Contact details could not be saved due to unknown error";
                }

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
