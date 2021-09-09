using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlckBook.Models
{
    public class Stream
    {
        public Stream()
        {
            Libraries = new List<Library>();
            Classes = new List<Class>();
            Subjects = new List<Subject>();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Stream name")]
        public string Name { get; set; }

        public virtual School School { get; set; }       
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Library> Libraries { get; set; }
    }
}
