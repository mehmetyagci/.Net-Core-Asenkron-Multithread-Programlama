using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TaskInstanceResultApp2 {
    internal class Program {
        private async static Task Main(string[] args) {

            /// Yöntem 1
            var task = new HttpClient().GetStringAsync("https://www.google.com/");

            await task; // Thread bloklanmadan işlem yapıldı.

            var result = task.Result; // Burada data elimizde artık. İstedğimiz gibi kullanabiliriz

            Console.WriteLine($"result:{result.Substring(0, 100)}");

            /// Yöntem 1
            var task2 = new HttpClient().GetStringAsync("https://www.google.com/")
                .ContinueWith((data) => {
                    var result2 = data.Result;
                    Console.WriteLine($"result2:{result2.Substring(0, 100)}");
                });

            await task2;
        }

        private static string GetData() {
            return string.Empty;

        }
    }
}
