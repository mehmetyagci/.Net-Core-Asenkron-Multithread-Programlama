using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;


namespace ParallelForApp {
    internal class Program {
        static void Main(string[] args) {

            long totalByte = 0;

            var files = Directory.GetFiles(@"C:\Users\MehmetYagci\Desktop\Pictures\thumbnail");

            Parallel.For(0, files.Length, (index) => {
                var fileInfo = new FileInfo(files[index]);
                Console.WriteLine($"fileInfo:{fileInfo.Name} length:{fileInfo.Length}");
                Interlocked.Add(ref totalByte, fileInfo.Length);
                Console.WriteLine($"totalByte:{totalByte.ToString()} ");
            });

            Console.WriteLine("End of Total Byte:" + totalByte.ToString());
        }
    }
}
