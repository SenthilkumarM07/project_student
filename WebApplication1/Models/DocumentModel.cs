using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DocumentModel
    {

        [Key] // Primary key
        public int DocumentId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string FilePath { get; set; }

    }
}