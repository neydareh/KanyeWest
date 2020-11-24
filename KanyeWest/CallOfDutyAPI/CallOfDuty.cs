using RestSharp;
using System.IO;
using Newtonsoft.Json.Linq;
using System;

namespace KanyeWest.CallOfDutyAPI
{
    public class CallOfDuty
    {
        public void GetCallOfDutyInfo()
        {
            string platform = "battle";
            string gamertag = "Chob%252321309";

            string url = $"https://call-of-duty-modern-warfare.p.rapidapi.com/warzone/{gamertag}/{platform}";
            var CODKeyString = File.ReadAllText("cod_key.json");

            string cod_key = JObject.Parse(CODKeyString).GetValue("CallOfDutyKey").ToString();
            string cod_host = JObject.Parse(CODKeyString).GetValue("CallOfDutyHost").ToString();

            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);

            request.AddHeader("x-rapidapi-key", cod_key);
            request.AddHeader("x-rapidapi-host", cod_host);

            IRestResponse response = client.Execute(request);
            var gamer = ParseJSONToObject(response, "br");

            DisplayGamerInfo(gamer);
        }
        public void DisplayGamerInfo(Gamer gamer)
        {
            Console.WriteLine("*************");
            Console.WriteLine("*  Metrics  *");
            Console.WriteLine("*************");
            Console.WriteLine();
            Console.WriteLine($"Wins: {gamer.Wins}");
            Console.WriteLine($"Kills: {gamer.Kills}");
            Console.WriteLine($"Kill Death Ratio: {gamer.KdRatio}");
            Console.WriteLine($"Score: {gamer.Score}");
            Console.WriteLine($"Games Played: {gamer.GamesPlayed}");
            Console.WriteLine($"Deaths: {gamer.Deaths}");
            Console.WriteLine($"Wins: {gamer.Wins}");
            Console.WriteLine($"Downs: {gamer.Downs}");
        }
        public Gamer ParseJSONToObject(IRestResponse response, string warzone)
        {
            return JObject.Parse(response.Content).GetValue($"{warzone}").ToObject<Gamer>();
        }
    }
}
