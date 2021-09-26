using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using vidly.Models;
using vidly.Models.CustomValidations;

namespace vidly.DTOs
{
    public class CustomerDto : BaseModelDto
    {

        public bool IsSubscribedToNewsLetter { get; set; }

        /*
         * There should not be any dependency between our DTOs and our Models (complete decoupling)
         * If needed create and use MembershipTypeDto instead
         */
        //public MembershipType MembershipType { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        public int MembershipTypeId { get; set; }

        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}