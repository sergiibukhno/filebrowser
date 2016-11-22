using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestEmpeek.WebService.DAL;
using TestEmpeek.WebService.Models;

namespace TestEmpeek.WebService.BLL
{
    public class FileBrowserBLL
    {
        string result=null;

        public DirInfo GetCurrentDirectoryInfo(string inputDirectory)
        {
            FileBrowserDAL fbDAL = new FileBrowserDAL();

            DirInfo dirinfo = fbDAL.GetInfo(inputDirectory);

            return dirinfo;

        }



        public DirInfo GoForward(string inputDirectory, string id)
        {
            FileBrowserDAL fbDAL = new FileBrowserDAL();

            DirInfo dirinfo = fbDAL.GetInfo(inputDirectory+ @"\" +id);

            return dirinfo;

        }

        public DirInfo GoBack(string inputDirectory)
        {
            FileBrowserDAL fbDAL = new FileBrowserDAL();
            

            int idx = inputDirectory.LastIndexOf(@"\");

            if (idx <= 3)
            {
                result = inputDirectory.Substring(0, idx + 1);
            }
            if (idx >= 4)
            {
                result = inputDirectory.Substring(0, idx);
            }
            
            DirInfo dirinfo = fbDAL.GetInfo(result);

            return dirinfo;

        }

    }
}