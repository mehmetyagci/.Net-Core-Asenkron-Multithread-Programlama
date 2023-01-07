using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;

namespace TaskWebApp.API.Controllers {


    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        [HttpGet("getcontent")]
        public async Task<IActionResult> GetContent(CancellationToken ct) {


            try {

                _logger.LogInformation("İstek başladı");

                await Task.Delay(5000, ct); // 10 sn. bekle

                // Manuel Throw fırlatma
                ct.ThrowIfCancellationRequested();

                // Başarısız Yöntemdi, Encoding.RegisterProvider ile çalışıyor. 
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                var data = new HttpClient().GetStringAsync("https://www.google.com.tr/").Result;

                _logger.LogInformation("İstek bitti");
                return Ok(data);
            }
            catch (Exception ex) {
                _logger.LogInformation("İstek iptal edildi.Exception details are:" + ex.ToString());
                return BadRequest();
            }




            // Başarılı Yöntem 1.
            //byte[] responseBytes = new HttpClient().GetByteArrayAsync("https://www.google.com.tr/").Result;
            //string responseString = Encoding.UTF8.GetString(responseBytes);
            //return Ok(responseString);

            // Başarılı Yöntem 2.
            //var client = new HttpClient();
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            //client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
            //client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "text/html; charset=utf-8");
            //string responseString = client.GetStringAsync("https://www.google.com.tr/").Result;
            //return Ok(responseString);

        }

        [HttpGet("getcontentasync")]
        public async Task<IActionResult> GetContentAsync() {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);


            // 5. Thread aşağıdaki isteği karşılıyor olsun.
            // 1. istek te Thread 5 aşağıdaki satırdan  sonra bloklanmıyor.
            // 2. İstek gelince Thread 5 gelen isteği karşılıyor.
            var myTask = new HttpClient().GetStringAsync("https://www.google.com.tr/");

            var data = await myTask;

            return Ok(data);

        }

        [HttpGet("getcontentasync2")]
        public async Task<IActionResult> GetContentAsync2(CancellationToken ct) {
            try {

                _logger.LogInformation("İstek başladı");

                Enumerable.Range(1, 10).ToList().ForEach(x => {
                    Thread.Sleep(1000);

                    ct.ThrowIfCancellationRequested();
                });

                _logger.LogInformation("İstek bitti");
                return Ok("işler bitti");
            }
            catch (Exception ex) {
                _logger.LogInformation("İstek iptal edildi.Exception details are:" + ex.ToString());
                return BadRequest();
            }
        }

}  // end of class
} // end of namespace
