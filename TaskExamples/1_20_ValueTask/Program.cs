using System;
using System.Threading.Tasks;

namespace ValueTask {
    internal class Program {

        public static int cachedata { get; set; } = 150;

        private async static Task Main(string[] args) {
            var data = await GetData();
            Console.WriteLine(data);
        }

        public static ValueTask<int> GetData() {
            return new ValueTask<int>(cachedata);
        }
    }
}
