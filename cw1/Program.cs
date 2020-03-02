using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cw1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //int? nullTest = null;
            //var tmp = "sadqw1";
            //var newPerson = new Person { FirstName = "Piotr" };
            //Console.WriteLine($"{tmp} {nullTest}");
            var path = @"P:\FTP(Public)\pgago\APBD";

            var url = args.Length > 0 ? args[0] : "https://pja.edu.pl";
            HttpClient httpClient = new HttpClient();
            using (httpClient)
            {
                var response = await httpClient.GetAsync(url);
                using (response)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var htmlContent = await response.Content.ReadAsStringAsync();
                        var mailRegex = new Regex("[a-z]+[a-z1-9]*@[a-z1-9]+\\.[a-z]+", RegexOptions.IgnoreCase);
                        var matches = mailRegex.Matches(htmlContent);
                        foreach (var match in matches)
                        {
                            Console.WriteLine(match.ToString());
                        }
                    }
                }
                
            }
            
        }
    }
}
