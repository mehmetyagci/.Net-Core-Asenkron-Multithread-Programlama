using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_29_ParallelForForEachCancellationTokenApp {
    public partial class Form1 : Form {

        private CancellationTokenSource cancellationToken;
        public int Counter { get; set; } = 0;

        public Form1() {
            InitializeComponent();
            cancellationToken = new CancellationTokenSource();
        }

        private void btnGetir_Click(object sender, EventArgs e) {
            listBox1.Items.Clear();

            cancellationToken = new CancellationTokenSource();
            List<string> urls = new List<string> {
                "https://www.cnn.com/",
                "https://www.google.com/",
                "https://www.bbc.co.uk/",
                "https://www.nytimes.com/",
                "https://www.amazon.com/",
                "https://www.reddit.com/",
                "https://www.linkedin.com/",
                "https://www.nasa.gov/",
                "https://www.hbo.com/",
                "https://www.nationalgeographic.com/",
                "https://www.cnbc.com/",
                "https://www.washingtonpost.com/",
            };

            HttpClient client = new HttpClient();

            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.CancellationToken = cancellationToken.Token;

            Task.Run(() => {
                try {
                    Parallel.ForEach<string>(urls, parallelOptions, (url) => {
                        Console.WriteLine($"url:{url}");

                        string content = client.GetStringAsync(url).Result; // Thread 'i blokluyoruz.
                        string data = $"{url}:{content.Length}";

                        //cancellationToken.Token.ThrowIfCancellationRequested();
                        parallelOptions.CancellationToken.ThrowIfCancellationRequested(); 
                        listBox1.Invoke((MethodInvoker)delegate {
                            listBox1.Items.Add(data);
                        });
                    });
                }
                catch (OperationCanceledException oce) {
                    MessageBox.Show($"işlemm iptal edildi: {oce.ToString()}");
                }
                catch (Exception) {

                    MessageBox.Show("Genel bir hata meydana geldi.");
                }
            });
        }

        private void btnArtir_Click(object sender, EventArgs e) {
            btnArtir.Text = Counter++.ToString();
        }

        private void btnIptal_Click(object sender, EventArgs e) {
            cancellationToken.Cancel();
        }
    }
}
