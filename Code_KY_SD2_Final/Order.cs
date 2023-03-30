using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;


namespace Code_KY_SD2_Final
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Style { get; set; }
        public string TvShow { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string FulfillmentType { get; set; }

        public string CleanPhoneNumber()
        {
            string digitsOnly = Regex.Replace(Phone, "[^0-9]", "");
            string formatted = Regex.Replace(digitsOnly, @"(\d{3})(\d{3})(\d{4})", "($1) $2-$3");
            return formatted;
        }
    }


}





