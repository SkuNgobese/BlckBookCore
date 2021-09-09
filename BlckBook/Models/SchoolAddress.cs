using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlckBook.Models
{
    public class SchoolAddress
    {
        [Key, ForeignKey("School")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please select {0}")]
        [Display(Name = "Province")]
        public string Province { get; set; }

        [Required(ErrorMessage = "Please enter {0}")]
        [RegularExpression(@"^[a-zA-Z0-9 ]*$", ErrorMessage = "Street address cannot contain special characters")]
        [Display(Name = "Street", Prompt = "399 Jorissen Str")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Please enter {0}")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "{0} cannot contain numbers or special characters")]
        [Display(Name = "Suburb", Prompt = "Faerie Glen")]
        public string Suburb { get; set; }

        [Required(ErrorMessage = "Please enter {0}")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "{0} cannot contain numbers or special characters")]
        [Display(Name = "City", Prompt = "Pretoria")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter Postal Code")]
        [StringLength(4, ErrorMessage = "Postal Code is 4 digits long", MinimumLength = 4)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "{0} cannot contain letter or special characters")]
        [Display(Name = "Code", Prompt = "0002")]
        public string Code { get; set; }

        public virtual School School { get; set; }
    }
}
