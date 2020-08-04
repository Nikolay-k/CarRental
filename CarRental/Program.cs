using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using NLog.Web;
using System;

namespace CarRental
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                logger.Debug("Api is being initialized");

                var host = CreateWebHostBuilder(args).Build();

                logger.Debug("Api starts");

                host.Run();

                logger.Debug("Api stopped");
            }
            catch (Exception e)
            {
                logger.Error(e, "Api stopped because of exception");
                throw new Exception("Api stopped because of exception", e);
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseNLog();
    }
}
