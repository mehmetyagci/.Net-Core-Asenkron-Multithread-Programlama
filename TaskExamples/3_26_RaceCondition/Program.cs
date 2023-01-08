using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _3_26_RaceCondition {
    internal class Program {
        static void Main(string[] args) {

            int deger = 0;
            string fileName = "3_26_RaceCondition.txt";
            string str = string.Empty;

            using (StreamWriter writer = new StreamWriter(fileName, true)) {
                Parallel.ForEach(Enumerable.Range(1, 1000).ToList(), (x) => {
                    Interlocked.Exchange(ref deger , x);
                    str = $"x:{x} deger:{deger} thread:{Thread.CurrentThread.ManagedThreadId}";
                    Console.WriteLine(str);
                    writer.WriteLine(str);
                });
                str = "son deger:" + deger;
                Console.WriteLine(str);
                writer.WriteLine(str);
            }
        }
    }
}
