using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlckBook.Models
{
    public class Subject
    {
        public Subject()
        {
            Portfolios = new List<Portfolio>();
        }
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual Class Class { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Portfolio> Portfolios { get; set; }
    }
}
