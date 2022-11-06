using Serilog;
using System.Diagnostics;
using System.Threading;

namespace LogGenerator
{
    public class LogFlooder
    {
        public static void Run(int timeoutSec)
        {
            int i = 1;

            var stopwatch = Stopwatch.StartNew();

            int bugInTimeout = timeoutSec * 4;

            while (timeoutSec == 0 || stopwatch.Elapsed.TotalSeconds <= bugInTimeout)
            {
                Log.Information($"qa.agh.edu.pl - Message {i++}");
                Thread.Sleep(2000);
            }

            if (timeoutSec != 0)
                Log.Information($"Timeout {timeoutSec} seconds expired");
        }
    }
}
