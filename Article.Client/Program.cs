using Article.Client.Services.Interfaces;
using Article.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Article.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");


            builder.Services
                 .AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7024/") })
                 .AddScoped<IHttpClientService, HttpClientService>()
                 .AddScoped<IArticleService, ArticleClientService>();

            await builder.Build().RunAsync();
        }
    }
}
