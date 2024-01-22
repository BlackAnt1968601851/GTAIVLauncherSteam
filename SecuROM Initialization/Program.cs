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
                var a = SteamUtils.GetAppID();
                var GTAIV = "SteamCheck.exe";
                if (a == (AppId_t)12210) {
                    if (File.Exists(GTAIV) == true) {
                        Console.Clear();
                        var v = System.AppDomain.CurrentDomain.BaseDirectory;
                        Process.Start(GTAIV, "/immediate 23\\10\\2009 15:18:59" + " \"" + v + "LaunchGTAIV.exe\"");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Error Code: 3\nYou seem to be missing SteamCheck.exe.");
                        Console.ReadKey();
                        Environment.Exit(3);
                    }
                }
                if (!(a == (AppId_t)12210)) {
                    Console.Clear();
                    Console.WriteLine("Steam DRM has failed Error: 4");
                    Console.WriteLine("You need to purchase GTA IV on steam.");
                    Console.WriteLine("Launch the game from GTA IV on steam.");
                    Console.WriteLine("Not from whatever game that is not gta iv.");
                    Console.ReadKey();
                    Environment.Exit(0);
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



