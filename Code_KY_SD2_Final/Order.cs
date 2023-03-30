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
        public int order_id { get; set; }
        public string customer_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string size { get; set; }
        public string color { get; set; }
        public string style { get; set; }
        public string tv_show { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public string fulfillment_type { get; set; }
    

    public string CleanPhoneNumber()
        {
            string digitsOnly = Regex.Replace(phone, "[^0-9]", "");
            string formatted = Regex.Replace(digitsOnly, @"(\d{3})(\d{3})(\d{4})", "($1) $2-$3");
            return formatted;
        }
    }


}





