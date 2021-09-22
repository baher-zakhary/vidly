using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.Models.CustomValidations
{
    /*
     * Client side validations and custom validators:
     * ----------------------------------------------
     * Custom validators don't work with client side validation
     * client side validation only works with standard .NET annotations
     * It is a good thing to do client side validation only for standard annotations
     * and let custom validations aka business logic be done on the server
     * so when the business changes it only needs to be changed on the server
     */
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            /*
             * AVOID MAGIC NUMBERS LIKE THIS
             * if (customer.MembershipTypeId == 1)
             */
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.Birthdate == null)
            {
                return new ValidationResult("Birthdate is required");
            }

            // nullable types have .Value
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            if (age < 18)
            {
                return new ValidationResult("Customer must be at least 18 years old to go on a membership.");
            }
            return ValidationResult.Success;
        }
    }
}