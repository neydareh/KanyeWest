using System;
using KanyeWest.APIQuoteGenerator;
using KanyeWest.CallOfDutyAPI;
using Lamar;
using Microsoft.Extensions.DependencyInjection;

namespace KanyeWest
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintRonAndKanyeConvo(10);
            
            GetCODResponse();
        }
        static void GetCODResponse()
        {
            var container = new Container(x => {
                x.AddSingleton<CallOfDuty>();
            });
            var response = container.GetService<CallOfDuty>();
            response.GetCallOfDutyInfo();
        }
        static void PrintRonAndKanyeConvo(int numberOfConversation)
        {
            var container = new Container(x => {
                x.AddSingleton<GenerateQuote>();
            });
            var quotes = container.GetService<GenerateQuote>();

            Console.WriteLine("Weirdest conversations between Kanye West and Ron Swanson");
            Console.WriteLine();

            for (int i = 0; i < numberOfConversation; i++)
            {
                Console.WriteLine("Ron Swanson: " + quotes.CallRonSwanson());
                Console.WriteLine("Kanye West: " + quotes.CallKanyeAPI());
                Console.WriteLine();
            }
        }
    }
}
