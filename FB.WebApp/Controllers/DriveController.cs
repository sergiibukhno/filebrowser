using System.Collections.Generic;
using System.Web.Http;
using FB.Models;
using FB.WebApp.Core;

namespace FB.WebApp.Controllers
{
    public class DriveController : ApiController
    {
        private IBrowserService _browserService;
        private IDirInfo dirinfo;

        public DriveController(IBrowserService browserService, IDirInfo dirInfo)
        {
            _browserService = browserService;
            dirinfo = dirInfo;
        }

        public IHttpActionResult Get()
        {           
            List<string> driveNames = new List<string>();
            driveNames = _browserService.ReturnDrives();
            return Ok(driveNames);
        }

        public IHttpActionResult Get(string id)
        {
            string decodedInput = _browserService.DecodeString(id);
            dirinfo = _browserService.ReturnFilesDirs(decodedInput);
            return Ok(dirinfo);
        }       
    }
}
