using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlckBook.Models
{
    public class Library
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public byte[] Content { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        public DateTime UploadDate { get; set; }

        public virtual School School { get; set; }
        public virtual Stream Stream { get; set; }
        public virtual Class Class { get; set; }
        public virtual Teacher Teacher { get; set; } 
    }

    public class BufferedSingleFileUploadDbModel : PageModel
    {

        [BindProperty]
        public BufferedSingleFileUploadDb FileUpload { get; set; }
    }

    public class BufferedSingleFileUploadDb
    {
        [Required(ErrorMessage = "Briefly describe the document you want to upload")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }
    }
}
