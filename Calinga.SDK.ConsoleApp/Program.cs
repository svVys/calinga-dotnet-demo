﻿using static System.FormattableString;

using System;
using System.Threading.Tasks;
using Calinga.Infrastructure;

namespace Calinga.SDK.ConsoleApp
{
    internal static class Program
    {
        private static async Task Main()
        {
            Console.WriteLine("calinga service: try to get translations");

            var service = new CalingaService(AppCalingaServiceSettings);

            var translation = await service.TranslateAsync("Button.Cancel", "en").ConfigureAwait(false);

            Console.WriteLine(Invariant($"Key: Button.Cancel,  Translation: {translation}"));

             translation = await service.TranslateAsync("Button.Create", "en").ConfigureAwait(false);

            Console.WriteLine(Invariant($"Key: Button.Create,  Translation: {translation}"));

            Console.WriteLine("clean cache...");
            service.ClearCache();

            Console.ReadKey(false);
        }

        private static CalingaServiceSettings AppCalingaServiceSettings => new CalingaServiceSettings
        {
            Tenant = "SdkSample",

            Project = "ExampleProject",

            ApiToken = "dd60c24b1353f14fc614742e1a9c687a",

            Version = "v1",

            IsDevMode = false,

            CacheDirectory = AppDomain.CurrentDomain.BaseDirectory
        };
    }
}
