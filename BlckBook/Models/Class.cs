using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlckBook.Models
{
    public class Class
    {
        public Class()
        {
            Subjects = new List<Subject>();
            Portfolios = new List<Portfolio>();
            Libraries = new List<Library>();
            Teachers = new List<ClassTeacher>();
            Students = new List<Student>();
            Tasks = new List<Task>();
        }
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "Please enter {0}")]
        [Display(Name = "Grade")]
        public int Grade { get; set; }

        [Required(ErrorMessage = "Please enter {0}")]
        [StringLength(1, ErrorMessage = "{0} can be A,B,C,D,E,F,G or H etc...", MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Z]* {0,1}[a-zA-Z]*$", ErrorMessage = "Special characters or numbers are not allowed!")]
        [Display(Name = "Class group")]
        public string Group { get; set; }

        public virtual Stream Stream { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Portfolio> Portfolios { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }       
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<ClassTeacher> Teachers { get; set; }
        public virtual ICollection<Library> Libraries { get; set; }
    }
}
