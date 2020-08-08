using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace myApp.Models.Claims
{
    public sealed class AllClaims
    {
        private AllClaims() { }
        private static AllClaims Instance = null;
        public static AllClaims GetInstance
        {
            get
            {
                if(Instance==null)
                {
                    Instance = new AllClaims();
                }
                return Instance;
            }
         }

        
        public List<Claim> Claims = new List<Claim>()
        {
            new Claim("CreateRole","CreateRole"),
            new Claim("EditRole","EditRole"),
            new Claim("DeleteRole","DeleteRole"),
            new Claim("User","User")
        };
    }
}
