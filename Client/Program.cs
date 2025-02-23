using System;
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
            await client.PostAsync("http://localhost:5245/Calculate?month=5&year=1403&timeout=112",new StringContent(""));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Finished Calculating");
        }
    }
}