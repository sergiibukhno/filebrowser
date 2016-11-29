using System.IO;

namespace FB.Models
{
    public interface IDirInfo
    {
        DirectoryInfo[] subdirect { get; set; }
        FileInfo[] files { get; set; }
        string currdir { get; set; }
    }

    public class DirInfo : IDirInfo
    {
        public DirectoryInfo[] subdirect { get; set; }
        public FileInfo[] files { get; set; }
        public string currdir { get; set; }
    }
}
