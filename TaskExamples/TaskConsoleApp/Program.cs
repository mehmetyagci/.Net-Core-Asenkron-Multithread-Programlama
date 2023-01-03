namespace TaskConsoleApp {
    internal class Program {
        //private async static Task Main(string[] args) {

        //    Console.WriteLine("Hello World");

        //    var mytask = new HttpClient().GetStringAsync("https://www.google.com").ContinueWith
        //        (data => {
        //            Console.WriteLine($"Uzunluk: {data.Result.Length}");
        //        });

        //    Console.WriteLine("Arada yapılacak işler");

        //    await mytask;
        //}


        //private async static Task Main(string[] args) {

        //    Console.WriteLine("Hello World");

        //    var mytask = new HttpClient().GetStringAsync("https://www.google.com");

        //    Console.WriteLine("Arada yapılacak işler");

        //    var data = await mytask;
        //    Console.WriteLine($"Uzunluk: {data.Length}");
        //}
        public static void calis(Task<string> data) {
            // 100 satırlık bir kod 
            Console.WriteLine($"Uzunluk: {data.Result.Length}");
        }

        private async static Task Main(string[] args) {

            Console.WriteLine("Hello World");

            var mytask = new HttpClient().GetStringAsync("https://www.google.com").ContinueWith(data);

            Console.WriteLine("Arada yapılacak işler");

            await mytask;
        }


    } // end of class
} // end of namespace