using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlckBook.Models
{
    public class SchoolAdmin
    {
        [Key, ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EnrollmentDate { get; set; }

        public bool IsActive { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual School School { get; set; }
    }
}
