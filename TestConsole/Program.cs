// See https://aka.ms/new-console-template for more information

using SimpleSur.Logger;
using SimpleSur.Logger.LogWriters;

Console.WriteLine("Hello, World!");

var logger = LoggerFactory.Create();

var env = LogHelper.GetEnvironmentInfo();

logger.LogInfo(env);

logger.LogWarn("hi");



var logger1 = LoggerFactory.Create("file1.log");
LogHelper.LogEnvironmentInfo(logger1);

logger1.LogError("fuck");

try
{
    var cmp = new CompositeLogWriter(null);
}
catch (Exception e)
{
    Console.WriteLine(e);
}