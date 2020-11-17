using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static class Variables
        {
            public static string startingFile = "";
            public static List<string> OpenPop = new List<string>();
        }
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("C:/Users/jojok/Downloads").OrderByDescending(d => new FileInfo(d).CreationTime).ToArray();
            Variables.startingFile = files[0];
            //Console.WriteLine("Hello World!");
            while (true)
            {
                Checking();
            }
        }
        public static async Task Checking()
        {
            //look through folder

            string[] files = Directory.GetFiles("C:/Users/jojok/Downloads").OrderByDescending(d => new FileInfo(d).CreationTime).ToArray();
            List<string> ToOpen = new List<string>();
            foreach (string filename in files)
            {
                if (filename != Variables.startingFile)
                {
                    ToOpen.Add(filename);
                }
                else
                {
                    break;
                }
            }
            foreach (string file in ToOpen)
            {
                if (!Variables.OpenPop.Contains(file))
                {
                    popup(file);
                }
            }
            System.Threading.Thread.Sleep(60000);
        }
        public static async Task popup(string path)
        {
            //create popup and move file
            Variables.OpenPop.Add(path);
            Console.WriteLine("*\n{0}\n*", path);
            Variables.OpenPop.Remove(path);

        }
    }
}
