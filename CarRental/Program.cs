using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using NLog;
using NLog.Targets;
using NLog.Web;
using System;
using System.Runtime.InteropServices;

namespace CarRental
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                var configuration = LogManager.Configuration;
                var fileTarget = configuration.FindTargetByName<FileTarget>("log-web");
                fileTarget.FileName = "/home/logfiles/${shortdate}.log";
                LogManager.Configuration = configuration;
            }

            try
            {
                logger.Debug("Site is being initialized");

                var host = CreateWebHostBuilder(args).Build();

                logger.Debug("Site starts");

                host.Run();

                logger.Debug("Site stopped");
            }
            catch (Exception e)
            {
                logger.Error(e, "Site stopped because of exception");
                throw new Exception("Site stopped because of exception", e);
            }
            finally
            {
                LogManager.Shutdown();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseNLog();
    }
}
