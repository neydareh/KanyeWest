using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace KanyeWest.KanyeAPI
{
    public class Kanye
    {
        public string CallKanyeAPI()
        {
            var client = new HttpClient();
            string urlKanye = "https://api.kanye.rest";
            var kanyeResponse = client.GetStringAsync(urlKanye).Result;
            //Console.WriteLine(kanyeResponse);
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
            return kanyeQuote;
        }
    }
}
