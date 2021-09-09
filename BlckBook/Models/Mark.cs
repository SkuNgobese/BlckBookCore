using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlckBook.Models
{
    public class Mark
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Mark?")]
        public double TotalMark { get; set; }

        public virtual Portfolio Portfolio { get; set; }
        public virtual Student Student { get; set; }
    }
}
