using System;
using KanyeWest.APIQuoteGenerator;
using Lamar;
using Microsoft.Extensions.DependencyInjection;

namespace KanyeWest
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(x => {
                x.AddSingleton<GenerateQuote>();
            });
            var quotes = container.GetService<GenerateQuote>();

            Console.WriteLine("Weirdest conversations between Kanye West and Ron Swanson");
            Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Ron Swanson: " + quotes.CallRonSwanson());
                Console.WriteLine("Kanye West: " + quotes.CallKanyeAPI());
                Console.WriteLine();
            }
        }
    }
}
