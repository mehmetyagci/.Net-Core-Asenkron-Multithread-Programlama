using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _4_31_ForAll {
    internal class Program {

        private static bool Islem(int x) {
            Thread.Sleep(30);
            return x % 2 == 0;
        }


        static void Main(string[] args) {
            var array = Enumerable.Range(1, 20).ToList();

            var newArray = array.AsParallel()
                               .Where(Islem); // ParallelQuery dönüyor late binding

            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            // Single Thread
            newArray.ToList().ForEach(x => {
                Thread.Sleep(500);
                Console.WriteLine($"x:{x} ThreadId:{Thread.CurrentThread.ManagedThreadId}");
            });
            Console.WriteLine($"1.{stopwatch.ElapsedMilliseconds}");

            stopwatch.Reset();

            stopwatch.Restart();
            // Multi Thread
            newArray.ForAll(x => {
                Thread.Sleep(500);
                Console.WriteLine($"x:{x} ThreadId:{Thread.CurrentThread.ManagedThreadId}");
            });
            Console.WriteLine($"2.{stopwatch.ElapsedMilliseconds}");
        }
    }
}
