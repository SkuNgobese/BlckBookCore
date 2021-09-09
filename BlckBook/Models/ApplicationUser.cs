using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlckBook.Models
{
    public class ApplicationUser : IdentityUser
    {
        public byte[] Avi { get; set; }

        [PersonalData]
        public string Title { get; set; }

        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string MiddleName { get; set; }

        [PersonalData]
        public string LastName { get; set; }

        public string FullName { get { return Title + " " + FirstName + " " + MiddleName + " " + LastName; } }

        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual SchoolAdmin SchoolAdmin { get; set; }
    }
}
