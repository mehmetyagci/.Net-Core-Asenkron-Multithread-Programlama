using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelForForEachThreadLocalVariables {
    internal class Program {
        static void Main(string[] args) {

            int total = 0;

            Parallel.ForEach(Enumerable.Range(0, 100).ToList(), () => 0, (x, loop, subtotal) => {
                System.Console.WriteLine("Thread:" + Thread.CurrentThread.ManagedThreadId);
                subtotal += x;
                return subtotal;
            }, (y) => Interlocked.Add(ref total, y));

            System.Console.WriteLine("===============================" + total);

            total = 0;

            Parallel.For(0, 100, () => 0, (x, loop, subtotal) => {
                System.Console.WriteLine("Thread:" + Thread.CurrentThread.ManagedThreadId);
                subtotal += x;
                return subtotal;
            }, (y) => Interlocked.Add(ref total, y));

            System.Console.WriteLine("===============================" + total);
        }
    }
}
