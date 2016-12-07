using System.Collections.Generic;
using System.Web.Http;
using FB.WebApp.Core;

namespace FB.WebApp.Controllers
{    
    public class CountController : ApiController
    {
        private IBrowserService _browserService;

        public CountController(IBrowserService browserService)
        {
            _browserService = browserService;
        }

        public IHttpActionResult Get(string id)
        {
            List<int> countedFiles = new List<int>();
            string decodedInput = _browserService.DecodeString(id);
            countedFiles = _browserService.Countfiles(decodedInput);
            return Ok(countedFiles);
        }        
    }
}
