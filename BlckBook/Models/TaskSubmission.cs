using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlckBook.Models
{
    public class TaskSubmission
    {
        [Key, ForeignKey("Task")]
        public Guid Id { get; set; }

        [Display(Name = "Script")]
        public byte[] Content { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        public DateTime SubmissionDate { get; set; }

        public virtual Task Task { get; set; }
        public virtual Student Student { get; set; }       
    }
}
