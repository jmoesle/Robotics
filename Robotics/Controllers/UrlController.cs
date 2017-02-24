using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Robotics.Models;
using Resources;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Robotics.Controllers
{
    [ServiceFilter(typeof(LanguageActionFilter))]
    //[Route("{culture}/[controller]")]
    public class UrlController : Controller
    {
        // http://localhost:5000/api/it-CH/AboutWithCultureInRoute
        // http://localhost:5000/api/fr-CH/AboutWithCultureInRoute
        private readonly IStringLocalizer<SharedResource> _localizer;


        public UrlController(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
        }

        [HttpGet]
        public string Get()
        {
            return _localizer["Name"];
        }
    }
}
