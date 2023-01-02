using System.Text;

namespace TaskFormApp {
    public partial class Form1 : Form {
        public int counter { get; set; } = 0;

        public Form1() {
            InitializeComponent();
        }

        //private void btnReadFile_Click(object sender, EventArgs e) {
        //    string data = ReadFile();
        //    richTextBox1.Text = data;
        //}

        private async void btnReadFile_Click(object sender, EventArgs e) {
            string data = await ReadFileAsync();
            richTextBox1.Text = data;
        }

        private void btnSayacArtir_Click(object sender, EventArgs e) {
            textBoxCounter.Text = (counter = counter + 1).ToString();
        }

        private string ReadFile() {
            string data = string.Empty;
            using (StreamReader s = new StreamReader("dosya.txt")) {
                Thread.Sleep(5000);
                data = s.ReadToEnd();
            }
            return data;
        }

        private async Task<string> ReadFileAsync() {
            string data = string.Empty;
            using (StreamReader s = new StreamReader("dosya.txt")) {
                Task<string> myTask = s.ReadToEndAsync(); // 
                // Üstteki satýr ile alttaki satýr arasýnda baþka iþler yapýlabilir.
                // WebRequest atýlabilir vs...

                await Task.Delay(5000);

                data = await myTask;
                return data;
            }
        }
    } // end of class
} // end of namespace