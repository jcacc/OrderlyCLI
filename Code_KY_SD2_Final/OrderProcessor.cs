using CsvHelper;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_KY_SD2_Final
{
    
    public class OrderProcessor<T> where T : Order
    {
        private readonly string _inputCsvFile;
        private readonly string _outputCsvFile1;
        private readonly string _outputCsvFile2;
        private readonly Func<T, bool> _splitCondition;

        public string InputCsvFile { get; }
        public string OutputCsvFile1 { get; }
        public string OutputCsvFile2 { get; }

        public OrderProcessor(string inputCsvFile, string outputCsvFile1, string outputCsvFile2, Func<T, bool> splitCondition = null)
        {
            InputCsvFile = inputCsvFile;
            OutputCsvFile1 = outputCsvFile1;
            OutputCsvFile2 = outputCsvFile2;
            _splitCondition = splitCondition;
        }




        public OrderProcessor(string inputCsvFile, string outputCsvFile1, string outputCsvFile2)
            : this(inputCsvFile, outputCsvFile1, outputCsvFile2, null)
        {
        }


        public List<T> ReadOrders(string inputFile)
        {
            using (var reader = new StreamReader(inputFile))
            using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csvReader.GetRecords<T>().ToList();
            }
        }


        public void Process()
        {
            using (var reader = new StreamReader(_inputCsvFile))
            using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var orders = csvReader.GetRecords<T>().ToList();
                var ordersToOutput1 = orders.Where(_splitCondition).ToList();
                var ordersToOutput2 = orders.Except(ordersToOutput1).ToList();

                WriteOrders(OutputCsvFile1, ordersToOutput1);
                WriteOrders(OutputCsvFile2, ordersToOutput2);
            }
        }


        private void WriteOrders(string outputFile, List<T> orders)
        {
            using (var writer = new StreamWriter(outputFile))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords(orders);
            }
        }
    }

}
