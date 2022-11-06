using Serilog;
using System;

namespace LogGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.CancelKeyPress += delegate
            {
                Log.Information("Log generator has been terminated.");
                Log.Information("Run LogGenerator.exe /? to display more info.");
                //return;
            };

            if (IsHelpRequested(args))
                return;

            if (!CheckArguments(args, out int timeoutSec))
                return;

            ConfigureLogger();

            Log.Information("Starting LogGenerator.");
            if (timeoutSec == 0)
                Log.Information("Timeout was not set. Press ctrl+c to finish program.");

            LogFlooder.Run(timeoutSec);

            Log.Information("Log generator has finished processing.");
            Log.Information("Run LogGenerator.exe /? to display more info.");
        }

        private static void ConfigureLogger()
        {
            string logDirName = $"..\\Logs\\";
            string logFileName = logDirName + "LogGenerator.log";

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logFileName, rollingInterval: RollingInterval.Minute)
                .CreateLogger();
            Log.Information($"Writing logs to directory '{logDirName}'");
        }

        private static bool IsHelpRequested(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0] == "/?" || args[0] == "--help")
                {
                    Info.PrintHelp();
                    return true;
                }
            }

            return false;
        }

        private static bool CheckArguments(string[] args, out int timeoutSec)
        {
            timeoutSec = 0;

            if (args.Length > 0)
            {
                if (int.TryParse(args[0], out timeoutSec))
                {
                    Console.WriteLine($"Setting application timeout={timeoutSec} seconds.");
                }
                else
                {
                    Console.WriteLine($"Provided argument is not valid integer.");
                    Console.WriteLine($"Run LogGenerator.exe /? to display help.");
                    return false;
                }
            }

            return timeoutSec >= 0;
        }
    }
}
