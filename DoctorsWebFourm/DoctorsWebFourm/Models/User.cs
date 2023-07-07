using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DoctorsWebFourm.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Enter Your Full Name")]
        [MaxLength(50, ErrorMessage = "Maximum 50 Characters Allowed"), MinLength(3, ErrorMessage = "Minimum 3 Characters Required")]
        public string Fullname { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Enter Your Phone Number(eg.03XXXXXXXXX)")]
        [StringLength(11, ErrorMessage = "Please Enter Valid Phone Number")]
        public string ContactNumber { get; set; }
        [Required(ErrorMessage = "Enter Your Address")]
        [MaxLength(200, ErrorMessage = "Maximum 200 Characters Allowed"), MinLength(4, ErrorMessage = "Minimum 4 Characters Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter Your Country")]
        [MaxLength(20, ErrorMessage = "Maximum 20 Characters Allowed"), MinLength(4, ErrorMessage = "Minimum 4 Characters Required")]
        public string Country { get; set; }
        [Display(Name = "Specialization Field")]
        [Required(ErrorMessage = "Enter Your Specialization Feild")]
        [MaxLength(40, ErrorMessage = "Maximum 40 Characters Allowed")]
        public string Specialization { get; set; }
        [Display(Name = "Qualification")]
        [Required(ErrorMessage = "Enter Your Qualification")]
        [MaxLength(40, ErrorMessage = "Maximum 40 Characters Allowed")]
        public string Qualification { get; set; }
        [Display(Name = "Experience")]
        [Required(ErrorMessage = "Enter Your Experience")]
        [MaxLength(40, ErrorMessage = "Maximum 40 Characters Allowed")]
        public int Experience { get; set; }
        [Display(Name = "Your Achievement")]
        [Required(ErrorMessage = "Enter Your Achievement")]
        [MaxLength(40, ErrorMessage = "Maximum 40 Characters Allowed")]
        public string Achievements { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter Your Password")]
        [MaxLength(20, ErrorMessage = "Maximum 20 Characters Or Digits Allowed"), MinLength(4, ErrorMessage = "Minimum 5 Characters Or Digits Required")]

        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "ReEnter Your Password")]
        [MaxLength(20), DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password Not Matched")]
        public string CPassword { get; set; }
        [Required(ErrorMessage = "Enter Your Email")]
        [MaxLength(50, ErrorMessage = "Maximum 50 Characters Allowed")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter a Valid Email Address")]

        public string Email { get; set; }
        [AllowNull]
        public DateTime RegistrationDate { get; set; }
        [DefaultValue(false)]
        public bool IsAdmin { get; set; }

        public bool IsPrivateProfile { get; set; }
        public ICollection<Query> Queries { get; set; }
        [DefaultValue("abc.png"),AllowNull]
        public string Img { get; set; }
    }
}
