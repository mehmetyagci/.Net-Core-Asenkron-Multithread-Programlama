using System;
using System.Threading.Tasks;

namespace TaskInstanceApp {
    internal class Program {
        static async Task Main(string[] args) {
            Task myTask = Task.Run(() => {
               throw new Exception("bir hata geldi");
            });

            await myTask;

            Console.WriteLine("İşlem bitti");


        }
    }
}
