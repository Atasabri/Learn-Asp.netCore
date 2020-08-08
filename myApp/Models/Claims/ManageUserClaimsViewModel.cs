using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace myApp.Models.Claims
{
    public class ManageUserClaimsViewModel
    {
        public string UserId { get; set; }
        public List<CustomClaim> Claims { get; set; }
    }


    public class CustomClaim
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public bool IsSelected { get; set; }
    }
}
