using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// Referenced: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-2.2
// https://stackoverflow.com/questions/10679214/how-do-you-set-the-content-type-header-for-an-httpclient-request

namespace API_Requests
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {            
            client.BaseAddress = new Uri("https://postman-echo.com/");
            //client.DefaultRequestHeaders
                //.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            PostRequest().Wait();
            GetRequest().Wait();
            PutRequest().Wait();
            PatchRequest().Wait();
        }

        static async Task PostRequest()
        {
            Console.WriteLine("\n\n\tPost Request...");

            string url = "post";
            Console.WriteLine(client.BaseAddress + url);

            var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"item1", "value1"}
            });

            var response = await client.PostAsync(url, content);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Console.WriteLine("Result:");
            Console.WriteLine(responseString);
        }

        static async Task GetRequest()
        {
            Console.WriteLine("\n\n\tGet Request...");

            string url = "get?foo1=bar1&foo2=bar2";
            Console.WriteLine(client.BaseAddress + url);

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Console.WriteLine("Result:");
            Console.WriteLine(responseString);
        }

        static async Task PutRequest()
        {
            Console.WriteLine("\n\n\tPut Request...");

            string url = "put";
            Console.WriteLine(client.BaseAddress + url);

            var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"item1", "value1"}
            });

            var response = await client.PutAsync(url, content);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Console.WriteLine("Result:");
            Console.WriteLine(responseString);
        }

        static async Task PatchRequest()
        {
            Console.WriteLine("\n\n\tPatch Request...");

            string url = "patch";
            Console.WriteLine(client.BaseAddress + url);

            var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"item1", "value1"}
            });

            var response = await client.PatchAsync(url, content);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Console.WriteLine("Result:");
            Console.WriteLine(responseString);
        }
    }
}
