using ContactManagement.Data;
using ContactManagement.Data.Providers;
using ContactManagement.Models.Validators;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ContactManagement.UnitTests
{
    public class Tests
    {
        ContactProvider contactProvider;

        [SetUp]
        public void Setup()
        {
            contactProvider = new ContactProvider(new ContactDBEntities());
        }

        #region Seed Data

        private List<ContactDetail> GetTestContactDetails()
        {
            var testContactDetails = new List<ContactDetail>();

            testContactDetails.Add(new ContactDetail { Id = 1, ContactName = "Test1", JobTitle = "Jr. Software Developer", CompanyId = 1, Email = "test@gmail.com", Phone = "4031111111", Address = "TestAddress1" });
            testContactDetails.Add(new ContactDetail { Id = 2, ContactName = "Test2", JobTitle = "Sr. Software Developer", CompanyId = 2, Email = "test@gmail.com", Phone = "4031111111", Address = "TestAddress2" });
            testContactDetails.Add(new ContactDetail { Id = 3, ContactName = "Test3", JobTitle = "Software Developer", CompanyId = 3, Email = "test@gmail.com", Phone = "4031111111", Address = "TestAddress3" });
            testContactDetails.Add(new ContactDetail { Id = 4, ContactName = "Test4", JobTitle = "Team Lead", CompanyId = 4, Email = "test@gmail.com", Phone = "4031111111", Address = "TestAddress4" });
            testContactDetails.Add(new ContactDetail { Id = 5, ContactName = "Test5", JobTitle = "Development Manager", CompanyId = 5, Email = "test@gmail.com", Phone = "4031111111", Address = "TestAddress5" });

            return testContactDetails;
        }

        private List<Company> GetTestCompanies()
        {
            var testCompanies = new List<Company>();

            testCompanies.Add(new Company { CompanyId = 1, CompanyName = "Amazon" });
            testCompanies.Add(new Company { CompanyId = 2, CompanyName = "Google" });
            testCompanies.Add(new Company { CompanyId = 3, CompanyName = "Microsoft" });
            testCompanies.Add(new Company { CompanyId = 4, CompanyName = "HP" });
            testCompanies.Add(new Company { CompanyId = 5, CompanyName = "MNP" });

            return testCompanies;
        }

        #endregion

        [Test]
        public void IsContactSaved()
        {
            ContactDetail contactDetail = new ContactDetail();
            contactDetail.Id = 1;
            contactDetail.ContactName = "Nisarg";
            contactDetail.CompanyId = 1;
            contactDetail.JobTitle = "Development Team Lead";
            contactDetail.Address = "Nolanhill";
            contactDetail.Phone = "4035551111";
            contactDetail.Email = "test@gmail.com";
            contactDetail.Comments = "test";

            int result = contactProvider.SaveContact(contactDetail);

            Assert.True(result > 0, "Contact could not be saved");
        }

        public void ValidInputs()
        {
            var controller = new Controllers.ContactController();
            List<Tuple<string, string>> internalValidationErrors;

            ContactDetailsValidator validator = new ContactDetailsValidator(controller);
            
            ContactDetail contactDetail = new ContactDetail();
            contactDetail.Id = 1;
            contactDetail.ContactName = "Nisarg";
            contactDetail.CompanyId = 1;
            contactDetail.JobTitle = "Development Team Lead";
            contactDetail.Address = "Nolanhill";
            contactDetail.Phone = "4035551111";
            contactDetail.Email = "test@gmail.com";
            contactDetail.Comments = "test";

            validator.ValidateInputs(contactDetail, out internalValidationErrors);            

            Assert.True(internalValidationErrors.Count == 0, "Input fields validation failed.");
        }
    }

}