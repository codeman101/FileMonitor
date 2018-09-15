using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLogger
{
    class Program
    {
        static string FileListPath;

        static void Main(string[] args)
        {
            string[] get = Environment.GetCommandLineArgs(); // get the name of the file to add to the file list
            string path = get[1];
            FileListPath = "C:\\Users\\Public\\Documents\\FileList.txt";
            
            try
            {
                FileAttributes attr = File.GetAttributes(path); // check if it's a directory
                if (attr.HasFlag(FileAttributes.Directory))
                {
                    string temp = path;
                    temp += " date " + DateTime.Now.ToString();

                    using (StreamWriter sw = File.AppendText(FileListPath))
                    {
                        sw.WriteLine(temp); // write current file path in loop to the file list
                    }
                    dirSearch(path);
                }
                else // not a directory so just going to add the individual file
                {
                    path += " date " + File.GetCreationTime(path);
                    using (StreamWriter sw = File.AppendText(FileListPath))
                    {
                        sw.WriteLine(path);
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write("the path you give isn't vaild rerun me and try again"); // file path wasn't found
                Console.Write(e.ToString());
            }
                
        }
        public static void dirSearch(string path) // method to recursively iterate through file tree to log directories and files
        {
            try
            {
                foreach (string dir in Directory.GetDirectories(path))
                {

                    foreach (string file in Directory.GetFiles(dir))
                    {
                        string temp = file;
                        temp += " date " + DateTime.Now.ToString(); // get today's date and add it to file path to be written to file list
                        using (StreamWriter sw = File.AppendText(FileListPath))
                        {
                            sw.WriteLine(temp); // write current file path in loop to the file list
                        }

                    }
                    dirSearch(dir);
                }
            }catch(Exception erro)
            {
                Console.Write("most inner directory it hit. Rolling back now");
            }
        }
    }
}
