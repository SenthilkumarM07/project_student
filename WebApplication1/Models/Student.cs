using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Student
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is Required")]
        [Range(18, 60, ErrorMessage = "Age must be between 18 and 60")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Department is Required")]
        [StringLength(100, ErrorMessage = "Department cannot exceed 100 characters")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; } // Alternatively, use Enum for Gender

        [Required(ErrorMessage = "Course is required")]
        [StringLength(50, ErrorMessage = "Course name cannot exceed 50 characters")]
        public string Course { get; set; }

        [Required(ErrorMessage = "PhoneNumber is Required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        //[RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[@$!%*?&#])[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
            //ErrorMessage = "Email must contain at least one uppercase letter, one lowercase letter, one number, one special character, and be in a valid email format.")]
        public string Email { get; set; }
    }
}
        

