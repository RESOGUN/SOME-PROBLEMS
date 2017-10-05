using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication2
{
    class Program
    {

        static bool CreateTree(string Dir, bool Sub,
    [Optional] StreamWriter Ws, [Optional] bool DisposeStream, [Optional] int Level)
        {
            if (!Directory.Exists(Dir))
                return false;

            string pad = new string('-', Level++);
            //try
            {
                string[] files = Directory.GetFiles(Dir);
                if (Ws == null)
                    Console.WriteLine(string.Concat(pad, " ", Dir));
                else
                    Ws.WriteLine(string.Concat(pad, " ", Dir));
                pad += "-";
                foreach (string file in files)
                    if (Ws == null)
                        Console.WriteLine(string.Concat(pad, " ", Path.GetFileName(file)));
                    else
                        Ws.WriteLine(string.Concat(pad, " ", Path.GetFileName(file)));
                if (Sub)
                {
                    foreach (string folder in Directory.GetDirectories(Dir))
                    {
                        CreateTree(folder, Sub, Ws, false, Level);
                    }
                }
            }
           // catch (Exception ex)
           // {
            //    if (Ws == null)
              //      Console.WriteLine(string.Concat(pad, " Exception: ", ex.Message));
               // else
                 //   Ws.WriteLine(string.Concat(pad, " Exception: ", ex.Message));
        //    }
           // finally
           // {
            //    if (DisposeStream && Ws != null)
             //   {
              //      Ws.Flush();
               //     Ws.Close();
               //     Ws.Dispose();
               //     Ws = null;
              //  }
           // }
            return true;
        }
        public static void PrintFiles(string dir, UInt16 fieldSize)
        {
            
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            FileInfo[] files = dirInfo.GetFiles();
            foreach (FileInfo file in files)
                Console.WriteLine(file.Name.PadLeft(fieldSize));
            DirectoryInfo[] dirs = dirInfo.GetDirectories();
            foreach (DirectoryInfo d in dirs)
                PrintFiles(d.FullName, (UInt16)(fieldSize + 4));
             
   
        }
        public static void Main(string[] args)
        {


            Console.OutputEncoding = Encoding.UTF8;
            string a = (Directory.GetCurrentDirectory());
            //PrintFiles(a, 0);
            CreateTree(a, true);
            Console.ReadKey(true);
            //DirectoryInfo dir = new DirectoryInfo(@"D:\RUS");
            //Console.WriteLine("============Directory=============");
            //foreach (var item in dir.GetDirectories())
            //{
            //    Console.WriteLine(item.Name);
            //    Console.WriteLine("==Sub-Directory==");
            //    foreach (var it in item.GetDirectories())
            //        Console.WriteLine(it.Name);
            //    Console.WriteLine();
            //}
            //Console.WriteLine("==============Files==============");
            //foreach (var item in dir.GetFiles())
            //{
            //    Console.WriteLine(item.Name);
            //}
            //Console.ReadLine();
        }
    }
}
