using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;



//--------------------------------------------------------------------------------------------------
// Name: OnStart
// 
// 
// Arguments:
// None: Program doesn't use the C# args parameter explicitly.
//
// 
//
// About: Starts off by reading from a text file in the user's documents folder called FileList and reads the file paths listed in that file.
// It then checks to see if any of those files are 14 days old and if they are it deletes the file or directory. Directories are deleted recursively.
// if path read from file isn't found then the path is rewritten to the file with a note at the end telling the user to delete the path from the list.
//
// 
//--------------------------------------------------------------------------------------------------

namespace FileMonitor
{
    public partial class FileMonitor : ServiceBase
    {
        public FileMonitor()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            { 
                string FileListPath = "C:\\Users\\Public\\Documents\\FileList.txt";
                string[] files = File.ReadAllLines(FileListPath); // get all file paths and dates entered into the file list
                int index = 0;
                for (int i = 0; i < files.Length; i++)
                {
                    index = files[i].LastIndexOf("date");
                    index += 5;
                    string temp = files[i].Substring(index); //get the date to check if the file is old enough to delete
                    DateTime date = Convert.ToDateTime(temp);
                    int diff = (DateTime.Today - date).Days;
                    if (diff > 14) // checking if the file is older than 2 weeks 
                    {
                        index -= 5;
                        string delPath = files[i].Substring(0, index); // get file path
                        FileAttributes attr = File.GetAttributes(delPath);
                        if (attr.HasFlag(FileAttributes.Directory)) // check if path is a directory or file
                        {
                            Directory.Delete(delPath, true); // if it's a directory delete everything in the directory
                        }
                        else // otherwise just delete the file
                        {
                            File.Delete(delPath);
                        }
                    }
                }
            }catch(Exception e)
            {
                using (StreamWriter sw = File.AppendText("C:\\Users\\Public\\Desktop\\FileList.txt"))
                {
                    sw.WriteLine(e.ToString() + "delete this path from file"); // write path to file with "delete this path from file" phrase at the end so user 
// knows to delete the path from the file
                }
            }
        }


        protected override void OnStop()
        {
        }
    }
}
