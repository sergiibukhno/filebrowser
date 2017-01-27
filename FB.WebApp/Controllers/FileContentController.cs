using FB.WebApp.Core;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
                HttpResponseMessage response = new HttpResponseMessage();
                response.Content = _browserService.GetContent(id);

                if (id.EndsWith("pdf"))
                {
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                }

                if (id.EndsWith("doc"))
                {
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/msword");
                    response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
                }

                return response;
            }                     
        }
    }
}
