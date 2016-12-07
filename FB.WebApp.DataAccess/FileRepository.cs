using System.Collections.Generic;
using System.IO;
using FB.Models;
using System;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;

namespace FB.WebApp.DataAccess
{
    public interface IFileRepository
    {
        IDirInfo GetFilesDirs(string input);
        List<int> GetAllFiles(string input);
        DriveInfo[] GetAllDrives();
        HttpResponseMessage GetFileContent(string input);
    }
    
    public class FileRepository:IFileRepository
    {
        private IDirInfo dirinfo;
        
        public FileRepository(IDirInfo dirInfo)
        {
            dirinfo = dirInfo;
        }

        public IDirInfo GetFilesDirs(string input)
        {
            DirectoryInfo directoryinfo = new DirectoryInfo(input);
            dirinfo.subdirect = directoryinfo.GetDirectories();
            dirinfo.files = directoryinfo.GetFiles();
            return dirinfo;
        }

        public List<int> GetAllFiles(string input)
        {            
            FileInfo[] files = null;
            List<FileInfo> fileList = new List<FileInfo>();
            Stack<string> stack=new Stack<string>();
            string[] directories;
            string dir;
            int less_10_count = 0;
            int from10_count = 0;
            int more_100_count = 0;

            stack.Push(input);

            while (stack.Count > 0)
            {
                dir = stack.Pop();
                DirectoryInfo directoryinfo = new DirectoryInfo(dir);
                
                try
                {
                    files = directoryinfo.GetFiles();
                }
                catch (Exception ex)
                {
                    continue;
                }
                
                foreach (var file in files)
                {
                    fileList.Add(file);
                }

                directories = Directory.GetDirectories(dir);
                
                foreach (string directory in directories)
                {
                    stack.Push(directory);
                }
            }

            List<double> mbinfo = new List<double>();

            foreach (var convert in fileList)
            {
                mbinfo.Add(convert.Length * 0.000001);
            }

            foreach (var item in mbinfo)
            {
                if (item <= 10)
                {
                    less_10_count++;
                }
                else
                    if (item > 10 && item <= 50)
                    {
                        from10_count++;
                    }
                    else
                        if (item >= 100)
                        {
                            more_100_count++;
                        }
            }

            return new List<int> { less_10_count, from10_count, more_100_count };
        }

        public DriveInfo[] GetAllDrives()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();           
            return allDrives;
        }

        public HttpResponseMessage GetFileContent(string input)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StreamContent(new FileStream(input, FileMode.Open, FileAccess.Read));
            
            if (input.EndsWith("pdf"))
            {
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            }

            if (input.EndsWith("doc"))
            {
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/msword");
                response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
            }

            return response;
        }

    }
}
