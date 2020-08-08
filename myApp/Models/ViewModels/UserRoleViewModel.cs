using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myApp.Models.ViewModels
{
    public class UserRoleViewModel
    {
        public string UserID { get; set; }
        public string Email { get; set; }
        public bool IsSelected { get; set; }
    }
}
