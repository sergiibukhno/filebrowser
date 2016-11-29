using System.Collections.Generic;
using System.Web.Http;
using FB.Models;
using FB.WebApp.Bll;

namespace FB.WebApp.Controllers
{
    public class DriveController : ApiController
    {
        private IBrowserService bs;
        private IDirInfo dirinfo;

        public DriveController(IBrowserService bll,IDirInfo dirInfo)
        {
            bs = bll;
            dirinfo = dirInfo;
        }
        
        public List<string> Get()
        {           
            List<string> driveNames = new List<string>();
            driveNames = bs.ReturnDrives();
            return driveNames;
        }

        public IDirInfo Get(string id)
        {
            string decodedInput = bs.DecodeString(id);
            dirinfo = bs.ReturnFilesDirs(decodedInput);
            return dirinfo;
        }       
    }
}
