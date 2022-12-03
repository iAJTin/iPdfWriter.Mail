
using System;

using iTin.Logging;
using iTin.Logging.ComponentModel;

namespace iPdfWriter.Net.Mail.ConsoleApp
{
    using Code;
    using ComponentModel;

    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.Title = Constants.AppName;

            ILogger logger = new Logger(Constants.AppName, new ILog[] { new FileLog(), new ColoredConsoleLog() }) { Deep = LogDeep.OnlyApplicationCalls, Status = LogStatus.Running };
            logger.Debug(">Start Logging<");

            // 01. Generate sample 01 report
            logger.Info("");
            logger.Info("> Start Pdf Sample 01");
            logger.Info(" > Shows how to send pdf output result by email");
            Sample01.Generate();

            logger.Info("");
            logger.Debug(">End Logging<");
            Console.ReadKey();
        }
    }
}
