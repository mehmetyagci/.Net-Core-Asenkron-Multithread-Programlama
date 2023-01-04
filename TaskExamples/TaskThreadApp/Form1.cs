namespace TaskThreadApp {
    public partial class Form1 : Form {

        public static int Counter { get; set; } = 0;
        public Form1() {
            InitializeComponent();
        }

        //private void btnStart_Click(object sender, EventArgs e) {
        //    Go(progressBar1);
        //    Go(progressBar2);
        //}

        //public void Go(ProgressBar progressBar) {
        //    Enumerable.Range(1, 100).ToList().ForEach(x => {
        //        Thread.Sleep(100);
        //        progressBar.Value = x;
        //    });
        //}

        private async void btnStart_Click(object sender, EventArgs e) {
            var aTask = Go(progressBar1, textBox1);
            var bTask = Go(progressBar2, textBox2);

            await Task.WhenAll(aTask, bTask);
        }

        public async Task Go(ProgressBar progressBar, TextBox textBox) {
            await Task.Run(() => {
                
                Enumerable.Range(1, 100).ToList().ForEach(x => {

                    Thread.Sleep(100);

                    progressBar.Invoke((MethodInvoker)delegate {
                        progressBar.Value = x;
                        progressBar.Text = x.ToString();
                        textBox.Text = x.ToString() + " ManagedThreadId:" + Thread.CurrentThread.ManagedThreadId;

                        if (progressBar.Value == 10) {
                            MessageBox.Show($"{progressBar.Name} is {progressBar.Value}");
                        } else if (progressBar.Value == 50) {
                            MessageBox.Show($"{progressBar.Name} is {progressBar.Value}");
                        }
                    });
                });
            });
        }

        private void btnCounter_Click(object sender, EventArgs e) {
            btnCounter.Text = Counter++.ToString();
        }
    }
}