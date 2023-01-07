namespace TaskFromResult {

    internal class Program {
        public static string CachedData { get; set; }

        private async static Task Main(string[] args) {

            CachedData = await GetDataAsync();

            Console.WriteLine(CachedData);
        }

        public static Task<string> GetDataAsync() {

            //Task.Run(() => {
            //    return 5;
            //});

            //Task.Run<string>(() => {
            //    return 5;
            //});

            if (String.IsNullOrEmpty(CachedData))
                return File.ReadAllTextAsync(@"C:\Users\MehmetYagci\source\repos\.Net-Core-Asenkron-Multithread-Programlama\TaskExamples\TaskFormApp\dosya.txt");
            else
                return Task.FromResult<string>(CachedData);
        }
    }
}