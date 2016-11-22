using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestEmpeek.WebService.BLL;
using TestEmpeek.WebService.Models;

namespace TestEmpeek.WebService.Controllers
{

    public static class BrowsingHistory
    {
        public static List<string> historyList = new List<string>();
    }



    [AllowAnonymous]
    public class BrowsingFilesController : ApiController
    {
        
              
        public DirInfo Get()
        {
            DirInfo dirInfo = new DirInfo();
            FileBrowserBLL fbBLL = new FileBrowserBLL();
            dirInfo = fbBLL.GetCurrentDirectoryInfo("");
            BrowsingHistory.historyList.Add(dirInfo.currdir);
            return dirInfo;
        }



        public DirInfo Get(string id)
        {
            DirInfo dirInfo = new DirInfo();
            FileBrowserBLL fbBLL = new FileBrowserBLL();

            string temporaryString = BrowsingHistory.historyList.Last();

            dirInfo = fbBLL.GoForward(temporaryString, id);

            BrowsingHistory.historyList.Add(dirInfo.currdir);

            return dirInfo;
      
        }


       
        public DirInfo Put()
        {
            FileBrowserBLL fbBLL = new FileBrowserBLL();
            DirInfo dirInfo = new DirInfo();
            string temporaryString = BrowsingHistory.historyList.Last();

            dirInfo = fbBLL.GoBack(temporaryString);

            BrowsingHistory.historyList.Add(dirInfo.currdir);

            return dirInfo;

        }

        
    }
}
