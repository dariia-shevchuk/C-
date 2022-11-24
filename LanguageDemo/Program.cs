using LanguageDemo.Interfaces;
using LanguageDemo.Language;
using LanguageDemo.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace LanguageDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            var host = Host.CreateDefaultBuilder().ConfigureServices(Configure).Build();
            var app = ActivatorUtilities.CreateInstance<App>(host.Services);
            app.Start();

        }

        private static void Configure(IServiceCollection service)
        {
            service.AddTransient<IMenu, Menu>();
            service.AddTransient<ILanguageManager, LanguageManager>();
            service.AddTransient<IResponsProvider, ConsoleResponsProvider>();
        }
    }
}
