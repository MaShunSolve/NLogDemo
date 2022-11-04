using NLog;
using NLog.Fluent;

internal class Program
{
    private static void Main(string[] args)
    {
        Logger log = LogManager.GetCurrentClassLogger();
        log.Info("這是一個簡單的測試");

    }
}