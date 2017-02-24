using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Robotics.Controllers
{
    public class HttpContextService : ActionFilterAttribute
    { 

    private  IHttpContextAccessor _context;
    public HttpContextService(IHttpContextAccessor context)
    {
        _context = context;
    }

    }
}

