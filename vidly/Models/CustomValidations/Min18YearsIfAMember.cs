using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.Models.CustomValidations
{
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