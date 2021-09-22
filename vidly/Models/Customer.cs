using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using vidly.Models.CustomValidations;

namespace vidly.Models
{
    public class Customer : BaseModel
    {
        public bool IsSubscribedToNewsLetter { get; set; }
        
        public MembershipType MembershipType { get; set; }  // called navigation property
        
        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }  // recognized by entityframework as foreign key
        
        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}