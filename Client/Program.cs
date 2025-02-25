using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var client = new HttpClient();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Started Calculating");
            Console.ForegroundColor = ConsoleColor.Yellow;
            var httpResponseMessage = await client.PostAsync("http://localhost:5245/Calculate?month=5&year=1403&timeout=1",new StringContent(""));
            var requestHeadersKeyValuePair = httpResponseMessage.Headers.Select(kvp => $"{kvp.Key}: {string.Join("",kvp.Value)}");
            var response =
                $"{httpResponseMessage.StatusCode}{Environment.NewLine}{string.Join(Environment.NewLine, requestHeadersKeyValuePair)}{Environment.NewLine}{httpResponseMessage.Content.ReadAsStringAsync().Result}";
            Console.WriteLine(response);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Finished Calculating");
        }
    }
}