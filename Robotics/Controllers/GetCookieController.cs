using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
using Robotics.Models;
using System.Collections;

namespace Robotics.Controllers 
{

   // [ServiceFilter(typeof(LanguageActionFilter))]
    [Route("{culture}/[controller]/[action]")]
    public class GetCookieCollection : IRequestCookieCollection, IHttpContextAccessor
    {
        public string _culture;

        int IRequestCookieCollection.Count => throw new NotImplementedException();

        ICollection<string> IRequestCookieCollection.Keys => throw new NotImplementedException();

        HttpContext IHttpContextAccessor.HttpContext { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        string IRequestCookieCollection.this[string key] => throw new NotImplementedException();
     

        bool IRequestCookieCollection.ContainsKey(string key)
        {
            throw new NotImplementedException();
        }

        bool IRequestCookieCollection.TryGetValue(string key, out string value)
        {
            throw new NotImplementedException();
        }

        IEnumerator<KeyValuePair<string, string>> IEnumerable<KeyValuePair<string, string>>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}