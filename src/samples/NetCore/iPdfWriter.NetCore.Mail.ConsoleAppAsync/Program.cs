﻿
using iTin.Logging;
using iTin.Logging.ComponentModel;

using iPdfWriter.NetCore.Mail.ConsoleApp.Code;
using iPdfWriter.NetCore.Mail.ConsoleApp.ComponentModel;

namespace iPdfWriter.NetCore.Mail.ConsoleApp;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        Console.Title = Constants.AppName;

        ILogger logger = new Logger(Constants.AppName, new ILog[] { new FileLog(), new ColoredConsoleLog() }) { Deep = LogDeep.OnlyApplicationCalls, Status = LogStatus.Running };
        logger.Debug(">Start Logging<");

        // 01. Shows how to send pdf output result by email with gmail asynchronously
        logger.Info("");
        logger.Info("> Start Sample 01");
        logger.Info(" > Shows how to send pdf output result by email with gmail asynchronously");
        await Sample01.GenerateAsync();

        // 02. Shows how to send pdf output result by email with Mailtrap (fake SMTP provider service) asynchronously
        logger.Info("");
        logger.Info("> Start Sample 02");
        logger.Info(" > Shows how to send pdf output result by email with Mailtrap (fake SMTP provider service) asynchronously");
        await Sample02.GenerateAsync();

        // 03. Shows how to send pdf output result by email with Ethereal (fake SMTP provider service) asynchronously
        logger.Info("");
        logger.Info("> Start Sample 03");
        logger.Info(" > Shows how to send pdf output result by email with Ethereal (fake SMTP provider service) asynchronously");
        await Sample03.GenerateAsync();

        logger.Info("");
        logger.Debug(">End Logging<");
        Console.ReadKey();
    }
}
