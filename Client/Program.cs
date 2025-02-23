using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var client = new HttpClient();
            var response = await client.PostAsync("http://localhost:5245/Calculate?month=5&year=1403&timeout=50",new StringContent(""));
        }
    }
}