using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
using Robotics.Models;

namespace Robotics.Controllers
{
  
   // [ServiceFilter(typeof(LanguageActionFilter))]
    //[Route("[controller]/[action]")]
    public class BaseController : Controller
{
   //you can use the localizer in you controller 
    private readonly IStringLocalizer<BaseController> _localizer;
    public BaseController(IStringLocalizer<BaseController> localizer)
    {
        _localizer = localizer;
    }

    public IActionResult Index()
    {
        return View();
    }

       [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            string returnUrl1;
            returnUrl1 = string.Concat("/", culture, returnUrl);

            Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), //CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) } 
        );
            
            return LocalRedirect(returnUrl1);
        }
        //public string _culture;
        // public IActionResult ReadCookies()
        // {
        //     ViewBag.CookieCulture = Request.Cookies["AspNetCore.Culture"];
        // _culture = Request.Cookies["AspNetCore.Culture"];
        //     if (string.IsNullOrEmpty(ViewBag.CookieCulture))
        //     {
        //ViewBag.CookieCulture = "en-US";
        //
        //}
        //            return View();
        //}
    }
}