using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace KanyeWest.APIQuoteGenerator
{
    class GenerateQuote
    {
        private readonly HttpClient _client = new HttpClient();
        public GenerateQuote(HttpClient client)
        {
            _client = client;
        }
        public string CallKanyeAPI()
        {
            string urlKanye = "https://api.kanye.rest";
            var kanyeResponse = _client.GetStringAsync(urlKanye).Result;
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
            return kanyeQuote;
        }
        public string CallRonSwanson()
        {
            string urlRonSwanson = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronSwansonAPIResponse = _client.GetStringAsync(urlRonSwanson).Result;
            var ronSwansonResponse = JArray.Parse(ronSwansonAPIResponse).ToString().Replace("[", "").Replace("]", "").Trim().Trim('\"');
            return ronSwansonResponse;
        }
    }
}
