using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;

namespace TaskWebApp.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase {

        [HttpGet("getcontent")]
        public IActionResult GetContent() {
            // Başarısız Yöntemdi, Encoding.RegisterProvider ile çalışıyor. 
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var data = new HttpClient().GetStringAsync("https://www.google.com.tr/").Result;
            return Ok(data);


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

    }  // end of class
} // end of namespace
