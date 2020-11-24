using System;
using KanyeWest.KanyeAPI;
using KanyeWest.RonSwansonAPI;
using Lamar;
using Microsoft.Extensions.DependencyInjection;

namespace KanyeWest
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(x => {
                x.AddSingleton<RonSwanson>();
                x.AddSingleton<Kanye>();
            });

            var ron = container.GetService<RonSwanson>();
            var kanye = container.GetService<Kanye>();

            Console.WriteLine("Weirdest conversations between Kanye West and Ron Swanson");
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Ron Swanson: " + ron.CallRonSwanson());
                Console.WriteLine("Kanye West: " + kanye.CallKanyeAPI());
                Console.WriteLine();
            }
        }
    }
}
