using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace KanyeWest
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            string urlKanye = "https://api.kanye.rest";

            var kanyeResponse = client.GetStringAsync(urlKanye).Result;

            Console.WriteLine(kanyeResponse);

            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
            Console.WriteLine();
            Console.WriteLine(kanyeQuote);

        }
    }
}
