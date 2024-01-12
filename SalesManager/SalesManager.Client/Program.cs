using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace SalesManager.Client
{
    /// <summary>
    /// The program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Mains the.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>A Task.</returns>
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBlazorBootstrap();

            await builder.Build().RunAsync();
        }
    }
}
