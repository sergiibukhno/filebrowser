using System.Collections.Generic;
using System.Web.Http;
using FB.WebApp.Bll;

namespace FB.WebApp.Controllers
{    
    public class CountController : ApiController
    {
        private IBrowserService bs;
        
        public CountController(IBrowserService bll)
        {
            bs = bll;
        }
        
        public List<int> Get(string id)
        {
            List<int> countedFiles = new List<int>();
            string decodedInput = bs.DecodeString(id);
            countedFiles = bs.Countfiles(decodedInput);
            return countedFiles;
        }        
    }
}
