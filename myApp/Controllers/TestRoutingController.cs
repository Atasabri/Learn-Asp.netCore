using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myApp.Controllers
{
    [Route("[controller]/[action]/{id?}")]
    public class TestRoutingController:Controller
    {

        [Route("")]
        [Route("~/TestRouting")]
        public string Test()
        {
            return "Ata Sabri";
        }
    }
}
