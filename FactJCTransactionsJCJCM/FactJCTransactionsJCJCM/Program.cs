using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FactJCTransactionsJCJCM {
    internal class Program {
        static async Task Main(string[] args) {
            try {
                Console.WriteLine("---Started---");

                // Create JsonSerializerSettings with TrimStringConverter
                var jsonSerializerSettings = new JsonSerializerSettings {
                    Converters = { new StringEnumConverter(), new TrimStringConverter() },
                    NullValueHandling = NullValueHandling.Ignore,
                    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                    Formatting = Formatting.Indented
                };

                string projectSummaryInquiryName = @"Anterra-Project-Summary";
                string factJCTransactions2023InquiryName = @"Anterra-FactJCTransactions-JC-2023";
                string selectFields = string.Empty;

                string url = string.Empty;
                string username = string.Empty;
                string password = string.Empty;

                #region Prod
                //url = @"https://carlsonlavine.acumatica.com/OData/Carlson%20LaVine%20Inc/";
                //username = @"svcAnterra";
                //password = @"IloveButter!";

                //url = @"https://forzagroupcompany.acumatica.com/OData/Forza%20Group%20Company/";
                //username = @"AnterraAdmin";
                //password = @"@nt2020!";

                //url = @"https://lifecycleinc.acumatica.com/ODATA/Lifecycle/";
                //username = @"svcAnterra";
                //password = @"Anterra!";

                //url = @"https://gojcm.acumatica.com/OData/JCM%20Production/";
                //username = @"svcAnterra";
                //password = @"GoAnterra!2";


                //url = @"https://infrastripe.acumatica.com/oData/InfraStripe%20Production/";
                //username = @"svcAnterra";
                //password = @"B1Rock$100%";

                //url = @"https://biz.texasscenic.com/AcuProd/OData/TSC/";
                //username = @"svcAnterra";
                //password = @"7e0i+zif?wG""";
                #endregion Prod

                #region Stage

                //url = @"https://acumatica.anterrabi.com/CarlsonLaVine/ODATA/";
                //username = @"svcAnterra";
                //password = @"IloveButter!";

                url = @"https://acumatica.anterrabi.com/Forza/ODATA/DevForza/";
                username = @"AnterraAdmin";
                password = @"@nt2020!";

                //url = @"https://lifecycleinc.acumatica.com/ODATA/Lifecycle/";
                //username = @"svcAnterra";
                //password = @"Anterra!";

                //url = @"https://acumatica.anterrabi.com/InfraStripe/ODATA/";
                //username = @"svcAnterra";
                //password = @"B1Rock$100%";

                //url = @"https://acumatica.anterrabi.com/TSC/OData/DevTSC/";
                //username = @"svcAnterra";
                //password = @"7e0i+zif?wG""";

                #endregion Stage

                await CompareProjectSummaryToFactJCTransactionsJC2023(jsonSerializerSettings, projectSummaryInquiryName, factJCTransactions2023InquiryName, url, username, password);

                Console.WriteLine("---Finished---");
                Console.ReadKey();
            }
            catch (Exception ex) {
                throw;
            }
            
        }

        private static async Task CompareProjectSummaryToFactJCTransactionsJC2023(JsonSerializerSettings jsonSerializerSettings, string projectSummaryInquiryName, string factJCTransactions2023InquiryName, string url, string username, string password) {

            int skip = 0;
            int top = 20000;

            string inquiryUrl = $"{url}{projectSummaryInquiryName}?$format=json&$skip={skip}&$top={top}";

            ProjectSummaryRoot projectSummaryRoot = new ProjectSummaryRoot();

            while (true) {

                using (HttpClient httpClient = new HttpClient()) {

                    Console.WriteLine($"inquiryUrl:{inquiryUrl}");

                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}")));

                    var response = await httpClient.GetAsync(inquiryUrl);
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode) {
                        string json = await response.Content.ReadAsStringAsync();

                        // Parse and process the response here
                        // Console.WriteLine(json);

                        var tempProjectSummaryRoot = JsonConvert.DeserializeObject<ProjectSummaryRoot>(json, jsonSerializerSettings);

                        // Check if there are more items to retrieve
                        if (tempProjectSummaryRoot.value.Count > 0) {

                            projectSummaryRoot.value.AddRange(tempProjectSummaryRoot.value);

                            // Update the skip value to retrieve the next batch of items
                            skip += top;

                            // Update the serviceUrl with the next link
                            inquiryUrl = $"{url}{projectSummaryInquiryName}?$format=json&$skip={skip}&$top={top}";
                        }
                        else {
                            // No more items to retrieve
                            break;
                        }
                    }
                    else {
                        // Handle error here
                        Console.WriteLine($"Error: {response.StatusCode}");
                        break;
                    }
                }
            }

            FactJCTransactionsJCTest3Root factJCTransactionsJCTest3Root = new FactJCTransactionsJCTest3Root();

            skip = 0;

            inquiryUrl = $"{url}{factJCTransactions2023InquiryName}?$format=json&$skip={skip}&$top={top}";
            while (true) {

                using (HttpClient httpClient = new HttpClient()) {

                    Console.WriteLine($"inquiryUrl:{inquiryUrl}");
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}")));

                    var response = await httpClient.GetAsync(inquiryUrl);
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode) {
                        string json = await response.Content.ReadAsStringAsync();

                        // Parse and process the response here
                        // Console.WriteLine(json);

                        var tempFactJCTransactionsJCTest3Root = JsonConvert.DeserializeObject<FactJCTransactionsJCTest3Root>(json, jsonSerializerSettings);

                        // Check if there are more items to retrieve
                        if (tempFactJCTransactionsJCTest3Root.value.Count > 0) {

                            factJCTransactionsJCTest3Root.value.AddRange(tempFactJCTransactionsJCTest3Root.value);

                            // Update the skip value to retrieve the next batch of items
                            skip += top;

                            // Update the serviceUrl with the next link
                            inquiryUrl = $"{url}{factJCTransactions2023InquiryName}?$format=json&$skip={skip}&$top={top}";
                        }
                        else {
                            // No more items to retrieve
                            break;
                        }
                    }
                    else {
                        // Handle error here
                        Console.WriteLine($"Error: {response.StatusCode}");
                        break;
                    }
                }
            }

            Console.WriteLine("Wait");

            var groupedProjects = factJCTransactionsJCTest3Root.value.GroupBy(p => p.ProjectID)
                .Select(g => new { Project = g.Key, Amount = g.Sum(c => decimal.Parse(c.Amount)) });

            Console.WriteLine($"FactJCTransactions-2023 project count: {groupedProjects.Count()}");
            Console.WriteLine($"Project Summary count: {projectSummaryRoot.value.Count}");

            var groupedProjectsSum = groupedProjects.Sum(x => x.Amount);
            var projectSummaryRootSum = projectSummaryRoot.value.Sum(x => decimal.Parse(x.CoststoDate));
            Console.WriteLine($"groupedProjectsSum:{groupedProjectsSum}");
            Console.WriteLine($"projectSummaryRootSum:{projectSummaryRootSum}");

            foreach (var projectSummary in projectSummaryRoot.value) {
                var groupedProject = groupedProjects.FirstOrDefault(x => x.Project == projectSummary.Project);
                if (groupedProject == null) {
                    Console.WriteLine($"Warning!, projectSummary.Project:{projectSummary.Project} does not exists in factJCTransactionsJC' project  CoststoDate:{projectSummary.CoststoDate}");
                    continue;
                }
                if (decimal.Parse(projectSummary.CoststoDate) != groupedProject.Amount) {
                    Console.WriteLine($"Warning! Project:{projectSummary.Project}" +
                        $"  ProjectSummary.CoststoDate :{projectSummary.CoststoDate}" +
                        $"  groupedProject.Amount :{groupedProject.Amount}  ");
                }
            }
        }
    }
}
