using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelForEach2 {
    internal class Program {
        private static void Main(string[] args) {
            long FilesByte1 = 0;

            // Versiyon 1 - Bozuk Lock suz.
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string picturesPath = @"C:\Users\MehmetYagci\Desktop\Pictures\thumbnail";
            var files = Directory.GetFiles(picturesPath);
            Parallel.ForEach(files, (file, loopstate, index) => {
                FileInfo f1 = new FileInfo(file);
                Console.WriteLine($" Number {f1.Name } has index {index}. Thread no:{Thread.CurrentThread.ManagedThreadId}");
                FilesByte1 = FilesByte1 + f1.Length ;
                Console.WriteLine($"name:{f1.Name} length:{  f1.Length  } FilesByte:{ FilesByte1  }");
            });
            Console.WriteLine($" Final FilesByte:{ FilesByte1 }");

            Console.WriteLine($"===========================================");

            // Versiyon 2 - Locklu :)
            long FilesByte2 = 0;
            sw.Reset();
            sw.Start();
            Parallel.ForEach(files, (file, loopstate, index) => {
                FileInfo f2 = new FileInfo(file);

                Console.WriteLine($" Number {f2.Name } has index {index}. Thread no:{Thread.CurrentThread.ManagedThreadId}");

                // Thread buraya geldiğinde, FilesByte değerini lock luyor. Diğer threadler erişemiyor.
                //Interlocked.Add(ref FilesByte2, f2.Length);

             

                Console.WriteLine($"name:{f2.Name} length:{ f2.Length  } FilesByte:{ FilesByte2  }");
            });
            Console.WriteLine($" Final FilesByte:{ FilesByte2  }");

        } // end of Main method
    } // end of class
} // end of namespace
