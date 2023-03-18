using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using Code_KY_SD2_Final;
using ConsoleTables;
using Serilog;
using Serilog.Events;

namespace Code_KY_SD2_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            string inputCsvFile = "C:\\tmp\\csharp\\Code_KY_SD2_Final\\Code_KY_SD2_Final\\input.csv";
            string outputCsvFile1 = "output1.csv";
            string outputCsvFile2 = "output2.csv";

            var processor = new OrderProcessor<Order>(inputCsvFile, outputCsvFile1, outputCsvFile2, o => o.FulfillmentType.ToLower() == "pickup");

            while (true)
            {
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. View all orders");
                Console.WriteLine("2. Process and split orders");
                Console.WriteLine("3. View split orders");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice (1-4): ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Log.Information("Reading orders from {InputCsvFile}", inputCsvFile);
                            var orders = processor.ReadOrders(inputCsvFile);
                            Log.Information("Found {OrderCount} orders", orders.Count);
                            DisplayOrders(orders);
                            break;

                        case "2":
                            Log.Information("Processing and splitting orders");
                            processor.Process(); 
                            Log.Information("Orders processed and saved to {OutputCsvFile1} and {OutputCsvFile2}", outputCsvFile1, outputCsvFile2);
                            break;

                        case "3":
                            Log.Information("Reading orders from {OutputCsvFile1}", outputCsvFile1);
                            var orders1 = processor.ReadOrders(outputCsvFile1);
                            Log.Information("Found {OrderCount} orders", orders1.Count);
                            DisplayOrders(orders1);

                            Log.Information("Reading orders from {OutputCsvFile2}", outputCsvFile2);
                            var orders2 = processor.ReadOrders(outputCsvFile2);
                            Log.Information("Found {OrderCount} orders", orders2.Count);
                            DisplayOrders(orders2);
                            break;

                        case "4":
                            Log.Information("Exiting the application");
                            Environment.Exit(0);
                            break;

                        default:
                            Log.Warning("Invalid choice. Please try again.");
                            break;
                    }


                }
                catch (Exception ex)
                {
                    Log.Error(ex, "An error occurred while processing the orders");
                }

                Console.WriteLine();
            }
        }

        private static void DisplayOrders(List<Order> orders)
        {
            var table = new ConsoleTable("ID", "Customer Name", "Email", "Phone", "Address", "Size", "Color", "Style", "TV Show", "Quantity", "Price", "Fulfillment Type");

            foreach (var order in orders)
            {
                table.AddRow(order.OrderId, order.CustomerName, order.Email, order.Phone, order.Address, order.Size, order.Color, order.Style, order.TvShow, order.Quantity, order.Price.ToString("F2"), order.FulfillmentType);
            }

            table.Write(Format.Minimal);
        }
    }
}
