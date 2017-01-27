using System.Collections.Generic;
using FB.WebApp.DataAccess;
using System.IO;
using FB.Models;
using System.Net.Http;

namespace FB.WebApp.Core
{
    public interface IBrowserService
    {
        List<string> ReturnDrives();
        List<int> Countfiles(string input);
        IDirInfo ReturnFilesDirs(string input);
        string DecodeString(string input);
        StreamContent GetContent(string input);
    }
    
    public class BrowserService:IBrowserService
    {
        private IFileRepository _fileRepository;
        private IDirInfo dirinfo;

        public BrowserService(IFileRepository fileRepository, IDirInfo dirInfo)
        {
            _fileRepository = fileRepository;
            dirinfo = dirInfo;
        }
        
        public List<string> ReturnDrives()
        {
            DriveInfo[] myDrives = _fileRepository.GetAllDrives();
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
            List<int> myFiles = _fileRepository.GetAllFiles(input);
            return myFiles;            
        }

        public IDirInfo ReturnFilesDirs(string input)
        {
            dirinfo = _fileRepository.GetFilesDirs(input);
            dirinfo.currdir = input;
            return dirinfo;
        }

        public string DecodeString(string input)
        {
            input = input.Replace("d0td0t", ":").Replace("b3cks1", "\\").Replace("t0d", ".").Replace("sh4", "#");
            return input;
        }

        public StreamContent GetContent(string input)
        {
            var responseContent = _fileRepository.GetFileContent(input);
            return responseContent;
        }
    }
}
