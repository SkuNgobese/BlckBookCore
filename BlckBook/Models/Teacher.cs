using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlckBook.Models
{
    public class Teacher
    {
        public Teacher()
        {
            Classes = new List<ClassTeacher>();
            Subjects = new List<Subject>();
            Libraries = new List<Library>();
            Tasks = new List<Task>();
        }
        [Key, ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Employment number")]
        public string EmploymentNo { get; set; }

        [Display(Name = "Id number")]
        public string IdNo { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime DoB { get; set; }              

        [DataType(DataType.DateTime)]
        public DateTime EnrollmentDate { get; set; }

        public bool IsActive { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual School School { get; set; }
        public virtual TeacherAddress TeacherAddress { get; set; }
        public virtual TeacherContact TeacherContact { get; set; }
        public virtual ICollection<ClassTeacher> Classes { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }       
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<Library> Libraries { get; set; }
    }
}
