using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlckBook.Models
{
    public class ClassTeacher
    {
        public string ClassId { get; set; }
        public virtual Class Class { get; set; }
        public string TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
