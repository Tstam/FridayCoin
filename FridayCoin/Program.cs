#region Using directives

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

#endregion

namespace FridayCoin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}