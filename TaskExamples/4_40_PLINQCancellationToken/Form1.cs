using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4_40_PLINQCancellationToken {
    public partial class Form1 : Form {

        CancellationTokenSource cts;
        public Form1() {
            InitializeComponent();
            cts = new CancellationTokenSource();
        }

        private bool Hesapla(int x) {
            // Thread.Sleep  kullanmıyoruz. Thread bloklanmasın.
            Thread.SpinWait(5000); // 500 kere iterasyon yapacak. Geçikme vermek için
            return x % 12 == 0;
        }

        private void button1_Click(object sender, EventArgs e) {
            Task.Run(() => {
                try {


                    Enumerable.Range(1, 1000000).AsParallel().
                        WithCancellation(cts.Token).
                        Where(Hesapla).
                        ToList().
                        ForEach(x => {
                            Thread.Sleep(10);
                            cts.Token.ThrowIfCancellationRequested();
                            listBox1.Invoke((MethodInvoker)delegate {
                                listBox1.Items.Add(x);
                            });
                        });
                }
                catch (OperationCanceledException opcex) {
                    MessageBox.Show("İşlem iptal edili");
                }
                catch (Exception ex) {
                    MessageBox.Show("Genel bir hata oluştu");
                    throw;
                }
            });
        }
        private void button2_Click(object sender, EventArgs e) {
            cts.Cancel();
        }
    }
}
