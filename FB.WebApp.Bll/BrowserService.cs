using System.Collections.Generic;
using FB.WebApp.Dal;
using System.IO;
using FB.Models;

namespace FB.WebApp.Bll
{
    public interface IBrowserService
    {
        List<string> ReturnDrives();
        List<int> Countfiles(string input);
        IDirInfo ReturnFilesDirs(string input);
        string DecodeString(string input);
    }
    
    public class BrowserService:IBrowserService
    {
        private IFileRepository fr;
        private IDirInfo dirinfo;
        
        public BrowserService(IFileRepository filerep,IDirInfo dirInfo)
        {
            fr = filerep;
            dirinfo = dirInfo;
        }
        
        public List<string> ReturnDrives()
        {
            DriveInfo[] myDrives = fr.GetAllDrives();
            List<string> driveNames = new List<string>();
            
            foreach (var item in myDrives)
            {
                if (item.DriveType.ToString() == "Fixed")
                {
                    driveNames.Add(item.Name);
                }
            }

            return driveNames;
        }

        public List<int> Countfiles(string input)
        {
            List<int> myFiles = fr.GetAllFiles(input);
            return myFiles;            
        }

        public IDirInfo ReturnFilesDirs(string input)
        {
            dirinfo = fr.GetFilesDirs(input);
            dirinfo.currdir = input;
            return dirinfo;
        }

        public string DecodeString(string input)
        {
            input = input.Replace("d0td0t", ":").Replace("b3cks1", "\\").Replace("t0d", ".").Replace("sh4", "#");
            return input;
        }
    }
}
