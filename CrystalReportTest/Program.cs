using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalReportTest
{
    class Program
    {
        private static void Main(string[] args)
        {
            var fileName = "a.txt";
            var fileName2 = "2a.txt";
            if (args.Length > 0)
            {
                fileName = $"{args[0]}.txt";
                fileName2 = $"{args[1]}.txt";
            }
            Console.WriteLine("Hello World -- Start");
            const string dir = @"App_Data_JP";
            Directory.CreateDirectory(dir);
            var filePath = Path.Combine(dir, fileName);
            var filePath2 = Path.Combine(dir, fileName2);
            File.WriteAllText(filePath, "Hi");
            File.WriteAllText(filePath2, "HiPippo");
            Console.WriteLine($"file path: {filePath}");
            Console.WriteLine("Hello World -- End");
        }
    }
}
