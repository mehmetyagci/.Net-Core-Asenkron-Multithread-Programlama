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

namespace TaskCancelationFormApp {
    public partial class Form1 : Form {
        CancellationTokenSource ct = new CancellationTokenSource();



        public Form1() {
            InitializeComponent();
        }

        private async void btnBaslat_Click(object sender, EventArgs e) {
            Task<HttpResponseMessage> myTask;

            try {

                myTask = new HttpClient()
                                .GetAsync(@"https://localhost:7178/api/Home/getcontent",
                                ct.Token
                                );

                await myTask;

                var content = await myTask.Result.Content.ReadAsStringAsync();

                richTextBox1.Text = content;
            }
            catch (TaskCanceledException tcex) {
                MessageBox.Show(tcex.Message);
            }
            catch (Exception ex) {
                throw;
            }

            // Console.WriteLine($"myTask.IsCanceled:{myTask.IsCanceled.ToString()}"  ); 
        }

        private void btnDurdur_Click(object sender, EventArgs e) {
            ct.Cancel();
        }
    }
}
