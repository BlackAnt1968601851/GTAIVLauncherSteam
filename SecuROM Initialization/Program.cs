using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Steamworks;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (SteamAPI.Init())
            {
                var GTAIV = "LaunchGTAIV.exe";
                if (File.Exists(GTAIV) == true)
                {
                    var v = System.AppDomain.CurrentDomain.BaseDirectory;
                    Process.Start(GTAIV);
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Error Code: 3\nYou seem to be missing SteamCheck.exe.");
                    Console.ReadKey();
                    Environment.Exit(3);
                }
            }
            if (SteamAPI.IsSteamRunning() == false)
            {
                Console.Clear();
                Console.WriteLine("Steam DRM has failed Error: 1");
                Console.WriteLine("You need to start Steam.");
                Console.ReadKey();
                SteamAPI.Shutdown();
                Environment.Exit(1);
            }
            if (!(SteamAPI.Init()))
            {
                {
                    Console.Clear();
                    Console.WriteLine("Steam DRM has failed Error: 2");
                    Console.WriteLine("You need to purchase GTA IV on steam.");
                    Console.WriteLine("or launch the game from steam.");
                    Console.ReadKey();
                    SteamAPI.Shutdown();
                    Environment.Exit(2);
                }
            }
        }
    }
}
