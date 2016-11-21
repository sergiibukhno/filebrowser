using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using TestEmpeek.WebService.Models;

namespace TestEmpeek.WebService.Controllers
{

    public static class BrowsingHistory
    {
        public static List<string> historyList =new List<string>();
    }



    [AllowAnonymous]
    public class ValuesController : ApiController
    {
        FileBrowser fb = new FileBrowser();
        
        string resultDirectory=null;
        

        public DirInfo Get()
        {
            DirInfo dirInfo = new DirInfo();
            dirInfo = fb.GetInfo("");

            BrowsingHistory.historyList.Add(dirInfo.currdir);
            return dirInfo;
        }

        
        public DirInfo Get(string id)
        {
            DirInfo dirInfo = new DirInfo();


            string temporaryString = BrowsingHistory.historyList.Last();
            dirInfo = fb.GetInfo(temporaryString + @"\" + id);

            BrowsingHistory.historyList.Add(dirInfo.currdir);






            return dirInfo;
        }
           
        
        public DirInfo Put()
        {
            DirInfo dirInfo = new DirInfo();
            string temporaryString = BrowsingHistory.historyList.Last();

            int index = temporaryString.LastIndexOf(@"\");

            if (index <= 3)
            {
                resultDirectory = temporaryString.Substring(0, index + 1);
            }
            if (index >= 4)
            {
                resultDirectory = temporaryString.Substring(0, index);
            }
            dirInfo = fb.GetInfo(resultDirectory);

            BrowsingHistory.historyList.Add(dirInfo.currdir);


            return dirInfo;

        }

        
    }
}
