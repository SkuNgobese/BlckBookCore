using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlckBook.Models
{
    public class SchoolContact
    {
        [Key, ForeignKey("School")]
        public Guid Id { get; set; }

        [StringLength(10, ErrorMessage = "Telephone number must be 10 digits long", MinimumLength = 10)]
        [Display(Name = "Telephone No.")]
        [DataType(DataType.PhoneNumber)]
        public string TelNo { get; set; }

        [StringLength(10, ErrorMessage = "Telephone number must be 10 digits long", MinimumLength = 10)]
        [Display(Name = "Fax No.")]
        [DataType(DataType.PhoneNumber)]
        public string FaxNo { get; set; }

        [EmailAddress]
        //[System.Web.Mvc.Remote("IsAlreadySigned", "Account", HttpMethod = "POST", ErrorMessage = "Email already exists in database")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        public virtual School School { get; set; }
    }
}
