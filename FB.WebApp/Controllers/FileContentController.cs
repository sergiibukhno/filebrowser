using FB.WebApp.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace FB.WebApp.Controllers
{    
    public class FileContentController : ApiController
    {
        private IBrowserService _browserService;

        public FileContentController(IBrowserService browserService)
        {
            _browserService = browserService;
        }

        public HttpResponseMessage Get(string id)
        {
            if (String.IsNullOrEmpty(id))
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            else
            {
                id = _browserService.DecodeString(id);
                HttpResponseMessage content = _browserService.GetContent(id);
                return content;
            }                     
        }
    }
}
