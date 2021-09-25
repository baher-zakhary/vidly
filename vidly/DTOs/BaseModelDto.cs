using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.DTOs
{
    public class BaseModelDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        private bool DisableIdAutoMapping { get; set; }

        public BaseModelDto()
        {
            EnableAutoMappingId();
        }

        public void DisableAutoMappingId()
        {
            DisableIdAutoMapping = true;
        }

        public void EnableAutoMappingId()
        {
            DisableIdAutoMapping = false;
        }

        public bool isIdAutoMappingDisabled()
        {
            return DisableIdAutoMapping == true;
        }
    }
}