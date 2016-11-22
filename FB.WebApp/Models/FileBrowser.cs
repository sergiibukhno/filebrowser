using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace TestEmpeek.WebService.Models
{
    public class FileBrowser
    {
        List<FileInfo> fileInfoList = new List<FileInfo>();
        List<string> log = new List<string>();
        


        public void WalkDirectoryTree(DirectoryInfo root)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;


            
                files = root.GetFiles("*.*");
            

            if (files != null)
            {
                foreach (FileInfo fi in files)
                {

                    fileInfoList.Add(fi);
                }


                subDirs = root.GetDirectories();

                foreach (DirectoryInfo dirInfo in subDirs)
                {

                    WalkDirectoryTree(dirInfo);
                }
            }
        }


        public DirInfo GetInfo(string _input)
        {
            DirInfo mydir = new DirInfo();
            string directory = null;

            if (_input!=null&&_input.Length!=0)
            {
                directory = _input;
            }

            if (_input == null || _input.Length == 0)
            {
                directory = Directory.GetCurrentDirectory();
            }

            int less_10_count = 0;
            int from10_count = 0;
            int more_100_count = 0;


            DirectoryInfo di = new DirectoryInfo(directory);

            try
            {

            WalkDirectoryTree(di);
            
                mydir.subdirect = di.GetDirectories();
                mydir.files = di.GetFiles();




                List<double> mbinfo = new List<double>();

                foreach (var convert in fileInfoList)
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

                mydir.firstinfo = less_10_count;
                mydir.secondinfo = from10_count;
                mydir.thirdinfo = more_100_count;
                mydir.currdir = directory;
                fileInfoList.Clear();
            }
            catch (Exception ex)
            {

                log.Add(ex.Message.ToString());
            }
            mydir.mylog = log;
            return mydir;
        }
    }
}