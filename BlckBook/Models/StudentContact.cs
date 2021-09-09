using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlckBook.Models
{
    public class StudentContact
    {
        [Key, ForeignKey("Student")]
        public string Id { get; set; }

        [StringLength(10, ErrorMessage = "{0} must be 10 digits long", MinimumLength = 10)]
        [Display(Name = "Contact number")]
        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; }

        [StringLength(10, ErrorMessage = "{0} must be 10 digits long", MinimumLength = 10)]
        [Display(Name = "Home tel.")]
        [DataType(DataType.PhoneNumber)]
        public string HomeTel { get; set; }

        public virtual Student Student { get; set; }
    }
}
