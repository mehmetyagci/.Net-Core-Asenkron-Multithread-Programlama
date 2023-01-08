using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelForEach {
    internal class Program {
        static void Main(string[] args) {

            string picturesPath = @"C:\Users\MehmetYagci\Desktop\Pictures";

            var files = Directory.GetFiles(picturesPath);

            // Create a new Stopwatch instance
            Stopwatch stopwatch = new Stopwatch();

            // Start the stopwatch
            stopwatch.Start();

            /// Multi Thread
            Parallel.ForEach(files, (item) => {

                Console.WriteLine("thread no:" + Thread.CurrentThread.ManagedThreadId);

                Image img = new Bitmap(item);

                var thumbnnail = img.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);

                thumbnnail.Save(Path.Combine(picturesPath, "thumbnail", Path.GetFileName(item)));
            });

            // Stop the stopwatch
            stopwatch.Stop();

            // Print the elapsed time to the console
            Console.WriteLine("Multithread Elapsed time: {0}", stopwatch.ElapsedMilliseconds);

            stopwatch.Reset();

            string folderPath = @"C:\Users\MehmetYagci\Desktop\Pictures\thumbnail";

            // Get the list of file paths in the folder
            string[] filePaths = Directory.GetFiles(folderPath);

            // Iterate through the list of file paths
            foreach (string filePath in filePaths) {
                // Delete the file
                File.Delete(filePath);
            }
            Console.WriteLine("All files deleted.");


            stopwatch.Start();

            /// Single Thread
            files.ToList().ForEach(item => {

                Console.WriteLine("thread no:" + Thread.CurrentThread.ManagedThreadId);

                Image img = new Bitmap(item);

                var thumbnnail = img.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);

                thumbnnail.Save(Path.Combine(picturesPath, "thumbnail", Path.GetFileName(item)));
            });

            // Stop the stopwatch
            stopwatch.Stop();

            // Print the elapsed time to the console
            Console.WriteLine("Single Thread Elapsed time: {0}", stopwatch.ElapsedMilliseconds);

            Console.WriteLine("İşlem bitti");
        }
    }
}
