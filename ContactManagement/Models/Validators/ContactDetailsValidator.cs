using ContactManagement.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ContactManagement.Models.Validators
{
    /// <summary>
    /// Validator Class - To validate input fields
    /// </summary>
    public class ContactDetailsValidator
    {
        public Controller Controller { get; set; }

        public ContactDetailsValidator(Controller controller)
        {
            Controller = controller;
        }

        /// <summary>
        /// Validates Phone Number
        /// </summary>
        /// <param name="data">The data.</param>
        public void ValidateInputs(ContactDetail contactModel, out List<Tuple<string, string>> internalValidationErrors)
        {
            internalValidationErrors = new List<Tuple<string, string>>();
            Tuple<string, string> tuple;

            if (string.IsNullOrWhiteSpace(contactModel.Phone))
            {
                //Controller.ModelState.AddModelError("Phone", "Phone Number is required");
                tuple = new Tuple<string, string>("Phone", "Phone Number is required");
                internalValidationErrors.Add(tuple);
            }
            else
            {
                string phoneRegex = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";

                Regex re = new Regex(phoneRegex);

                if (!re.IsMatch(contactModel.Phone))
                {
                    //Controller.ModelState.AddModelError("Phone", "Phone Number is not valid");
                    tuple = new Tuple<string, string>("Phone", "Phone Number is required");
                    internalValidationErrors.Add(tuple);
                }
            }

            if (string.IsNullOrWhiteSpace(contactModel.Email))
            {
                //Controller.ModelState.AddModelError("Email", "Email Address is required");
                tuple = new Tuple<string, string>("Email", "Email Address is required");
                internalValidationErrors.Add(tuple);
            }
            else
            {
                string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                        @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

                Regex re = new Regex(emailRegex);

                if (!re.IsMatch(contactModel.Email))
                {
                    //Controller.ModelState.AddModelError("Email", "Email Address is not valid");
                    tuple = new Tuple<string, string>("Email", "Email Address is required");
                    internalValidationErrors.Add(tuple);
                }
            }
        }
    }
}
