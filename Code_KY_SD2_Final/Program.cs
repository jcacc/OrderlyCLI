using Code_KY_SD2_Final;
using Serilog;
using System.Text.RegularExpressions;


class Program
{
    static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("logs.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        string inputCsvFile = "C:\\tmp\\csharp_projects\\Code_KY_SD2_Final\\Code_KY_SD2_Final\\input.csv";
        string outputCsvFile1 = "C:\\tmp\\csharp_projects\\Code_KY_SD2_Final\\Code_KY_SD2_Final\\output1.csv";
        string outputCsvFile2 = "C:\\tmp\\csharp_projects\\Code_KY_SD2_Final\\Code_KY_SD2_Final\\output2.csv";

        var processor = new OrderProcessor<Order>(inputCsvFile, outputCsvFile1, outputCsvFile2, order => Regex.IsMatch(order.FulfillmentType, @"^Location1$"));
        processor.Process();

        Log.Information("Order processing complete.");
        Log.CloseAndFlush();
    }
}
