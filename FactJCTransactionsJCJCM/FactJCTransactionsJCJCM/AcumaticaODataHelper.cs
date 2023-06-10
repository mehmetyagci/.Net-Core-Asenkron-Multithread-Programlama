using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FactJCTransactionsJCJCM {
    public static class AcumaticaODataHelper {

        public static async Task<string> QueryGenericInquiry(string username, string password, string url, string inquiryName, string selectFields,int skip, int top) {
            // Set up the HttpClient with authentication headers
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}")));

            // Construct the URL for the generic inquiry request
            string inquiryUrl = $"{url}{inquiryName}?$format=json&$skip={skip}&$top={top}";
            if (!string.IsNullOrEmpty(selectFields)) {
                inquiryUrl += $"?$select={selectFields}";
            }

            // Send the GET request to Acumatica OData API
            var response = await client.GetAsync(inquiryUrl);

            //var responseStream = await response.Content.ReadAsStreamAsync();

            response.EnsureSuccessStatusCode();

            // Read the JSON response as a string
            string responseJson = await response.Content.ReadAsStringAsync();

            return responseJson;
        }
    }
}
