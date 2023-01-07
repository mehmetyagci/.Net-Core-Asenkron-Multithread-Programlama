using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TaskInstanceResultApp {

    internal class Program {
        private async static Task Main(string[] args) {

            Console.WriteLine($"Main1->ManagedThreadId:{Thread.CurrentThread.ManagedThreadId.ToString()}");
            Console.WriteLine($"GetData():{GetData().Substring(0,10)}");
            Console.WriteLine($"Main2->ManagedThreadId:{Thread.CurrentThread.ManagedThreadId.ToString()}");
            var asyncResult = await GetDataAsync();
            Console.WriteLine($"Main3->ManagedThreadId:{Thread.CurrentThread.ManagedThreadId.ToString()}");
            Console.WriteLine($"asyncResult:{asyncResult.Substring(0, 10)}");
            Console.WriteLine($"Main4->ManagedThreadId:{Thread.CurrentThread.ManagedThreadId.ToString()}");
        }


        public static string GetData() {
            Console.WriteLine($"GetData1->ManagedThreadId:{Thread.CurrentThread.ManagedThreadId.ToString()}");

            var task = new HttpClient().GetStringAsync("https://www.google.com/");

            Console.WriteLine($"GetData2->ManagedThreadId:{Thread.CurrentThread.ManagedThreadId.ToString()}");

            return task.Result;  // Thread 'i bloklar. Winform' da Pencereyi taşımayı, başka bir button 'a tıklamayı vs. engeller.
        }

        public static Task<string> GetDataAsync() {
            Console.WriteLine($"GetDataAsync1->ManagedThreadId:{Thread.CurrentThread.ManagedThreadId.ToString()}");

            var task = new HttpClient().GetStringAsync("https://www.google.com/");
            Console.WriteLine($"GetDataAsync2->ManagedThreadId:{Thread.CurrentThread.ManagedThreadId.ToString()}");

            return task;   
        }
    }
}
