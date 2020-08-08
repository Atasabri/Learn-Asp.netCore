using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myApp.Models.ViewModels
{
    public class RoleViewModel
    {
        public string ID { get; set; }
        [Required]
        public string Name { get; set; }

        public List<UserRoleViewModel> Users { get; set; }
    }
}
