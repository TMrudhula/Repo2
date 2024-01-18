using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    internal class Class2
    {
        public void DisplayFileInfo()
        {
            //existing file
            FileInfo fi = new FileInfo("C:\\c# notes\\Day 1 notes.txt");
            Console.WriteLine($"File name is {fi.Name}");
            Console.WriteLine($"File creation time is {fi.CreationTime.ToLongTimeString()}");
            Console.WriteLine($"File last access time is {fi.LastAccessTime.ToLongDateString()}");
            //Console.WriteLine($"File length is {fi.Length.ToString()} Bytes");
            Console.WriteLine($"File extension is {fi.Extension}");
            Console.WriteLine($"File exists: {fi.Exists}");
            Console.WriteLine($"File last write time is {fi.LastWriteTime}");
            Console.ReadLine();
        }

        public void CreateFile()
        {
            FileInfo fi = new FileInfo("NewFile.txt");
            using StreamWriter str = fi.CreateText();
            str.WriteLine("hello");
            Console.WriteLine("File has been created with text.");
        }

        public void DeleteFile()
        {
            // Use a raw string literal for the file path
            FileInfo fi = new FileInfo(@"NewFile2.txt");
            // Delete the file if it exists
            fi.Delete();
            Console.WriteLine("File has been deleted");
        }

        public void CopyToFile()
        {
            // Use raw string literals for the file paths
            string path = @"NewFile.txt";
            string path2 = @"NewFile2.txt";
            FileInfo fi1 = new FileInfo(path);
            FileInfo fi2 = new FileInfo(path2);
            // Copy the first file to the second file
            fi1.CopyTo(path2);
            Console.WriteLine("{0} was copied to {1}.", path, path2);
        }

        public void MoveFile()
        {
            // Use raw string literals for the file paths
            string path = @"NewFile.txt";
            string path2 = @"NewFile3.txt";
            FileInfo fi1 = new FileInfo(path);
            FileInfo fi2 = new FileInfo(path2);
            // Copy the first file to the second file
            fi1.MoveTo(path2);
            Console.WriteLine("{0} was copied to {1}.", path, path2);
        }

        public void AppendtoFile()
        {
            // Create a FileInfo object for the file to append
            FileInfo fi = new FileInfo(@"NewFile2.txt");

            // Check if the file exists and create it if not
            if (!fi.Exists)
            {
                fi.Create().Close();
            }

            // Open the file in append mode and write some lines
            using (StreamWriter sw = fi.AppendText())
            {
                sw.WriteLine("This");
                sw.WriteLine("is Extra");
                sw.WriteLine("Text");
                Console.WriteLine("File has been appended");
            }
        }

        public void OpenText()
        {
            // Create a FileInfo object for the file to read
            FileInfo fi = new FileInfo(@"NewFile2.txt");

            // Check if the file exists and open it in read mode
            if (fi.Exists)
            {
                using (StreamReader sr = fi.OpenText())
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}

