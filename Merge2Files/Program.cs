using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge2Files
{
    public class Program
    {
        static void Main(string[] args)
        {
            var file1 = "org.txt";
            var file2 = "new.txt";
            var fileMerge = "merged.txt";
            if (args.Length > 0)
                file1 = args[0];
            if (args.Length > 1)
                file2 = args[1];
            if (args.Length > 2)
                fileMerge = args[2];
            Console.WriteLine($"Read file1 {file1}");
            var list1 = RemoveEmptyLines(File.ReadAllLines(file1).ToList());
            Console.WriteLine($"Read file2 {file2}");
            var list2 = RemoveEmptyLines(File.ReadAllLines(file2).ToList());
            Console.WriteLine($"Merge");

            foreach (var list2Item in list2)
            {
                if (list1.Where(item => item == list2Item).FirstOrDefault() == null)
                    list1.Add(list2Item);
            }
            Console.WriteLine($"Write merged {fileMerge}");
            File.WriteAllLines(fileMerge, list1);
            Console.ReadKey();
        }

        public static List<string> RemoveEmptyLines(List<string> list)
        {
            for (int i = list.Count - 1; i >= 0; i--)
                if (list[i].Length == 0)
                    list.RemoveAt(i);
            return list;
        }
    }
}
