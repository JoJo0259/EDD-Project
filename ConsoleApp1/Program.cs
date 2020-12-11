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
            public static string DownloadsPath;
            public static string downSave = "\\down.txt";
            public static string nTempWipe = "";
        }
        public static void tag(string[] topFold, List<int> acceptable, List<string> toopen)
        {
            string currentLoc = Path.Combine(topFold[1], toopen[0].Split(@"\").Last());
            string[] split = currentLoc.Split(@"\");
            string currentFold = "Tag";
            string currentBase = Path.Combine(split[0], split[1]);
            int q = 2;
            while(q <= split.Length - 3)
            {
                currentBase = Path.Combine(currentBase, split[q]);
                q++;
            }
            string currentFile = currentLoc.Split(@"\").Last();
            string[] primaryFold = Directory.GetDirectories(currentLoc.Split(@"\")[currentLoc.Split(@"\").Length - 2]);
            int sel = 0;
            int p = 1;
            acceptable.Clear();
            while (p <= primaryFold.Length)
                {
                    acceptable.Add(p);
                    p++;
                }
            acceptable.Add(p);
            while (!acceptable.Contains(sel))
                {
                    Console.WriteLine("Which sort method would you like to use.\nAnswer with the list number.");
                    int i = 1;
                    foreach (string folder in primaryFold)
                    {
                        Console.WriteLine("{0}. {1}", i, primaryFold[i - 1].Split(@"\").Last());
                        i++;
                    }
                    Console.WriteLine("{0}. Create New Folder", i);
                    var res = Console.ReadLine();
                    int yes;
                    int.TryParse(res, out yes);
                    if (yes != 0)
                    {
                        sel = yes;
                    }
                    else
                    {
                        Console.WriteLine("That is not an acceptable response\nTry again");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                }
            if (sel == p)
                {
                    //Create New primary
                    Console.WriteLine("Enter the name of your new primay folder.");
                    var name = Console.ReadLine();
                    string newFold = Path.Combine(currentFold, name);
                    Directory.CreateDirectory(/*Path.Combine(currentBase, */newFold)/*)*/;
                    File.Move(currentLoc, Path.Combine(newFold, currentFile));
                    //new loop for secondary folder
                    currentLoc = Path.Combine(newFold, currentFile);
                    currentFold = newFold;
                    string[] secondaryFold = Directory.GetDirectories(currentFold);
                    sel = 0;
                    p = 1;
                    acceptable.Clear();
                    while (p <= secondaryFold.Length)
                    {
                        acceptable.Add(p);
                        p++;
                    }
                    acceptable.Add(p);
                    while (!acceptable.Contains(sel))
                    {
                        Console.WriteLine("Which sort method would you like to use.\nAnswer with the list number.");
                        int i = 1;
                        foreach (string folder in secondaryFold)
                        {
                            Console.WriteLine("{0}. {1}", i, secondaryFold[i - 1].Split(@"\").Last());
                            i++;
                        }
                        Console.WriteLine("{0}. Create New Folder", i);
                        var res = Console.ReadLine();
                        int yes;
                        int.TryParse(res, out yes);
                        if (yes != 0)
                        {
                            sel = yes;
                        }
                        else
                        {
                            Console.WriteLine("That is not an acceptable response\nTry again");
                            System.Threading.Thread.Sleep(1000);
                            Console.Clear();
                        }
                    }
                    if (sel == p)
                    {
                        //create new secondary
                        Console.WriteLine("Enter the name of your new secondary folder.");
                        name = Console.ReadLine();
                        newFold = Path.Combine(currentFold, name);
                        Directory.CreateDirectory(newFold);
                        File.Move(currentLoc, Path.Combine(newFold, currentFile));
                        //final loop
                        currentLoc = Path.Combine(newFold, currentFile);
                        currentFold = newFold;
                        string[] tertiaryFold = Directory.GetDirectories(currentFold);
                        sel = 0;
                        p = 1;
                        acceptable.Clear();
                        while (p <= tertiaryFold.Length)
                        {
                            acceptable.Add(p);
                            p++;
                        }
                        acceptable.Add(p);
                        while (!acceptable.Contains(sel))
                        {
                            Console.WriteLine("Which sort method would you like to use.\nAnswer with the list number.");
                            int i = 1;
                            foreach (string folder in tertiaryFold)
                            {
                                Console.WriteLine("{0}. {1}", i, tertiaryFold[i - 1].Split(@"\").Last());
                                i++;
                            }
                            Console.WriteLine("{0}. Create New Folder", i);
                            var res = Console.ReadLine();
                            int yes;
                            int.TryParse(res, out yes);
                            if (yes != 0)
                            {
                                sel = yes;
                            }
                            else
                            {
                                Console.WriteLine("That is not an acceptable response\nTry again");
                                System.Threading.Thread.Sleep(1000);
                                Console.Clear();
                            }
                        }
                        if (sel == p)
                        {
                            Console.WriteLine("Eneter the name for your new tertiary folder.");
                            name = Console.ReadLine();
                            newFold = Path.Combine(currentFold, name);
                            Directory.CreateDirectory(newFold);
                            File.Move(currentLoc, Path.Combine(newFold, currentFile));
                        }
                        else
                        {
                            //just move
                            File.Move(currentLoc, Path.Combine(tertiaryFold[sel - 1], currentFile));
                        }
                    }
                    else
                    {
                        File.Move(currentLoc, Path.Combine(secondaryFold[sel - 1], currentFile));
                        //other loop
                        //final loop
                        currentLoc = Path.Combine(secondaryFold[sel - 1], currentFile);
                        currentFold = secondaryFold[sel - 1];
                        string[] tertiaryFold = Directory.GetDirectories(currentFold);
                        sel = 0;
                        p = 1;
                        acceptable.Clear();
                        while (p <= primaryFold.Length)
                        {
                            acceptable.Add(p);
                            p++;
                        }
                        acceptable.Add(p);
                        while (!acceptable.Contains(sel))
                        {
                            Console.WriteLine("Which sort method would you like to use.\nAnswer with the list number.");
                            int i = 1;
                            foreach (string folder in tertiaryFold)
                            {
                                Console.WriteLine("{0}. {1}", i, tertiaryFold[i - 1].Split(@"\").Last());
                                i++;
                            }
                            Console.WriteLine("{0}. Create New Folder", i);
                            var res = Console.ReadLine();
                            int yes;
                            int.TryParse(res, out yes);
                            if (yes != 0)
                            {
                                sel = yes;
                            }
                            else
                            {
                                Console.WriteLine("That is not an acceptable response\nTry again");
                                System.Threading.Thread.Sleep(1000);
                                Console.Clear();
                            }
                        }
                        if (sel == p)
                        {
                            Console.WriteLine("Eneter the name for your new tertiary folder.");
                            name = Console.ReadLine();
                            newFold = Path.Combine(currentFold, name);
                            Directory.CreateDirectory(newFold);
                            File.Move(currentLoc, Path.Combine(newFold, currentFile));
                        }
                        else
                        {
                            //just move
                            File.Move(currentLoc, Path.Combine(tertiaryFold[sel - 1], currentFile));
                        }
                    }
                }
            else
                {
                    File.Move(currentLoc, Path.Combine(primaryFold[sel - 1], currentFile));
                    //new loop for things
                    currentLoc = Path.Combine(primaryFold[sel - 1], currentFile);
                    currentFold = primaryFold[sel - 1];
                    string[] secondaryFold = Directory.GetDirectories(currentFold);
                    sel = 0;
                    p = 1;
                    acceptable.Clear();
                    while (p <= secondaryFold.Length)
                    {
                        acceptable.Add(p);
                        p++;
                    }
                    acceptable.Add(p);
                    while (!acceptable.Contains(sel))
                    {
                        Console.WriteLine("Which sort method would you like to use.\nAnswer with the list number.");
                        int i = 1;
                        foreach (string folder in secondaryFold)
                        {
                            Console.WriteLine("{0}. {1}", i, secondaryFold[i - 1].Split(@"\").Last());
                            i++;
                        }
                        Console.WriteLine("{0}. Create New Folder", i);
                        var res = Console.ReadLine();
                        int yes;
                        int.TryParse(res, out yes);
                        if (yes != 0)
                        {
                            sel = yes;
                        }
                        else
                        {
                            Console.WriteLine("That is not an acceptable response\nTry again");
                            System.Threading.Thread.Sleep(1000);
                            Console.Clear();
                        }
                    }
                    if (sel == p)
                    {
                        //create new secondary
                        Console.WriteLine("Enter the name of your new secondary folder.");
                        string name = Console.ReadLine();
                        string newFold = Path.Combine(currentFold, name);
                        Directory.CreateDirectory(newFold);
                        File.Move(currentLoc, Path.Combine(newFold, currentFile));
                        //final loop
                        currentLoc = Path.Combine(newFold, currentFile);
                        currentFold = newFold;
                        string[] tertiaryFold = Directory.GetDirectories(currentFold);
                        sel = 0;
                        p = 1;
                        acceptable.Clear();
                        while (p <= tertiaryFold.Length)
                        {
                            acceptable.Add(p);
                            p++;
                        }
                        acceptable.Add(p);
                        while (!acceptable.Contains(sel))
                        {
                            Console.WriteLine("Which sort method would you like to use.\nAnswer with the list number.");
                            int i = 1;
                            foreach (string folder in tertiaryFold)
                            {
                                Console.WriteLine("{0}. {1}", i, tertiaryFold[i - 1].Split(@"\").Last());
                                i++;
                            }
                            Console.WriteLine("{0}. Create New Folder", i);
                            var res = Console.ReadLine();
                            int yes;
                            int.TryParse(res, out yes);
                            if (yes != 0)
                            {
                                sel = yes;
                            }
                            else
                            {
                                Console.WriteLine("That is not an acceptable response\nTry again");
                                System.Threading.Thread.Sleep(1000);
                                Console.Clear();
                            }
                        }
                        if (sel == p)
                        {
                            Console.WriteLine("Eneter the name for your new tertiary folder.");
                            name = Console.ReadLine();
                            newFold = Path.Combine(currentFold, name);
                            Directory.CreateDirectory(newFold);
                            File.Move(currentLoc, Path.Combine(newFold, currentFile));
                        }
                        else
                        {
                            //just move
                            File.Move(currentLoc, Path.Combine(tertiaryFold[sel - 1], currentFile));
                        }
                    }
                    else
                    {
                        File.Move(currentLoc, Path.Combine(secondaryFold[sel - 1], currentFile));
                        //other loop
                        //final loop
                        currentLoc = Path.Combine(secondaryFold[sel - 1], currentFile);
                        currentFold = secondaryFold[sel - 1];
                        string[] tertiaryFold = Directory.GetDirectories(currentFold);
                        sel = 0;
                        p = 1;
                        acceptable.Clear();
                        while (p <= tertiaryFold.Length)
                        {
                            acceptable.Add(p);
                            p++;
                        }
                        acceptable.Add(p);
                        while (!acceptable.Contains(sel))
                        {
                            Console.WriteLine("Which sort method would you like to use.\nAnswer with the list number.");
                            int i = 1;
                            foreach (string folder in tertiaryFold)
                            {
                                Console.WriteLine("{0}. {1}", i, tertiaryFold[i - 1].Split(@"\").Last());
                                i++;
                            }
                            Console.WriteLine("{0}. Create New Folder", i);
                            var res = Console.ReadLine();
                            int yes;
                            int.TryParse(res, out yes);
                            if (yes != 0)
                            {
                                sel = yes;
                            }
                            else
                            {
                                Console.WriteLine("That is not an acceptable response\nTry again");
                                System.Threading.Thread.Sleep(1000);
                                Console.Clear();
                            }
                        }
                        if (sel == p)
                        {
                            Console.WriteLine("Eneter the name for your new tertiary folder.");
                            string name = Console.ReadLine();
                            string newFold = Path.Combine(currentFold, name);
                            Directory.CreateDirectory(newFold);
                            File.Move(currentLoc, Path.Combine(newFold, currentFile));
                        }
                        else
                        {
                            //just move
                            File.Move(currentLoc, Path.Combine(tertiaryFold[sel - 1], currentFile));
                        }
                    }
                }
        }
        public static string getDown()
        {
            string[] users = Directory.GetDirectories(@"C:\Users\");
            Console.WriteLine("Which user are you\nAnswer with the list number");
            int i = 1;
            int sel = 0;
            foreach (string user in users)
            {
                Console.WriteLine(i + ".  "  + user);
                i++;
            }
            while (true)
            {
                var ret = Console.ReadLine();
                try
                {
                    sel = int.Parse(ret);
                    if (sel > 0 && sel < users.Length)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Selection out of range.\nTry again.");
                    }
                }
                catch
                {
                    Console.WriteLine("That is not a number.\nTry again.");
                }
            }
            return Path.Combine(users[sel - 1], "Downloads");
        }
        static void Main(string[] args)
        {
            //Console.WriteLine((int.Parse(DateTime.Now.ToString("dd")) + 7).ToString() + DateTime.Now.ToString("/MM/yyy HH:mm:ss"));
            if (File.Exists(Directory.GetCurrentDirectory() + Variables.downSave))
            {
                Variables.DownloadsPath = File.ReadAllText(Directory.GetCurrentDirectory() + Variables.downSave);
                while (true)
                {
                    if (Directory.Exists(Variables.DownloadsPath))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("There was a problem with the saved or new donwloads folder path.\nPlease re-try a new path selection");
                        Variables.DownloadsPath = getDown();
                    }
                }
            }
            else
            {
                File.Create(Directory.GetCurrentDirectory() + Variables.downSave).Close();
                Console.WriteLine("Use the path selection to find your downloads folder");
                Variables.DownloadsPath = getDown();
                while (true)
                {
                    if (Directory.Exists(Variables.DownloadsPath))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("There was a problem with the selected donwloads folder path.\nPlease re-try a new selection");
                        Variables.DownloadsPath = getDown();
                    }
                }
            }
            while (true)
            {
                try
                {
                    File.WriteAllTextAsync(Directory.GetCurrentDirectory() + Variables.downSave, Variables.DownloadsPath);
                    break;
                }
                catch
                {

                }
            }
            List<string> Folders = new List<string>();
            Folders.Add("Tag");
            Folders.Add("Long Term");
            Folders.Add("Temporary");
            string[] Folds = Directory.GetDirectories(Directory.GetCurrentDirectory()).ToArray();
            foreach(string folder in Folds)
            {
                if (Folders.Contains(folder.Split(@"\").Last()))
                {
                    Folders.Remove(folder.Split(@"\").Last());
                }
            }
            foreach(string unfolder in Folders)
            {
                Directory.CreateDirectory(unfolder);
            }
            while (true)
            {
                try
                {
                    File.WriteAllText(Directory.GetCurrentDirectory() + Variables.downSave, Variables.DownloadsPath);
                    break;
                }
                catch
                {

                }
            }
            string[] files = Directory.GetFiles(Variables.DownloadsPath).OrderByDescending(d => new FileInfo(d).CreationTime).ToArray();
            Variables.startingFile = files[0];
            //Console.WriteLine("Hello World!");
            while (true)
            {
                Checking();
            }
        }
        public static void Checking()
        {
            //look through folder

            string[] files = Directory.GetFiles(Variables.DownloadsPath).OrderByDescending(d => new FileInfo(d).CreationTime).ToArray();
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
            List<string> ToRemove = new List<string>();
            foreach (string file in ToOpen)
            {
                if (!Variables.OpenPop.Contains(file))
                {
                    Variables.OpenPop.Add(file);
                }
                else
                {
                    ToRemove.Add(file);
                }
            }
            foreach(string file in ToRemove)
            {
                ToOpen.Remove(file);
            }
            popup(ToOpen);
            System.Threading.Thread.Sleep(60000);
        }
        public static void popup(List<string> toopen)
        {
            //create popup and move file
            if(toopen.Count != 0)
            {
                Console.WriteLine("*\n{0}\n*", toopen[0]);
                string[] topFold = Directory.GetDirectories(Directory.GetCurrentDirectory());
                int sel = -1;
                List<int> acceptable = new List<int>();
                int r = 1;
                foreach(string thing in topFold)
                {
                    acceptable.Add(r);
                    r++;
                }
                acceptable.Add(r);
                while (!acceptable.Contains(sel))
                {
                    Console.WriteLine("Which sort method would you like to use.\nAnswer with the list number.");
                    int i = 1;
                    foreach (string folder in topFold)
                    {
                        Console.WriteLine("{0}. {1}", i, topFold[i - 1].Split(@"\").Last());
                        i++;
                    }
                    Console.WriteLine("{0}. Delete", i);
                    var res = Console.ReadLine();
                    int yes;
                    int.TryParse(res, out yes);
                    if (yes != 0)
                    {
                        sel = yes;
                    }
                    else
                    {
                        Console.WriteLine("That is not an acceptable response\nTry again");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                }
                //do the task given
                if(sel != acceptable.Last())
                {
                    File.Move(toopen[0], Path.Combine(topFold[sel - 1], toopen[0].Split(@"\").Last()));
                    if (topFold[sel - 1].Split(@"\").Last() == "Tag")
                    {
                        tag(topFold, acceptable, toopen);
                    }
                }
                else if (sel == acceptable.Last())
                {
                    try
                    {
                        File.Delete(toopen[0]);
                    }
                    catch
                    {
                        Console.WriteLine("Error in deleting file\nTry again later");
                    }
                }
                else
                {
                    Console.WriteLine("There has been a glitch in the matrix.\nTry again later.");
                }
                Variables.OpenPop.Remove(toopen[0]);
                toopen.RemoveAt(0);
                popup(toopen);
                Console.WriteLine("Sucessful!");
            }
        }
    }
}
