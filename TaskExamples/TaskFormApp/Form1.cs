using System.Text;
using System.Net.Http;
using System.Threading;

namespace TaskFormApp {
    public partial class Form1 : Form {
        public int counter { get; set; } = 0;

        public Form1() {
            InitializeComponent();
            System.Text.EncodingProvider provider = System.Text.CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(provider);
        }

        //private void btnReadFile_Click(object sender, EventArgs e) {
        //    string data = ReadFile();
        //    richTextBox1.Text = data;
        //}

        private async void BtnReadFile_Click(object sender, EventArgs e) {
            string data = string.Empty;
            Task<string> okuma = ReadFileAsync();

            // Ba�ka bir i�lem 
            richTextBox2.Text = new HttpClient().GetStringAsync("https://www.google.com.tr/").Result;

            data = await okuma; // sonucu bekle.
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
                // �stteki sat�r ile alttaki sat�r aras�nda ba�ka i�ler yap�labilir.
                // WebRequest at�labilir vs...

                await Task.Delay(5000);

                data = await myTask;
                return data;
            }
        }
    } // end of class
} // end of namespace