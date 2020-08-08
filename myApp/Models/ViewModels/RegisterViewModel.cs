using Microsoft.AspNetCore.Mvc;
using myApp.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myApp.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [EmailDomain("atasabri.com", ErrorMessage = "Domain Name Is Not Valid !!")]
        [Remote(action: "IsEmailUsed", controller:"Account")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Re-Enter Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password And Confirm Password Not Match !")]
        public string RePassword { get; set; }
    }
}
