using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TestEmpeek.WebService.Models
{
    public class DirInfo
    {
        public int firstinfo { get; set; }
        public int secondinfo{ get; set; }
        public int thirdinfo{ get; set; }
        public List<FileInfo> FileList = new List<FileInfo>();
        public DirectoryInfo[] subdirect { get; set; }
        public FileInfo[] files { get; set; }
        public string currdir { get; set; }
        public List<string> mylog = new List<string>();
        
    }
}