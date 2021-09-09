using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlckBook.Models
{
    public class School
    {
        public School()
        {
            Students = new List<Student>();
            Teachers = new List<Teacher>();
            Streams = new List<Stream>();
            Libraries = new List<Library>();
            Events = new List<Event>();
        }
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Special characters or numbers are not allowed!")]
        [Display(Name = "School name")]
        public string Name { get; set; }   

        public virtual SchoolContact SchoolContact { get; set; }
        public virtual SchoolAddress SchoolAddress { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Library> Libraries { get; set; }
        public virtual ICollection<Stream> Streams { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
