using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TarikGuneyTPL {
    internal class Program {
        #region Versiyon 1
        //static void Main(string[] args) {
        //    var t = GetGoogleSourceCode().ContinueWith(task => { Console.WriteLine(task.Result); });
        //    Console.WriteLine("Finished");
        //}

        //private static Task<string> GetGoogleSourceCodeAsync() {
        //    var httpClient = new HttpClient();
        //    var t = Task.Run(() => {
        //        return httpClient.GetStringAsync("https://www.google.com").Result;
        //    });
        //    return t;
        //}
        #endregion Versiyon 1

        #region Versiyon 2

        static void Main(string[] args) {
            var t = GetGoogleSourceCodeAsync(); // .ContinueWith(task => { Console.WriteLine(task.Result); });
            Console.WriteLine("Finished");
        }

        private async  static Task GetGoogleSourceCodeAsync() {
            try {
                var httpClient = new HttpClient();
                var result = await httpClient.GetStringAsync("https://www.google.com");
                Console.WriteLine(result);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
            finally {
                Console.WriteLine("finished 1");
            }
        }

        #endregion Versiyon 2
    }
}
