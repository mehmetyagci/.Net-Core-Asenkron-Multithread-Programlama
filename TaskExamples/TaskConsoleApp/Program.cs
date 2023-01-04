using System.Diagnostics;

namespace TaskConsoleApp {
    internal class Program {
        private async static Task Main(string[] args) {

            var stopwatch = new Stopwatch();

            Console.WriteLine($"Main Thread:{Thread.CurrentThread.ManagedThreadId}");
            List<string> urlsList = new List<string>() {
                "https://www.google.com",
                "https://www.amazon.com/",
                "https://www.yahoo.com/",
                "https://www.mynet.com/",
                "https://www.microsoft.com",
            };

            List<Task<Content>> taskList = new List<Task<Content>>();
            urlsList.ToList().ForEach(url => {
                taskList.Add(GetContentAsync(url));
            });

            stopwatch.Start();

            var contents = await Task.WhenAll(taskList.ToArray());
            contents.ToList().ForEach(task => {
                Console.WriteLine(task.Site + task.Length);
            });

            stopwatch.Stop();
            Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");

        }

        public static async Task<Content> GetContentAsync(string url) {
            Content content = new Content();
            var data = await new HttpClient().GetStringAsync(url);

            await Task.Delay(5000);

            content.Site = url;
            content.Length = data.Length;
            Console.WriteLine($"GetContentAsync thread: {Thread.CurrentThread.ManagedThreadId}");
            return content;
        }

        public class Content {
            public string Site { get; set; }
            public int Length { get; set; }
        }
    } // end of class
} // end of namespace