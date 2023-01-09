using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _4_30_AsParallel {
    internal class Program {

        private static bool Islem(int x) {
            Thread.Sleep(30);
            return x % 2 == 0;
        }
        static void Main(string[] args) {

            var array = Enumerable.Range(1, 1000).ToList();
            // 100 sayı var 5 Thread kullanıldığını varsayalım
            // 1. Thread 'e  1-20 arasındaki sayıları kontrol edecek
            // 2. Thread 'e 21-40 arasındaki sayıları kontrol edecek
            // 3. Thread 'e 41-60 arasındaki sayıları kontrol edecek
            // 4. Thread 'e 61-80 arasındaki sayıları kontrol edecek
            // 5. Thread 'e 81-100 arasındaki sayıları kontrol edecek

            // Parallel olmayan çalışma
            //array.Where(x => x % 2 == 0).ToList().ForEach(x => {
            //    Console.WriteLine(x);
            //});

            // Parallel çalışma
            //var newArray = array.AsParallel()
            //                    .Where(x => x % 2 == 0); // ParallelQuery dönüyor late binding 
            var newArray = array.AsParallel()
                                .Where(Islem); // ParallelQuery dönüyor late binding

            newArray.ToList().ForEach(x => {
                Console.WriteLine($"ThreadId:{Thread.CurrentThread.ManagedThreadId} x:{x}");
            });
        }
    }
}
