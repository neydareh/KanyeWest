using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace KanyeWest.RonSwansonAPI
{
    public class RonSwanson
    {
        public string CallRonSwanson()
        {
            var client = new HttpClient();
            string urlRonSwanson = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            var ronSwansonAPIResponse = client.GetStringAsync(urlRonSwanson).Result;

            var ronSwansonResponse = JArray.Parse(ronSwansonAPIResponse).ToString()
                .Replace("[", "").Replace("]", "")
                .Trim().Trim('\"');

            //Console.WriteLine("Response: " + client.GetStringAsync(urlRonSwanson));
            return ronSwansonResponse;
        }
    }
}
