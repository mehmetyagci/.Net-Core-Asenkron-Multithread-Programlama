using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TaskAkis {
    internal class Program {
        private async static Task Main(string[] args) {
            Console.WriteLine("ilk adım");

            var googleTask = GetContentAsync("https://www.google.com/");
            Console.WriteLine($"2. adım google");

            var microsoftTask = GetContentAsync("https://www.microsoft.com/");
            Console.WriteLine($"2. adım microsoft");

            var amazonTask = GetContentAsync("https://www.amazon.com/");
            Console.WriteLine($"2. adım amazon");

           
            var contentGoogle = await googleTask;
            Console.WriteLine($"3. adım Google => " + contentGoogle.Length);

            var contentMicrosoft = await microsoftTask;
            Console.WriteLine("3. adım Microsoft => " + contentMicrosoft.Length);

            var contentAmazon = await amazonTask;
            Console.WriteLine("3. adım Amazon => " + contentAmazon.Length);
        }

        private static async Task<string> GetContentAsync(string url) {
            Console.WriteLine($"GetContent:{url} çalışmaya başladı");
            var content = await new HttpClient().GetStringAsync(url);
            Console.WriteLine($"GetContent:{url} istek yapıldı async");
            return content;
        }
    }
}
