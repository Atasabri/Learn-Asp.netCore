using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myApp.Security
{
    public class RequirmentHandler : AuthorizationHandler<Requirment>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, Requirment requirement)
        {
            int x = 1;
            if(x==1)
            {
                 context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
