using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlckBook.Models
{
    public class Student
    {
        public Student()
        {
            TaskSubmissions = new List<TaskSubmission>();
        }
        [Key, ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        [Display(Name = "Student number")]
        public string StudNo { get; set; }

        [Display(Name = "Id number")]
        public string IdNo { get; set; }       

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime DoB { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EnrollmentDate { get; set; }

        public bool IsActive { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual School School { get; set; }
        public virtual StudentAddress StudentAddress { get; set; }
        public virtual StudentContact StudentContact { get; set; }       
        public virtual Class Class { get; set; }        
        public virtual ICollection<TaskSubmission> TaskSubmissions { get; set; }
    }
}
