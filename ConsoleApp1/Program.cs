using ConsoleApp1.BinarySearchTree;
using ConsoleApp1.Code;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercises
{
    public class Program
    {
        static IClassMethods executingModule = null;

        
        
        public static FileInfo GetNewestFile()
        {
            DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            
            if (!Directory.Exists($"{dir}"))
                return null;
            List<FileInfo> files = dir.GetFiles("*",SearchOption.AllDirectories).ToList();
            FileInfo latest = files[0];
            DateTime thisTime = DateTime.Now;
            TimeSpan min = thisTime.Subtract(latest.LastWriteTime);
            
            
            for(int i = 1; i < files.Count; i++)
            {
                if (files[i].Name == "Program.cs")
                    continue;
                if (files[i].Extension == ".cs" && thisTime.Subtract(files[i].LastWriteTime) < min)
                {
                    min = thisTime.Subtract(files[i].LastWriteTime);
                    latest = files[i];
                }
               
            }
            return latest;
        }


        public static Type GetTypeByFile(FileInfo file)
        {
            List<Type> types = Assembly.GetExecutingAssembly().GetTypes().ToList();
            string fileName = file.Name.Substring(0, file.Name.LastIndexOf('.'));
            
            foreach (var item in types)
            {
                if (item.Name == fileName)
                    return item;
            }
            return null;
        }

        public static void PopulateExecutingModule(Type type)
        {
            executingModule = (IClassMethods)type.GetConstructor(new Type[] {}).Invoke(new object[] {});


        }

        [STAThread]
        static void Main(string[] args)
        {
            
            
         

            FileInfo latest = GetNewestFile();
            
               
            Type type = GetTypeByFile(latest);
            PopulateExecutingModule(type);
            executingModule.Work();
            

            Console.Read();

        }
       
    }
}
