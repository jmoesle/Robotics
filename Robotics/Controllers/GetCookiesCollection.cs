using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Robotics.Models;

namespace Robotics.Controllers
{
    [ServiceFilter(typeof(HttpContextService))]
    public class GetCookiesCollection : Controller
    {
        private string _culture;
        public GetCookiesCollection()
        {
            _culture = Request.Cookies["culture"];
        }
    }

            
        
    
}
