using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlckBook.Models
{
    public class Portfolio
    {
        public Portfolio()
        {
            Marks = new List<Mark>();
        }
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please enter {0}")]
        [Display(Name = "Assessment description")]
        [RegularExpression(@"^[a-zA-Z0-9 ]*$", ErrorMessage = "You cannot use special characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "What is the {0} for this Assessment?")]
        [Display(Name = "Total mark")]
        [Range(1, 300)]
        public double TotalMark { get; set; }

        [Required(ErrorMessage = "What is {0} for this Assessment?")]
        [Display(Name = "CASS Contribution")]
        [Range(1, 25)]
        public double CassContribution { get; set; }

        public virtual Class Class { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
