using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.ViewModels.Requests.System.Users
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Please enter username")]
        [RegularExpression("^[0-9a-zA-Z]*$",
           ErrorMessage = "Username doesn't have space character")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email:", Prompt = "example@example.com")]
        [RegularExpression("^[a-z][a-z0-9_\\.]{5,32}@[a-z0-9]{2,}(\\.[a-z0-9]{2,4}){1,2}$", ErrorMessage = "Email is invalid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:", Prompt = "********")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$",
            ErrorMessage = "Passwords must be at least 6 characters, one digit, one uppercase, one non alphanumeric character")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter confirmation password")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmation Password:", Prompt = "********")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter PhoneNumber")]
        [RegularExpression("^0[0-9]{9}$",
            ErrorMessage = "Phone numbers have to start with 0 and have 10 numbers")]
        public string PhoneNumber { get; set; }
    }
}
