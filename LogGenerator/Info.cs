using System;

namespace LogGenerator
{
    public class Info
    {
        public static void PrintHelp()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("QA AGH Log Generator");
            Console.WriteLine("--------------------");
            Console.WriteLine("Application which generates logs.");
            Console.WriteLine("New message is logged every 2 seconds.");
            Console.WriteLine("New log file is created every minute.");
            Console.WriteLine("--------------------");
            Console.WriteLine("To run application:");
            Console.WriteLine("Double click LogGenerator.exe or run from command line.");
            Console.WriteLine("Run LogGenerator.exe /? or LogGenerator.exe --help to display this help.");
            Console.WriteLine("Run LogGenerator.exe numberOfSeconds to set application timeout.");
            Console.WriteLine("--------------------");
            Console.WriteLine("To stop application press ctrl + c.");
            Console.WriteLine("--------------------");
        }
    }
}
