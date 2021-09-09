using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlckBook.Models
{
    public class Task
    {
        public Task()
        {
            TaskSubmissions = new List<TaskSubmission>();
        }
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please enter {0}")]
        [MaxLength(30, ErrorMessage = "Please keep task's title short, not more than {1} letters")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please describe the task")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Due date")]
        [Required(ErrorMessage = "Please enter {0}")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }

        [Display(Name = "Time")]
        [Required(ErrorMessage = "Please enter submission time")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DueTime { get; set; }

        [Display(Name = "Submition option")]
        [Required(ErrorMessage = "Please choose Submitting Option")]
        public string SubmitionOption { get; set; }

        [DataType(DataType.Date)]
        public DateTime PostDate { get; set; }

        public byte[] Content { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please select class here.")]
        public string ClassId { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual Class Class { get; set; }
        public virtual ICollection<TaskSubmission> TaskSubmissions { get; set; }        
    }
}
