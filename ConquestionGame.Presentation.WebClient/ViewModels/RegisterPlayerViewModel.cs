using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConquestionGame.Presentation.WebClient.ViewModels
{
    public class RegisterPlayerViewModel
    {
        [StringLength(20, ErrorMessage = "Name must be between 1 and 20 characters", MinimumLength = 1)]
        [Required]
        [Display(Name = "User Name")]
        public string Username { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Enter a valid email. e.g. username@email.com")]
        [Required]
        public string Email { get; set; }
        [RegularExpression("(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9~!@#$%^&*])[a-zA-Z0-9~!@#$%^&*]+", ErrorMessage = "Password should contain at least one upper and lower case character and one number or special character.")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}