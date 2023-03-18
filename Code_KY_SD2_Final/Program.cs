using Code_KY_SD2_Final;
using Serilog;
using System.Text.RegularExpressions;


class Program
{
    static void Main(string[] args)
    {
        // Configure logging
        // ...

        string inputCsvFile = "C:\\tmp\\csharp_projects\\Code_KY_SD2_Final\\Code_KY_SD2_Final\\input.csv";
        string outputCsvFile1 = "C:\\tmp\\csharp_projects\\Code_KY_SD2_Final\\Code_KY_SD2_Final\\output1.csv";
        string outputCsvFile2 = "C:\\tmp\\csharp_projects\\Code_KY_SD2_Final\\Code_KY_SD2_Final\\output2.csv";

        var processor = new OrderProcessor<Order>(inputCsvFile, outputCsvFile1, outputCsvFile2, order => Regex.IsMatch(order.FulfillmentType, @"^Location1$"));

        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Order Management System");
            Console.WriteLine("========================");
            Console.WriteLine("1. View Input Orders");
            Console.WriteLine("2. Process Orders");
            Console.WriteLine("3. View Processed Orders");
            Console.WriteLine("4. Exit");
            Console.Write("\nEnter your choice: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nInput Orders:");
                        DisplayOrders(processor.ReadOrders(inputCsvFile));
                        break;
                    case 2:
                        processor.Process();
                        Log.Information("Order processing complete.");
                        Console.WriteLine("\nOrders processed successfully.");
                        break;
                    case 3:
                        Console.WriteLine("\nProcessed Orders (Location1):");
                        DisplayOrders(processor.ReadOrders(outputCsvFile1));
                        Console.WriteLine("\nProcessed Orders (Location2):");
                        DisplayOrders(processor.ReadOrders(outputCsvFile2));
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input. Please try again.");
            }

            if (!exit)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        Log.CloseAndFlush();
    }

    private static void DisplayOrders(List<Order> orders)
    {
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("ID\tFulfillment Type\tShipping Method\tCustomer Name\tProduct\tQuantity");
        Console.WriteLine("-----------------------------------------------------");
        foreach (var order in orders)
        {
            Console.WriteLine($"{order.Id}\t{order.FulfillmentType}\t{order.ShippingMethod}\t{order.CustomerName}\t{order.Product}\t{order.Quantity}");
        }
    }
}

