using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class BaseModel
    {
        public int Id { get; set; }

        /*
         * strings need required annotation as they can be null,
         * other types are not nullable by default so they are required implicity
         * as long as they don't have ? operator ex: int?, byte? ...
         */
        [Required]  
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        [NotMapped]
        private bool DisableIdAutoMapping { get; set; }

        public BaseModel()
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