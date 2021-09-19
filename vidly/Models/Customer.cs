﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class Customer : BaseModel
    {
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }  // called navigation property
        public byte MembershipTypeId { get; set; }  // recognized by entityframework as foreign key
        
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? Birthdate { get; set; }
    }
}